using DesktopVodovoz.Command;
using DesktopVodovoz.Models;
using DesktopVodovoz.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace DesktopVodovoz.ViewModels
{
    public class UserWindowVM : INotifyPropertyChanged
    {
        DBWorker dw = new DBWorker();

        //Пользователи
        private ObservableCollection<ModelUser> _userData;
        public ObservableCollection<ModelUser> UsersData
        {
            get { return _userData; }
            set
            {
                _userData = value;
                OnPropertyChanged("UsersData");
            }
        }

        //Selected User
        public ModelUser SUser { get; set; }

        //Update Button
        private RelayCommand updateUserCmd;
        public RelayCommand UpdateUserCmd
        {
            get
            {
                return updateUserCmd ?? (
                updateUserCmd = new RelayCommand(obj =>
                {
                    UsersData = new ObservableCollection<ModelUser>(dw.GetUsers());
                }));
            }
        }

        //AddUser Button
        private RelayCommand addUserCmd;
        public RelayCommand AddUserCmd
        {
            get
            {
                return addUserCmd ?? (
                addUserCmd = new RelayCommand(obj =>
                {
                    AddUser addUser = new AddUser();
                    addUser.ShowDialog();
                    dw.GetUsers();
                }));
            }
        }

        //RenameUser Button
        private RelayCommand renameUserCmd;
        public RelayCommand RenameUserCmd
        {
            get
            {
                return renameUserCmd ?? (
                renameUserCmd = new RelayCommand(obj =>
                {
                    if (SUser != null)
                    {
                        RenameUser renameUser = new RenameUser(SUser.iduser);
                        renameUser.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Пользователь не выбран!", "Ой!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                }));
            }
        }

        //VM
        public UserWindowVM()
        {
            UsersData = new ObservableCollection<ModelUser>(dw.GetUsers());
        }

        //PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
