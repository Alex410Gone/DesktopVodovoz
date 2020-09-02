using DesktopVodovoz.Command;
using DesktopVodovoz.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace DesktopVodovoz.ViewModels
{
    public class AddUserVM : INotifyPropertyChanged
    {
        DBWorker dw = new DBWorker();

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
        private DateTime _birthDate = DateTime.Now.Date;
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                _birthDate = value;
                OnPropertyChanged("BirthDate");
            }
        }

        //Button Добавить
        private RelayCommand addCmd;
        public RelayCommand AddCmd
        {
            get
            {
                return addCmd ?? (
                addCmd = new RelayCommand(obj =>
                {
                    //Проверям заполненны ли все поля
                    if (!string.IsNullOrWhiteSpace(Secondname) && !string.IsNullOrWhiteSpace(Firstname) && !string.IsNullOrWhiteSpace(Middlename) && 
                    !string.IsNullOrWhiteSpace(SelectedGender) && BirthDate != null && SelectedDivision != null)
                    {
                        dw.AddUser(Secondname, Firstname, Middlename, SelectedGender, BirthDate, SelectedDivision);
                        MessageBox.Show("Данные добавленны!", "Выполненно", MessageBoxButton.OK, MessageBoxImage.Information);
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

        //VM
        public AddUserVM()
        {
            Division = new ObservableCollection<ModelDivision>(dw.GetDivisions());
            Genders = new ObservableCollection<ModelGender>(ModelGender.GetGenders());
        }

        //PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
