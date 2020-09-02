using DesktopVodovoz.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DesktopVodovoz.Views
{
    /// <summary>
    /// Логика взаимодействия для RenameUser.xaml
    /// </summary>
    public partial class RenameUser : Window
    {
        public RenameUser(int id)
        {
            InitializeComponent();

            //Инициализируем ViewModel
            UpdateUserVM vm = new UpdateUserVM(id);
            DataContext = vm;

            //Закрытие окна
            vm.CloseAction = new Action(() => this.Close());
        }
    }
}
