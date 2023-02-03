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
using WpfApp.Data;
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
            WorkDB dB = new WorkDB();
            dB.addNewCard(id, CardsLBL);
        }
        /*private void showCards() {  
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
        }*/

        private void SPCards_Loaded(object sender, RoutedEventArgs e)
        {
            WorkDB dB = new WorkDB();

            dB.showCards(id, CardsLBL);
        }
    }
}
