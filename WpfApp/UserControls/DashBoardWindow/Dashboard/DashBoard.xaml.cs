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
using WpfApp.Data;

namespace WpfApp
{
    public partial class DashBoard : Window
    {
        string useid;
        
        public DashBoard(string id, string login, string password)
        {

            InitializeComponent();

            WorkDB dB = new WorkDB();
            dB.getDateForDashboard(id, login, password, MainDashBoard, Cards, Statistics);

            MainDashBoard.Visibility = Visibility.Visible;
            Cards.Visibility = Visibility.Hidden;
            Statistics.Visibility = Visibility.Hidden;
            Premium.Visibility = Visibility.Hidden;
            Setting.Visibility = Visibility.Hidden;




        }
        
        private void openMain(object sender, ContextMenuEventArgs e)
        {
            MainDashBoard.Visibility = Visibility.Visible;
            Cards.Visibility = Visibility.Hidden;
            Statistics.Visibility = Visibility.Hidden;
            Premium.Visibility = Visibility.Hidden;
            Setting.Visibility = Visibility.Hidden;
            Setting.Visibility = Visibility.Hidden;
        }

        private void openCards(object sender, RoutedEventArgs e)
        {
            MainDashBoard.Visibility = Visibility.Hidden;
            Cards.Visibility = Visibility.Visible;
            Statistics.Visibility = Visibility.Hidden;
            Premium.Visibility = Visibility.Hidden;
            Setting.Visibility = Visibility.Hidden;

        }

        private void openStatistics(object sender, RoutedEventArgs e)
        {
            MainDashBoard.Visibility = Visibility.Hidden;
            Cards.Visibility = Visibility.Hidden;
            Statistics.Visibility = Visibility.Visible;
            Premium.Visibility = Visibility.Hidden;
            Setting.Visibility = Visibility.Hidden;
        }
        private void openPrimium(object sender, RoutedEventArgs e)
        {
            MainDashBoard.Visibility = Visibility.Hidden;
            Cards.Visibility = Visibility.Hidden;
            Statistics.Visibility = Visibility.Hidden;
            Premium.Visibility = Visibility.Visible;
            Setting.Visibility = Visibility.Hidden;
        }

        private void openMain(object sender, RoutedEventArgs e)
        {
            MainDashBoard.Visibility = Visibility.Visible;
            Cards.Visibility = Visibility.Hidden;
            Statistics.Visibility = Visibility.Hidden;
            Premium.Visibility = Visibility.Hidden;
            Setting.Visibility = Visibility.Hidden;
        }

        private void openSettings(object sender, RoutedEventArgs e)
        {
            MainDashBoard.Visibility = Visibility.Hidden;
            Cards.Visibility = Visibility.Hidden;
            Statistics.Visibility = Visibility.Hidden;
            Premium.Visibility = Visibility.Hidden;
            Setting.Visibility = Visibility.Visible;
        }
    }
}
