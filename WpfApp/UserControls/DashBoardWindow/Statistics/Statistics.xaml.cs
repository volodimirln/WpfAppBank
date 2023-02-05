using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using WpfApp.WorkDoc;
using System.Data.Common;
using System.Data.SQLite;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для Statistics.xaml
    /// </summary>
    public partial class Statistics : UserControl
    {

        public string id { get; set; }
        //public string Name { get; set; }

        public Statistics()
        {
            InitializeComponent();
        }
        private void Spending()
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
                if (record["type"].ToString() == "0")
                {
                    sum += int.Parse(record["sum"].ToString());
                }
               
            }
            BlnLbl.Content = sum.ToString() + "₽";
           // BalanceLbl.Content = "Баланс" + sum.ToString();
        }
        private void Pfofit()
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

            }
            Plbl.Content = sum.ToString() + "₽";
            // BalanceLbl.Content = "Баланс" + sum.ToString();
        }
        private void IsPayment()
        {
            string SQLRequest = "SELECT * FROM 'refill' WHERE iduser = '" + id + "' ORDER BY id DESC LIMIT 6;";
            string databaseName = "mn.db";
            SQLiteConnection connection =
            new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(SQLRequest, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            string texts = "";
            
            texts = new string('\u2500', 5) + new string('\u2500', 140) + "\r\n";
            int i = 0;
            foreach (DbDataRecord record in reader)
            {
                if (record["type"].ToString() == "0")
                {
                    
                    texts += record["countePartyr"].ToString() + "       " + record["payType"].ToString() + "       " + record["sum"].ToString() + "₽      " + record["date"].ToString() + "       " + record["cardnum"].ToString() + "\r\n";
                    texts += new string('\u2500', 5) + new string('\u2500', 140) + "\r\n";
                    
                    
                }
            }
            IsPayLbl.Content = texts;
        }
        private void IngPayment()
        {
            string SQLRequest = "SELECT * FROM 'refill' WHERE iduser = '" + id + "' ORDER BY id DESC LIMIT 6;";
            string databaseName = "mn.db";
            SQLiteConnection connection =
            new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(SQLRequest, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            string texts = "";

            texts = new string('\u2500', 5) + new string('\u2500', 140) + "\r\n";
            int i = 0;
            foreach (DbDataRecord record in reader)
            {
                if (record["type"].ToString() == "1")
                {

                    texts += "Пополнение счета" + "           " + record["payType"].ToString() + "           " + record["sum"].ToString() + "₽           " + record["date"].ToString() + "          " + record["cardnum"].ToString() + "\r\n";
                    texts += new string('\u2500', 5) + new string('\u2500', 140) + "\r\n";


                }
            }
            IncPayLbl.Content = texts;
        }
        private void NewPdf(object sender, RoutedEventArgs e)
        {
            ClassWorkPDF workDoc = new ClassWorkPDF();
            workDoc.createPDF();
            OpenFile();
            
        }
      
        private void OpenFile()
        {
            Process.Start(new ProcessStartInfo("Report.pdf") { UseShellExecute = true });
        }

        private void StackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            Spending();
            IsPayment();
            Pfofit();
            IngPayment();
        }
    }
}
