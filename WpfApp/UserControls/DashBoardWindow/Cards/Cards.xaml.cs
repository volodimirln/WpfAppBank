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
        private void dbv()
        {
            string databaseName = "mn.db";
            SQLiteConnection connection =
            new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM 'cards';", connection);

            SQLiteDataReader reader = command.ExecuteReader();

            string[] arcard = new string[100];
            int i = 0;
            foreach (DbDataRecord record in reader)
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
            // MainLbl.Content = tr;
            var result = arcard.Where(x => x != null).ToArray();
            ComboBox combo;
            combo = new ComboBox();
            result.ToList().ForEach(item => DelCard.Items.Add(item));
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WorkDB dB = new WorkDB();
            dB.addNewCard(id, CardsLBL);

        }
        private void BTNDelCardId_Click(object sender, RoutedEventArgs e)
        {
            WorkDB dB = new WorkDB();
            dB.delCardByID("", CardsLBL, id, DelCard.SelectedValue.ToString());
            
        }
        private void SPCards_Loaded(object sender, RoutedEventArgs e)
        {
            WorkDB dB = new WorkDB();
            dB.showCards(id, CardsLBL);
            dbv();
            
        }
    }
}
