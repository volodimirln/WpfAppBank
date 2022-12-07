using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();

            LoginElem.Visibility = Visibility.Visible;
            RegElem.Visibility = Visibility.Hidden;
            AboutElem.Visibility = Visibility.Hidden;
            SettingElem.Visibility = Visibility.Hidden;
            LodBut.Background = new SolidColorBrush(Color.FromRgb(241, 136, 77));

        }

        private void OpenInfo(object sender, RoutedEventArgs e)
        {
            LoginElem.Visibility = Visibility.Hidden;
            RegElem.Visibility = Visibility.Hidden;
            AboutElem.Visibility = Visibility.Visible;
            SettingElem.Visibility = Visibility.Hidden;

            AboutBut.Background = new SolidColorBrush(Color.FromRgb(241, 136, 77));
            LodBut.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            RegBut.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            SettingBut.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
        }

        private void OpenSetting(object sender, RoutedEventArgs e)
        {
            LoginElem.Visibility = Visibility.Hidden;
            RegElem.Visibility = Visibility.Hidden;
            AboutElem.Visibility = Visibility.Hidden;
            SettingElem.Visibility = Visibility.Visible;
            AboutBut.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            LodBut.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            RegBut.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            SettingBut.Background = new SolidColorBrush(Color.FromRgb(241, 136, 77));
        }

        private void OpenRegistration(object sender, RoutedEventArgs e)
        {
            LoginElem.Visibility = Visibility.Hidden;
            RegElem.Visibility = Visibility.Visible;
            AboutElem.Visibility = Visibility.Hidden;
            SettingElem.Visibility = Visibility.Hidden;
            AboutBut.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            LodBut.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            RegBut.Background = new SolidColorBrush(Color.FromRgb(241, 136, 77));
            SettingBut.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
        }

        private void OpenLogin(object sender, RoutedEventArgs e)
        {
            LoginElem.Visibility = Visibility.Visible;
            RegElem.Visibility = Visibility.Hidden;
            AboutElem.Visibility = Visibility.Hidden;
            SettingElem.Visibility = Visibility.Hidden;
            AboutBut.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            LodBut.Background = new SolidColorBrush(Color.FromRgb(241, 136, 77));
            RegBut.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            SettingBut.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
        }

        private void ClickLogo(object sender, RoutedEventArgs e)
        {
            AboutBut.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            LodBut.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            RegBut.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            SettingBut.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
        }
    }
}
