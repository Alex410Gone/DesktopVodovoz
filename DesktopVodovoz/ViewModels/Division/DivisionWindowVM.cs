using DesktopVodovoz.Command;
using DesktopVodovoz.Models;
using DesktopVodovoz.Views;
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
    class DivisionWindowVM : INotifyPropertyChanged
    {
        DBWorker dw = new DBWorker();

        //Подразделение
        private ObservableCollection<ModelDivision> _divisionData;
        public ObservableCollection<ModelDivision> DivisionData
        {
            get { return _divisionData; }
            set
            {
                _divisionData = value;
                OnPropertyChanged("DivisionData");
            }
        }

        public ModelDivision SDivision { get; set; }

        //Update Button
        private RelayCommand updateDivisionCmd;
        public RelayCommand UpdateDivisionCmd
        {
            get
            {
                return updateDivisionCmd ?? (
                updateDivisionCmd = new RelayCommand(obj =>
                {
                    DivisionData = new ObservableCollection<ModelDivision>(dw.GetDivisions());
                }));
            }
        }

        //AddDivision Button
        private RelayCommand addDivisionCmd;
        public RelayCommand AddDivisionCmd
        {
            get
            {
                return addDivisionCmd ?? (
                addDivisionCmd = new RelayCommand(obj =>
                {
                    AddDivision addDivision = new AddDivision();
                    addDivision.ShowDialog();
                }));
            }
        }

        //RenameDivision Button
        private RelayCommand renameDivisionCmd;
        public RelayCommand RenameDivisionCmd
        {
            get
            {
                return renameDivisionCmd ?? (
                renameDivisionCmd = new RelayCommand(obj =>
                {
                    if (SDivision != null)
                    {
                        RenameDivision renameDivision = new RenameDivision(SDivision.iddivision);
                        renameDivision.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Подразделение не выбрано!", "Ой!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }));
            }
        }

        //VM
        public DivisionWindowVM()
        {
            DivisionData = new ObservableCollection<ModelDivision>(dw.GetDivisions());
        }

        //PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}

