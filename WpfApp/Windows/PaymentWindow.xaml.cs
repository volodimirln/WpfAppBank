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
    /// Логика взаимодействия для PaymentWindow.xaml
    /// </summary>
    public partial class PaymentWindow : Window
    {
        public string idref { get; set; }
        public string payTyperef { set; get; }
        public int SumRef { set; get; }
        public PaymentWindow(string id, string payType)
        {
            InitializeComponent();

            idref = id;
            payTyperef = payType;
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
            SumRef = sum;

            SQLiteCommand command1 = new SQLiteCommand("SELECT * FROM 'cards';", connection);

            SQLiteDataReader reader1 = command1.ExecuteReader();

            string[] arcard = new string[100];
            int i = 0;
            foreach (DbDataRecord record in reader1)
            {
                if (id == record["clientid"].ToString())
                {
                    for (int j = 0; j < arcard.Length; j++)
                    {
                        arcard[i] = record["number"].ToString();
                    }
                    i++;
                }

            }
            
            var result = arcard.Where(x => x != null).ToArray();
            ComboBox combo;
            combo = new ComboBox();
            result.ToList().ForEach(item => DelCard.Items.Add(item));




        }
        public void payMent()
        {
            if(SumRef > int.Parse(SumPay.Text)) { 
            string SQLRequest = "INSERT INTO 'refill' ('iduser', 'date', 'sum', 'parDesc', 'countePartyr', 'type', 'payType', 'cardnum') VALUES ('" + idref + "', '2023', '" + SumPay.Text + "', '"+ NamePay.Text +"', '"+ ContrPay.Text + "', 0, '"+ payTyperef + "', '"+ DelCard.SelectedValue.ToString() + "');";
            string databaseName = "mn.db";
            SQLiteConnection connection =
            new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(SQLRequest, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            MessageBox.Show("Вы совершили "+ payTyperef + "!");
            MainDashBoard mainDashBoard = new MainDashBoard();
            mainDashBoard.Balance();
            }
            else
            {
                MessageBox.Show("Недостаточно средств. Пополните счет!");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            payMent();
        }
       
    }
}
