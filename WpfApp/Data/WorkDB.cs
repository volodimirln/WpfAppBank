using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp.Data
{

    class WorkDB : Window
    {
        private string id;
        private string login;
        private string rscs;
        private string password;
        private string names;
        private string namecomp;
        private string inn;
        private string ogrn;
        private string raschet;
        private string balance;
        public string[] arcard;
        string texts;
        private SQLiteDataReader? reader;

        //Подключение к БД
        private void setConnectionDB(string SQLRequest)
        {
            string databaseName = "mn.db";
            SQLiteConnection connection =
            new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(SQLRequest, connection);
            reader = command.ExecuteReader();
            
        }


        //Получение данных
        private void getDateLogin()
        {
            foreach (DbDataRecord record in reader)
            {
                id = record["id"].ToString();
                login = record["login"].ToString();
                password = record["password"].ToString();
            }
        }
        private void getDateDadhboard()
        {
            foreach (DbDataRecord record in reader)
            {
                names = record["name"].ToString();
                namecomp = record["namecomp"].ToString();
                inn = record["inn"].ToString();
                ogrn = record["ogrn"].ToString();
                balance = record["balance"].ToString();
                raschet = record["raschet"].ToString();
            }
        }
        private void setDataCards()
        {
            
            texts = new string('\u2500', 5) + new string('\u2500', 140) + "\r\n";
            foreach (DbDataRecord record in reader)
            {
                texts += record["number"].ToString() + " " + record["systempay"].ToString() + "          Срок - " + record["date"].ToString() + "          CVC - " + record["cvc"].ToString() + "          Пин-код - " + record["pincode"].ToString() + "          " + record["datareg"].ToString() + "\r\n";
                texts += new string('\u2500', 5) + new string('\u2500', 140) + "\r\n";
            }

        }
        private void setDataArrayCards()
        {
            string[] arcard = new string[] { };
            int i = 0;
            foreach (DbDataRecord record in reader)
            {
                i++;
                arcard[i] = record["number"].ToString();
            }
        }


        // Запросы
        public void setAuthtorization(TextBox tb, PasswordBox tbpassword, TextBox tblogin)
        {
            string TBPass = tb.Text;
            string PBPass = tbpassword.Password;
            string SQLRequest = "SELECT * FROM 'users' WHERE login = '" + tblogin.Text + "';";
            setConnectionDB(SQLRequest);
            getDateLogin();
            openDashboard(TBPass, PBPass);
        }
        public void setRegistrtion(TextBox login, TextBox name, TextBox compname, TextBox inn, TextBox ogrn, TextBox kpp, TextBox pswd, PasswordBox pswds)
        {
            setRSC();
            string SQLRequest = "INSERT INTO 'users' ('login', 'name', 'namecomp', 'inn', 'ogrn', 'raschet', 'password', 'kpp', 'balance') VALUES ('" + login.Text + "', '" + name.Text + "', '" + compname.Text + "', '" + inn.Text + "', '" + ogrn.Text + "', '" + rscs + "', '" + pswd.Text + "', '" + kpp.Text + "', 5000);";
            setConnectionDB(SQLRequest);

            login.Text = ""; name.Text = ""; compname.Text = ""; inn.Text = ""; ogrn.Text = ""; kpp.Text = ""; pswd.Text = ""; pswds.Password = "";
        }
        public void getDateForDashboard(string id, string login, string password, MainDashBoard mainDashBoard, Cards cards, Statistics statistics)
        {
            string SQLRequest = "SELECT * FROM 'users' WHERE login = '" + login + "' AND password = '" + password + "' AND id = '" + id + "';";
            setConnectionDB(SQLRequest);
            getDateDadhboard();

            cards.id = id;
            mainDashBoard.balance = "Баланс - " + balance + "₽";
            mainDashBoard.name = "Добро пожаловать, " + names;
            mainDashBoard.namecoomp = namecomp;
            mainDashBoard.inn = "ИНН: " + inn;
            mainDashBoard.ogrn = "ОГРН: " + ogrn;
            mainDashBoard.raschet = "Рас. счет. " + raschet;
            mainDashBoard.id = id;
            statistics.id = id;
        }
        public void addNewCard(string id, Label lbl)
        {
            Random rnd = new Random();
            int lastNumber = rnd.Next(0, 10);
            int cvc = rnd.Next(99, 1000);
            int pincode = rnd.Next(999, 10000);
            int month = rnd.Next(0, 13);

            string number = "2098 700 0001 234" + lastNumber.ToString();
            string SQLRequest = "INSERT INTO 'cards' ('clientid', 'number', 'systempay', 'date', 'cvc', 'pincode', 'datareg') VALUES ('" + id + "', '" + number + "', 'MIR', '" + month + "/30', '" + cvc + "', '" + pincode + "', '" + DateTime.Now.ToString() + "' );";
            setConnectionDB(SQLRequest);
            showCards(id, lbl);
            MessageBox.Show("Новая карта добавленна!");
        }
        public void showCards(string id, Label lbl)
        {
            string SQLRequest = "SELECT * FROM 'cards' WHERE clientid = '" + id + "';";
            setConnectionDB(SQLRequest);
            setDataCards();
            lbl.Content = texts;
        }

        


        //Прочее
        private void openDashboard(string TBPass, string PBPass)
        {
            if (password == TBPass || password == PBPass)
            {
                DashBoard dsh = new DashBoard(id, login, password);
                MessageBox.Show("Авторизация прошла успешно!");
                dsh.ShowDialog();

            }
            else
            {
                MessageBox.Show("Введены некорректные данные!");
            }
        }
        
        private void setRSC()
        {
            Random rsch = new Random();
            int rschfirsnbr = rsch.Next(1, 9);
            int rschordinalnbr = rsch.Next(1000000, 9999999);
            rschfirsnbr.ToString();
            rschordinalnbr.ToString();
            rscs = "40701810" + rschfirsnbr + "00001" + rschordinalnbr;
        }
       public void delCardByID(string idCard, Label lbl, string iduser, string number)
        {
            string SQLRequest = "DELETE FROM 'cards' WHERE number = '" + number + "';";
            //string SQLRequest = "DELETE * FROM 'cards' WHERE id = ;";
            setConnectionDB(SQLRequest);
            showCards(iduser, lbl);
            MessageBox.Show("Вы удалили карту");

        }
    }
}
