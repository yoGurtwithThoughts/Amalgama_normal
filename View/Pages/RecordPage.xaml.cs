using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Amalgama.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для RecordPage.xaml
    /// </summary>
    public partial class RecordPage : Page
    {
        public RecordPage()
        {
            InitializeComponent();
        }



        private void Imageclosed_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void AgeAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RecCons_Click(object sender, RoutedEventArgs e)
        {
            RecCons.Background = new SolidColorBrush(Color.FromRgb(135, 0, 0)); 
            Seance.Background = new SolidColorBrush(Colors.Transparent);
            RecCons.Foreground = new SolidColorBrush(Colors.White);
            Seance.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void Seance_Click(object sender, RoutedEventArgs e)
        {
            
            Seance.Background = new SolidColorBrush(Color.FromRgb(95, 0, 0)); 
            RecCons.Background = new SolidColorBrush(Colors.Transparent);
            RecCons.Foreground = new SolidColorBrush(Colors.Black);
            Seance.Foreground = new SolidColorBrush(Colors.White);
        }
        }
    }
    

