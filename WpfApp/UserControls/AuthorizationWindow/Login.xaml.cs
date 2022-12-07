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
            string id = "";
            string login = "";
            string password = "";

            string databaseName = "mn.db";
            SQLiteConnection connection =
            new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM 'users' WHERE login = '"+ TBxLogin.Text + "';", connection);
            SQLiteDataReader reader = command.ExecuteReader();
            foreach (DbDataRecord record in reader)
            {
                id = record["id"].ToString();
                login = record["login"].ToString();
                password = record["password"].ToString();
            }
           if(password == TBxPassword.Text)
            {
                DashBoard dsh = new DashBoard( id,  login,  password);
                MessageBox.Show("Авторизация прошла успешно!");
                dsh.ShowDialog();
            }
            else
            {
                MessageBox.Show("Введены некорректные данные!");
            }
        }
    }
}
