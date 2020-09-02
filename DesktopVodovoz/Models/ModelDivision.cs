using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace DesktopVodovoz.Models
{
   public class ModelDivision : INotifyPropertyChanged
    {
        private int _iddivison;
        private string _namedivison;
        private int? _iduser;
        private string _fullname;

        public int iddivision
        {
            get { return _iddivison; }
            set
            {
                _iddivison = value;
                OnPropertyChanged("iddivision");
            }
        }
        public string namedivision
        {
            get { return _namedivison; }
            set
            {
                _namedivison = value;
                OnPropertyChanged("namedivision");
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
