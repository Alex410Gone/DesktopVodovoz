using DesktopVodovoz.Command;
using DesktopVodovoz.Models;
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
    class UpdateDivisionVM : INotifyPropertyChanged
    {
        DBWorker dw = new DBWorker();

        //TextBox Наименование
        private string _namedivision;
        public string NameDivision
        {
            get { return _namedivision; }
            set
            {
                _namedivision = value;
                OnPropertyChanged("NameDivision");
            }
        }

        public int iddivision { get; set; }

        //Combobox Руководитель
        public ObservableCollection<ModelUser> Leader { get; set; }
        private int? sLeader;
        public int? SelectedLeader
        {
            get { return sLeader; }
            set
            {
                sLeader = value;
                OnPropertyChanged("SDivision");
            }
        }

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
                    if (!string.IsNullOrWhiteSpace(NameDivision) && SelectedLeader != null)
                    {
                        dw.UpdateDivision(this.iddivision, NameDivision, SelectedLeader);
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

        public UpdateDivisionVM(int id)
        {
            Leader = new ObservableCollection<ModelUser>(dw.GetUsers());
            ModelDivision division = dw.GetDivisions().Where(d => d.iddivision == id).FirstOrDefault();

            iddivision = id;
            NameDivision = division.namedivision;
            SelectedLeader = division.iduser;
        }

        //PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
