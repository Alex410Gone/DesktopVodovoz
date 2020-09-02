using DesktopVodovoz.Command;
using DesktopVodovoz.Models;
using DesktopVodovoz.Views;
using Renci.SshNet.Messages;
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
    class OrderWindowVM : INotifyPropertyChanged
    {
        DBWorker dw = new DBWorker();

        //Заказы
        private ObservableCollection<ModelOrder> orderData;
        public ObservableCollection<ModelOrder> OrderData
        {
            get { return orderData; }
            set
            {
                orderData = value;
                OnPropertyChanged("OrderData");
            }
        }

        public ModelOrder SelectedOrder { get; set; }

        //Update Button
        private RelayCommand updateOrderCmd;
        public RelayCommand UpdateOrderCmd
        {
            get
            {
                return updateOrderCmd ?? (
                updateOrderCmd = new RelayCommand(obj =>
                {
                    OrderData = new ObservableCollection<ModelOrder>(dw.GetOrders());
                }));
            }
        }

        //AddOrder Button
        private RelayCommand addOrderCmd;
        public RelayCommand AddOrderCmd
        {
            get
            {
                return addOrderCmd ?? (
                addOrderCmd = new RelayCommand(obj =>
                {
                    AddOrder addOrder = new AddOrder();
                    addOrder.ShowDialog();
                }));
            }
        }

        //RenameOrder Button
        private RelayCommand renameOrderCmd;
        public RelayCommand RenameOrderCmd
        {
            get
            {
                return renameOrderCmd ?? (
                renameOrderCmd = new RelayCommand(obj =>
                {
                    if (SelectedOrder != null)
                    {
                        RenameOrder renameOrder = new RenameOrder(SelectedOrder.idorder);
                        renameOrder.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Заказ не выбран!", "Ой!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }));
            }
        }

        //VM
        public OrderWindowVM()
        {
            OrderData = new ObservableCollection<ModelOrder>(dw.GetOrders());
        }

        //PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
