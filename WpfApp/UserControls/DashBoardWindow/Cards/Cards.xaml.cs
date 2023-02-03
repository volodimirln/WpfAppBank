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
        private void BTNDelCardId_Click(object sender, RoutedEventArgs e)
        {
            WorkDB dB = new WorkDB();
            dB.delCardByID(TBDelCardId.Text, CardsLBL, id);
            //MessageBox.Show(TBDelCardId.Text);
        }
        private void SPCards_Loaded(object sender, RoutedEventArgs e)
        {
            WorkDB dB = new WorkDB();

            dB.showCards(id, CardsLBL);
        }
    }
}
