using DesktopVodovoz.Command;
using DesktopVodovoz.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DesktopVodovoz.ViewModels
{
    class UpdateUserVM : INotifyPropertyChanged
    {
        //Combobox Division
        private ObservableCollection<ModelDivision> _division;
        public ObservableCollection<ModelDivision> Division
        {
            get { return _division; }
            set
            {
                _division = value;
                OnPropertyChanged("Division");
            }
        }

        private int? _selectedDivision;
        public int? SelectedDivision
        {
            get
            { return _selectedDivision; }
            set
            {
                _selectedDivision = value;
                OnPropertyChanged("SelectedDivision");
            }
        }

        //Combobox Gender 
        public ObservableCollection<ModelGender> Genders { get; set; }
        private string _selectedGender;
        public string SelectedGender
        {
            get { return _selectedGender; }
            set
            {
                _selectedGender = value;
                OnPropertyChanged("SelectedGender");
            }
        }

        //TextBox ФИО
        private string _secondname;
        private string _firstname;
        private string _middlename;

        public string Secondname
        {
            get { return _secondname; }
            set
            {
                _secondname = value;
                OnPropertyChanged("Secondname");
            }
        }
        public string Firstname
        {
            get { return _firstname; }
            set
            {
                _firstname = value;
                OnPropertyChanged("Firstname");
            }
        }
        public string Middlename
        {
            get { return _middlename; }
            set
            {
                _middlename = value;
                OnPropertyChanged("Middlename");
            }
        }

        //DatePicker ДатаРождения
        private DateTime _birthDate;
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                _birthDate = value;
                OnPropertyChanged("BirthDate");
            }
        }

        //IdUser
        public int iduser { get; set; }

        //Button Обновить
        private RelayCommand renameCmd;
        public RelayCommand RenameCmd
        {
            get
            {
                return renameCmd ?? (
                renameCmd = new RelayCommand(obj =>
                {
                    //Проверям заполненны ли все поля
                    if (!string.IsNullOrWhiteSpace(Secondname) && !string.IsNullOrWhiteSpace(Firstname) && !string.IsNullOrWhiteSpace(Middlename) && !string.IsNullOrWhiteSpace(SelectedGender) && SelectedDivision != null)
                    {
                        DBWorker dw = new DBWorker();
                        dw.UpdateUser(this.iduser, Secondname, Firstname, Middlename, SelectedGender, BirthDate, SelectedDivision);
                        MessageBox.Show("Данные Обновленны!", "Выполненно", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Данные заполненны не верно!", "Ой!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }));
            }
        }

        //Button Отменить (Закрывает окно)
        private RelayCommand closeCmd;
        public RelayCommand CloseCmd
        {
            get
            {
                return closeCmd ?? (
                closeCmd = new RelayCommand(obj =>
                {
                    CloseCommandFunction();
                }));
            }
        }
        public Action CloseAction { get; set; }
        private void CloseCommandFunction()
        {
            CloseAction();
        }

        public UpdateUserVM(int id)
        {
            DBWorker dw = new DBWorker();
            ModelUser user = dw.GetUsers().Where(d => d.iduser == id).FirstOrDefault();
            Division = new ObservableCollection<ModelDivision>(dw.GetDivisions());
            Genders = new ObservableCollection<ModelGender>(ModelGender.GetGenders());

            iduser = id;
            Firstname = user.firstname;
            Secondname = user.secondname;
            Middlename = user.middlename;
            BirthDate = DateTime.Parse(user.datebirth);
            SelectedGender = user.gender;
            SelectedDivision = dw.GetDivisions().Where(d => d.namedivision == user.division).Select(p => p.iddivision).FirstOrDefault();
        }

        //PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
