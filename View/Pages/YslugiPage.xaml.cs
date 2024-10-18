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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Amalgama.Core.Navigation;

namespace Amalgama.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для YslugiPage.xaml
    /// </summary>
    public partial class YslugiPage : Page
    {
        public YslugiPage()
        {
            InitializeComponent();
            string multiLineText = "Наши татуировщики наносят не просто картинку, \n" +
                                   "а создают настоящее произведение искусства, \n" +
                                   "которое выражает внутреннее «Я» клиента.\n";

            TxtB.Text = multiLineText;
            string multiLineText1 = "Если тату утратила свою актуальность, была , \n" +
                                  "нанесена непрофессиональным татуировщиком,  \n" +
                                  "представляет собой партак, то изменить \n"+
                                  "ситуацию помогут наши мастера. \n";

            TxtB1.Text = multiLineText1;
            string multiLineText2 = "Наши услуги пирсинга - это возможность  \n" +
                                  "украсить свое тело необычными и красивыми  \n" +
                                  "украшениями. Мы предлагаем широкий выбор \n" +
                                  "услуг. \n";

            TxtB2.Text = multiLineText2;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ArrowButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CoreNavigate.NavigatorCore.Navigate(new StartPage()); 
        }

        private void More_Click(object sender, RoutedEventArgs e)
        {

        }

        private void More1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void More2_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
