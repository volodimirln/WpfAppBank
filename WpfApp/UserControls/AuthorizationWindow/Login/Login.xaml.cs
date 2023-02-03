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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;
using System.IO;
using System.Data.Common;
using WpfApp.Data;

namespace WpfApp
{

    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }
        public void Enter(object sender, RoutedEventArgs e)
        {
            WorkDB logindb = new WorkDB();
            logindb.setAuthtorization(TBxPassword, psb, TBxLogin);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            psb.Visibility = Visibility.Hidden;
            TBxPassword.Text = psb.Password;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            psb.Visibility = Visibility.Visible;
            psb.Password = TBxPassword.Text;
        }
    }
}
