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
using System.Windows.Threading;

namespace Amalgama.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для Pirsing.xaml
    /// </summary>
    public partial class Pirsing : Page
    {
        private DispatcherTimer _textTimer1;
        private DispatcherTimer _textTimer2;

        private int _currentIndex1;
        private int _currentIndex2;

        private string[] _paragraphs1 = new string[]
       {
            "\tПирсинг – это способ механической модификация тела человека, " +
           "процесс которого состоит непосредственно из " +
           "самого прокола и вставки украшения в это место."
       };
        private string[] _paragraphs2 = new string[]
       {
            "\tЗа два дня до пирсинга нужно исключить алкоголь (алкоголь в крови может привести к сильному кровотечению)." +
           "\r\nНе принимайте никаких лекарств, ухудшающих свертываемость крови (Аспирин, Ибупрофен, Напроксен, Витамин Е и т.д.)" +
           "\r\nПеред визитом за 1-2 часа нужно поесть, чтобы уровень сахара в крови был стабильный и не было головокружения." +
           "\r\nНе будет лишним хорошо отдохнуть перед пирсингом, выспаться, настроить себя на позитивный лад." +
           " От настроя и самочувствия в том числе зависит насколько легко пройдет процедура." +
           "\r\nЗаранее подумайте о том, что вы наденете, если вам предстоит раздеваться; одевайтесь удобно и практично. " +
           "Не надевайте одежду и аксессуары, которые будут тереться об украшение."
       };
        private int _currentParagraphIndex1;
        private int _currentParagraphIndex2;

        public Pirsing()
        {
            InitializeComponent();
        }

        private void Closer_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            _textTimer1 = new DispatcherTimer();
            _textTimer1.Interval = TimeSpan.FromMilliseconds(20);
            _textTimer1.Tick += TextTimer1_Tick;

            _textTimer2 = new DispatcherTimer();
            _textTimer2.Interval = TimeSpan.FromMilliseconds(20);
            _textTimer2.Tick += TextTimer2_Tick;

            _textTimer1.Start();
        }
        private void TextTimer1_Tick(object sender, EventArgs e)
        {
            if (_currentParagraphIndex1 < _paragraphs1.Length)
            {
                string currentParagraph = _paragraphs1[_currentParagraphIndex1];

                if (_currentIndex1 < currentParagraph.Length)
                {
                    TxtWrite.Text += currentParagraph[_currentIndex1];
                    _currentIndex1++;
                }
                else
                {
                    _currentIndex1 = 0;
                    _currentParagraphIndex1++;
                }
            }
            else
            {
                _textTimer1.Stop();
                _textTimer2.Start();
            }
        }
    

    private void TextTimer2_Tick(object sender, EventArgs e)
    {
        if (_currentParagraphIndex2 < _paragraphs2.Length)
        {
            string currentParagraph = _paragraphs2[_currentParagraphIndex2];

            if (_currentIndex2 < currentParagraph.Length)
            {
                TxtWrite1.Text += currentParagraph[_currentIndex2];
                _currentIndex2++;
            }
            else
            {

                _currentIndex2 = 0;
                _currentParagraphIndex2++;
            }
        }
        else
        {
            _textTimer2.Stop();

        }
    }

}
}

