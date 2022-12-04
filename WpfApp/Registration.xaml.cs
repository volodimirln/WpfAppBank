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

namespace WpfApp
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        private void Regisr_Click(object sender, RoutedEventArgs e)
        {
            string login = TBxLogin.Text;
            string name = TBxName.Text;
            string compname = TBxCompName.Text;
            string inn = TBxINN.Text;
            string ogrn = TBxOGRN.Text;
            string rsc = TBxRasChet.Text;
            string pswd = TBxPassword.Text;

            string databaseName = "mn.db";
            SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();
            SQLiteCommand command = new SQLiteCommand("INSERT INTO 'users' ('login', 'name', 'namecomp', 'inn', 'ogrn', 'raschet', 'password') VALUES ('"+ login + "', '"+ name + "', '"+ compname + "', '"+ inn + "', '"+ ogrn + "', '"+ rsc + "', '"+ pswd + "');", connection);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Вы успешно прошли регистрацию!");
        }
    }
}
