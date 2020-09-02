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
    /// Логика взаимодействия для RenameOrder.xaml
    /// </summary>
    public partial class RenameOrder : Window
    {
        public RenameOrder(int id)
        {
            InitializeComponent();

            //Инициализируем ViewModel
            UpdateOrderVM vm = new UpdateOrderVM(id);
            DataContext = vm;

            //Закрытие окна
            vm.CloseAction = new Action(() => this.Close());
        }
    }
}
