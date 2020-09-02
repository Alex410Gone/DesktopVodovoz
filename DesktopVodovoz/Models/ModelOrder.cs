using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopVodovoz.Models
{
    public class ModelOrder : INotifyPropertyChanged
    {
        private int _idorder;
        private string _nameproduct;
        private int? _iduser;
        private string _fullname;

        public int idorder
        {
            get { return _idorder; }
            set
            {
                _idorder = value;
                OnPropertyChanged("idorder");
            }
        }
        public string nameproduct
        {
            get { return _nameproduct; }
            set
            {
                _nameproduct = value;
                OnPropertyChanged("nameproduct");
            }
        }
        public int? iduser
        {
            get { return _iduser; }
            set
            {
                _iduser = value;
                OnPropertyChanged("iduser");
            }
        }
        public string fullname
        {
            get { return _fullname; }
            set
            {
                _fullname = value;
                OnPropertyChanged("fullname");
            }
        }

        //PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
