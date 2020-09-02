using DesktopVodovoz.Command;
using DesktopVodovoz.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace DesktopVodovoz.ViewModels
{
    class AddOrderVM : INotifyPropertyChanged
    {
        DBWorker dw = new DBWorker();

        //TextBox Наименование 
        private string _nameproduct;
        public string NameProduct
        {
            get { return _nameproduct; }
            set
            {
                _nameproduct = value;
                OnPropertyChanged("NameProduct");
            }
        }

        //Combobox Сотрудник
        public ObservableCollection<ModelUser> Users { get; set; }
        private int? sUser;
        public int? SelectedUser
        {
            get { return sUser; }
            set
            {
                sUser = value;
                OnPropertyChanged("SelectedUser");
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
                    if (!string.IsNullOrWhiteSpace(NameProduct) && SelectedUser != null)
                    {
                        dw.AddOrder(NameProduct, SelectedUser);
                        MessageBox.Show("Заказ добавлен!", "Выполненно", MessageBoxButton.OK, MessageBoxImage.Information);
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

        public AddOrderVM()
        {
            Users = new ObservableCollection<ModelUser>(dw.GetUsers());
        }

        //PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
