using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DesktopVodovoz.Models;
using DesktopVodovoz.Views;
using MySql.Data.MySqlClient;
using MySql.Data.EntityFramework;
using DesktopVodovoz.ViewModels;

namespace DesktopVodovoz
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Инициализация WM
            UserWindowVM uvm = new UserWindowVM();
            User.DataContext = uvm;

            DivisionWindowVM dvm = new DivisionWindowVM();
            Division.DataContext = dvm;

            OrderWindowVM ovm = new OrderWindowVM();
            Order.DataContext = ovm;
        }
    }
}
