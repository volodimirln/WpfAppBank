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

namespace WpfApp
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();

            TBxINN.MaxLength= 12;
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
            Random rsch = new Random();
            int rschfirsnbr = rsch.Next(1, 9);
            int rschordinalnbr = rsch.Next(1000000, 9999999);

            rschfirsnbr.ToString();
            rschordinalnbr.ToString();

            string login = TBxLogin.Text;
            string name = TBxName.Text;
            string compname = TBxCompName.Text;
            string inn = TBxINN.Text;
            string ogrn = TBxOGRN.Text;
            string rsc = "40701810"+ rschfirsnbr + "00001" + rschordinalnbr;
            string kpp = TBxKPP.Text;
            string pswd = TBxPassword.Text;

            string databaseName = "mn.db";
            SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();
            SQLiteCommand command = new SQLiteCommand("INSERT INTO 'users' ('login', 'name', 'namecomp', 'inn', 'ogrn', 'raschet', 'password', 'kpp', 'balance') VALUES ('"+ login + "', '"+ name + "', '"+ compname + "', '"+ inn + "', '"+ ogrn + "', '"+ rsc + "', '"+ pswd + "', '" + kpp + "', 5000);", connection);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Вы успешно прошли регистрацию!");
        }
    }
}
