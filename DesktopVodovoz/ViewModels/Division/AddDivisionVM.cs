using DesktopVodovoz.Command;
using DesktopVodovoz.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace DesktopVodovoz.ViewModels
{
    class AddDivisionVM : INotifyPropertyChanged
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
                if (!string.IsNullOrWhiteSpace(NameDivision) && SelectedLeader != null)
                    {
                        dw.AddDivision(NameDivision, SelectedLeader);
                        MessageBox.Show("Подразделение добавленно!", "Выполненно", MessageBoxButton.OK, MessageBoxImage.Information);
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

        public AddDivisionVM()
        {
            Leader = new ObservableCollection<ModelUser>(dw.GetUsers());
        }

        //PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
