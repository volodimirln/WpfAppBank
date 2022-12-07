using System;
using System.Collections.Generic;
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
       
        public MainDashBoard()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public string name { get; set; }
        public string namecoomp { get; set; }
        public string inn { get; set; }
        public string ogrn { get; set; }
        public string raschet { get; set; }
        public string balance { get; set; }

    }
}
