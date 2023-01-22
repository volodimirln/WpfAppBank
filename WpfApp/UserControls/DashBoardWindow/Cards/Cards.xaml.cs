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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для Cards.xaml
    /// </summary>
    public partial class Cards : UserControl
    {
        public string id { get; set; }
        public Cards()
        {
           
            InitializeComponent();
            this.DataContext = this;
            
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int lastNumber = rnd.Next(0, 10);
            int cvc = rnd.Next(99, 1000);
            int pincode = rnd.Next(999, 10000);
            int month = rnd.Next(0, 13);

            string number = "2098 700 0001 234" + lastNumber.ToString();
            string databaseName = "mn.db";
            SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();
            SQLiteCommand command = new SQLiteCommand("INSERT INTO 'cards' ('clientid', 'number', 'systempay', 'date', 'cvc', 'pincode', 'datareg') VALUES ('" + id + "', '" + number + "', 'MIR', '"+ month.ToString() + "/30', '"+ cvc.ToString() + "', '"+ pincode.ToString() + "', '"+ DateTime.Now.ToString() + "' );", connection);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Карта добавлена! При следуещем запуске приложения карта отобраится.");

        }
        private void showCards() {  
           string texts = "";
            string databaseName = "mn.db";
            SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM 'cards' WHERE clientid = '" + id + "';", connection);
            SQLiteDataReader reader = command.ExecuteReader();
            texts = new string('\u2500', 5) + new string('\u2500', 140) + "\r\n";
            foreach (DbDataRecord record in reader)
            {
                texts += record["number"].ToString() + " " +record["systempay"].ToString() + "          Срок - " + record["date"].ToString() + "          CVC - " + record["cvc"].ToString() + "          Пин-код - " + record["pincode"].ToString() + "          " + record["datareg"].ToString() + "\r\n";
                texts += new string('\u2500', 5) + new string('\u2500', 140) + "\r\n";
            }
            CardsLBL.Content = texts;
        }

        private void SPCards_Loaded(object sender, RoutedEventArgs e)
        {
            showCards();
        }
    }
}
