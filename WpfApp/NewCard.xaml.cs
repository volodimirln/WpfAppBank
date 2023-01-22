using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography;
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
using System.Xml.Linq;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для NewCard.xaml
    /// </summary>
    public partial class NewCard : Window
    {
        string userid;

        string text;

        public NewCard(string id)
        {
            InitializeComponent();
            userid = id;

            string databaseName = "mn.db";
            SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM 'cards' WHERE clientid = '" + userid + "';", connection);
            SQLiteDataReader reader = command.ExecuteReader();
            foreach (DbDataRecord record in reader)
            {
                text += record["number"].ToString() + "\r\n";
               text += new string('\u2500', 5) + new string('\u2500', 60) + "\r\n" ;
            }
            
            TextResult.Content = text;
        }

        

        private void NewCardBTN_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();

            int lastNumber = rnd.Next(0, 10);

            string number = "2098 700 0001 234" + lastNumber.ToString();
            string databaseName = "mn.db";
            SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();
            SQLiteCommand command = new SQLiteCommand("INSERT INTO 'cards' ('clientid', 'number', 'systempay') VALUES ('" + userid + "', '" + number + "', 'MIR');", connection);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Вы успешно прошли регистрацию!");
        }
    }
}
