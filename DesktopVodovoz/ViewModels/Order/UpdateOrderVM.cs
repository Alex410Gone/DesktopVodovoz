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
    class UpdateOrderVM : INotifyPropertyChanged
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

        public int idproduct { get; set; }

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
                    if (!string.IsNullOrWhiteSpace(NameProduct) && SelectedUser != null)
                    {
                        dw.UpdateOrder(this.idproduct, NameProduct, SelectedUser);
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

        public UpdateOrderVM(int id)
        {
            ModelOrder order = dw.GetOrders().Where(o => o.idorder == id).FirstOrDefault();
            Users = new ObservableCollection<ModelUser>(dw.GetUsers());

            idproduct = id;
            NameProduct = order.nameproduct;
            SelectedUser = order.iduser;
            
        }

        //PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
