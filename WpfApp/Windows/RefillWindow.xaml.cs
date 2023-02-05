using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
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
using WpfApp;

namespace BankApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для RefillWindow.xaml
    /// </summary>
    
    public partial class RefillWindow : Window
    {
        public string idref { get; set; }
        
        public RefillWindow(string id)
        {
            idref = id;
            InitializeComponent();
            Balance();
        }
        
       

        private void RefillBtn(object sender, RoutedEventArgs e)
        {
            string SQLRequest = "INSERT INTO 'refill' ('iduser', 'date', 'sum', 'parDesc', 'countePartyr', 'type') VALUES ('"+ idref +"', '2023', '"+ ReplenAmouunt.Text + "', 'Пополнение счета', '-', 1);";
            string databaseName = "mn.db";
            SQLiteConnection connection =
            new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(SQLRequest, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            MessageBox.Show("Вы пополнили счет!");
            Balance();
            ReplenAmouunt.Text = "";
            MainDashBoard mainDashBoard = new MainDashBoard();
            mainDashBoard.Balance();
        }
        private void Balance()
        {
            string SQLRequest = "SELECT * FROM 'refill' WHERE iduser = '" + idref + "';";
            string databaseName = "mn.db";
            SQLiteConnection connection =
            new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(SQLRequest, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            int sum = 0;
            foreach (DbDataRecord record in reader)
            {
                if (record["type"].ToString() == "1")
                {
                    sum += int.Parse(record["sum"].ToString());
                }
                if (record["type"].ToString() == "0")
                {
                    sum -= int.Parse(record["sum"].ToString());
                }
            }
            BalanceLbl.Content = "Баланс " + sum.ToString()+ "₽";
        }
    }
}
