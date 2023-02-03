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
using System.Text.RegularExpressions;
using WpfApp.Data;

namespace WpfApp
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();

            TBxINN.MaxLength = 12;
            TBxOGRN.MaxLength = 13;
            TBxKPP.MaxLength = 9;
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        
        private void Regisr_Click(object sender, RoutedEventArgs e)
        {
            int count = TBxINN.SelectionLength;
            if (!String.IsNullOrEmpty(TBxLogin.Text) && !String.IsNullOrEmpty(TBxName.Text) && !String.IsNullOrEmpty(TBxCompName.Text)
                && !String.IsNullOrEmpty(TBxINN.Text) && !String.IsNullOrEmpty(TBxOGRN.Text) && !String.IsNullOrEmpty(TBxKPP.Text))
            {
                WorkDB dB = new WorkDB();
                dB.setRegistrtion(TBxLogin, TBxName, TBxCompName, TBxINN, TBxOGRN, TBxKPP, TBxPassword, psb);
                MessageBox.Show("Регистрация прошла успешно");
            }
            else
            {
                MessageBox.Show("Вы указали не все данные!");
            }
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
