using BankApp.Windows;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
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
using System.Xml.Linq;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainDashBoard.xaml
    /// </summary>
    public partial class MainDashBoard : UserControl
    {
        public string name { get; set; }
        public string namecoomp { get; set; }
        public string inn { get; set; }
        public string ogrn { get; set; }
        public string raschet { get; set; }
        public string balance { get; set; }
        public string id { get; set; }
        public MainDashBoard()
        {
            InitializeComponent();
            this.DataContext = this;
            
        }
        private void btnRubPayments(object sender, RoutedEventArgs e)
        {
            PaymentWindow paymentWindow = new PaymentWindow(id, "Рублевый платеж");
            Balance();
            paymentWindow.Show();
        }

        private void btnSWIFTPayments(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("В Вашем регионе SWIFT-переводы недоступны");
        }

        private void btnBudPayments(object sender, RoutedEventArgs e)
        {
            PaymentWindow paymentWindow = new PaymentWindow(id, "Бюджетный платеж");
            Balance();
            paymentWindow.Show();
        }

        private void btnDonationPayments(object sender, RoutedEventArgs e)
        {
            PaymentWindow paymentWindow = new PaymentWindow(id, "Пожертвование платеж");
            Balance();
            paymentWindow.Show();
        }

        private void BtnReplanAmount(object sender, RoutedEventArgs e)
        {
            RefillWindow refillWindow = new RefillWindow(id);
            Balance();
            refillWindow.Show();
        }
        public void Balance()
        {
             string SQLRequest = "SELECT * FROM 'refill' WHERE iduser = '" + id + "';";
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
    AccountBalance.Content = "Баланс: "+sum+ "₽";
        }

        

        private void Balance_Loaded(object sender, RoutedEventArgs e)
        {
            Balance();
        }
    }
}
