using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopVodovoz.Models
{
    public class ModelUser : INotifyPropertyChanged
    {
        private int _iduser;
        private string _secondname;
        private string _firstname;
        private string _middlename;
        private string _datebirth;
        private string _gender;
        private string _division;
        private string _fullname;

        public int iduser
        {
            get { return _iduser;}
            set { _iduser = value; OnPropertyChanged("iduser"); }
        }
        public string secondname
        {
            get { return _secondname; }
            set { _secondname = value; OnPropertyChanged("secondname"); }
        }
        public string firstname
        {
            get { return _firstname; }
            set { _firstname = value; OnPropertyChanged("firstname"); }
        }
        public string middlename
        {
            get { return _middlename; }
            set { _middlename = value; OnPropertyChanged("middlename"); }
        }
        public string datebirth
        {
            get { return _datebirth; }
            set { _datebirth = value; OnPropertyChanged("datebirth"); }
        }
        public string gender
        {
            get { return _gender; }
            set { _gender = value; OnPropertyChanged("gender"); }
        }
        public string division
        {
            get { return _division; }
            set { _division = value; OnPropertyChanged("division"); }
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

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
