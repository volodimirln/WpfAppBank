using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using WpfApp.WorkDoc;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для Statistics.xaml
    /// </summary>
    public partial class Statistics : UserControl
    {


        public Statistics()
        {
            InitializeComponent();
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
    
    }
}
