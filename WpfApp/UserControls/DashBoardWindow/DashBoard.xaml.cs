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
using System.Data.SQLite;
using System.IO;
using System.Data.Common;
using System.Xml.Linq;

namespace WpfApp
{
    public partial class DashBoard : Window
    {
        
        public DashBoard(string id, string login, string password)
        {

            InitializeComponent();
           
            string names = "";
            string namecomp = "";
            string inn = "" ;
            string ogrn = "";
            string raschet = "";
            string balance = "";

            string databaseName = "mn.db";
            
            SQLiteConnection connection =
            new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM 'users' WHERE login = '" + login + "' AND password = '" + password + "' AND id = '" + id + "';", connection);
            SQLiteDataReader reader = command.ExecuteReader();
            foreach (DbDataRecord record in reader)
            {
                names = record["name"].ToString();
                namecomp = record["namecomp"].ToString();
                inn = record["inn"].ToString();
                ogrn = record["ogrn"].ToString();
                balance = record["balance"].ToString();
                raschet = record["raschet"].ToString();
            }
            MainDashBoard.balance = "Баланс - " + balance + "₽";
            MainDashBoard.name = "Добро пожаловать, " + names;
            MainDashBoard.namecoomp = namecomp;
            MainDashBoard.inn = "ИНН: " + inn;
            MainDashBoard.ogrn = "ОГРН: " + ogrn;
            MainDashBoard.raschet = "Рас. счет. " + raschet;

            MainDashBoard.Visibility = Visibility.Visible;
            Cards.Visibility = Visibility.Hidden;
            Statistics.Visibility = Visibility.Hidden;
            Premium.Visibility = Visibility.Hidden;
        }
        
        private void openMain(object sender, ContextMenuEventArgs e)
        {
            MainDashBoard.Visibility = Visibility.Visible;
            Cards.Visibility = Visibility.Hidden;
            Statistics.Visibility = Visibility.Hidden;
            Premium.Visibility = Visibility.Hidden;
        }

        private void openCards(object sender, RoutedEventArgs e)
        {
            MainDashBoard.Visibility = Visibility.Hidden;
            Cards.Visibility = Visibility.Visible;
            Statistics.Visibility = Visibility.Hidden;
            Premium.Visibility = Visibility.Hidden;
        }

        private void openStatistics(object sender, RoutedEventArgs e)
        {
            MainDashBoard.Visibility = Visibility.Hidden;
            Cards.Visibility = Visibility.Hidden;
            Statistics.Visibility = Visibility.Visible;
            Premium.Visibility = Visibility.Hidden;
        }
        private void openPrimium(object sender, RoutedEventArgs e)
        {
            MainDashBoard.Visibility = Visibility.Hidden;
            Cards.Visibility = Visibility.Hidden;
            Statistics.Visibility = Visibility.Hidden;
            Premium.Visibility = Visibility.Visible;
        }

        private void openMain(object sender, RoutedEventArgs e)
        {
            MainDashBoard.Visibility = Visibility.Visible;
            Cards.Visibility = Visibility.Hidden;
            Statistics.Visibility = Visibility.Hidden;
            Premium.Visibility = Visibility.Hidden;
        }
    }
}
