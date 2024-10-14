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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static Amalgama.Core.Navigation;

namespace Amalgama.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        private DispatcherTimer _timer;
        private int _contentIndex;
        private List<UIElement> _contentItems;
        private string[] _messages = { "1", "2", "3", "4" };
        private string[] _colorsHex = { "#840000", "#D9D9D9", "#D9D9D9", "#D9D9D9" };

        public StartPage()
        {
            InitializeComponent();
            InitializeTimer();
            CreateCircles();
            InitializeContentItems();
            TextBlock textBlock = new TextBlock();
        }

        private void CreateCircles()
        {
           
                for (int i = 0; i < _colorsHex.Length; i++)
                {
                    
                    Ellipse ellipse = new Ellipse
                    {
                        Width = 50,
                        Height = 50,
                        Fill = (SolidColorBrush)new BrushConverter().ConvertFromString(_colorsHex[i]),
                        Margin = new Thickness(0.5)
                    };
                    CirclesPanel.Children.Add(ellipse);
                }

        }
        private void StartTimer()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(2); 
            _timer.Tick += UpdateText;
            _timer.Start();

        }
        private void UpdateText(object? sender, EventArgs e)
        {
            ContentTxt.Text = _messages[_contentIndex];
            _contentIndex = (_contentIndex + 1) % _messages.Length;
        }


        private void InitializeContentItems()
        {
            Style titleMainStyle = (Style)FindResource("SliderBar");

            _contentItems = new List<UIElement> {
            new TextBlock { TextWrapping = TextWrapping.Wrap,
            Style = titleMainStyle,
            Inlines =
            {
                new Run("Когда стоит делать тату?") { FontWeight = FontWeights.Bold },
                new LineBreak(),
                new Run("\nТатуировщики рекомендуют делать татуировки, а также пирсинг, не в жаркое время года, т. е. осенью, зимой, весной!")
            }
        },
        new TextBlock
        {
            Text = "New content",
            TextWrapping = TextWrapping.Wrap,
            Style = titleMainStyle
        },
            new TextBlock { Text = "New content ", TextWrapping=TextWrapping.Wrap , Style = titleMainStyle  },
            };

        }  

        private void InitializeTimer()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(7.5); 
            _timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _contentIndex = (_contentIndex + 1) % _contentItems.Count;
            Contentstack.Children.Clear();
            Contentstack.Children.Add(_contentItems[_contentIndex]);
            _contentIndex = (_contentIndex + 1) % _contentItems.Count;
        }
       

        private void DraverButton_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _contentIndex = 0;
            Contentstack.Children.Clear();
            Contentstack.Children.Add(_contentItems[_contentIndex]);
            _timer.Start();
            var textBlockFadeInAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = new Duration(TimeSpan.FromSeconds(1))
            };

            var textBlockTranslateAnimation = new DoubleAnimation
            {
                From = -50,
                To = 0,
                Duration = new Duration(TimeSpan.FromSeconds(1))
            };

            Storyboard.SetTarget(textBlockFadeInAnimation, AnimatedBlock);
            Storyboard.SetTargetProperty(textBlockFadeInAnimation, new PropertyPath(TextBlock.OpacityProperty));

            Storyboard.SetTarget(textBlockTranslateAnimation, AnimatedBlock);
            Storyboard.SetTargetProperty(textBlockTranslateAnimation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)"));

            var textBlockStoryboard = new Storyboard();
            textBlockStoryboard.Children.Add(textBlockFadeInAnimation);
            textBlockStoryboard.Children.Add(textBlockTranslateAnimation);

            var textBlockFadeInAnimation1 = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = new Duration(TimeSpan.FromSeconds(1))
            };

            var textBlockTranslateAnimation1 = new DoubleAnimation
            {
                From = -50,
                To = 0,
                Duration = new Duration(TimeSpan.FromSeconds(1))
            };

            Storyboard.SetTarget(textBlockFadeInAnimation1, Contentstack);
            Storyboard.SetTargetProperty(textBlockFadeInAnimation1, new PropertyPath(TextBlock.OpacityProperty));

            Storyboard.SetTarget(textBlockTranslateAnimation1, Contentstack);
            Storyboard.SetTargetProperty(textBlockTranslateAnimation1, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)"));
            var textBlockFadeInAnimation2 = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = new Duration(TimeSpan.FromSeconds(1))
            };

            var textBlockTranslateAnimation2 = new DoubleAnimation
            {
                From = -50,
                To = 0,
                Duration = new Duration(TimeSpan.FromSeconds(1))
            };

            Storyboard.SetTarget(textBlockFadeInAnimation2, Contentstack);
            Storyboard.SetTargetProperty(textBlockFadeInAnimation2, new PropertyPath(TextBlock.OpacityProperty));

            Storyboard.SetTarget(textBlockTranslateAnimation2, Contentstack);
            Storyboard.SetTargetProperty(textBlockTranslateAnimation1, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)"));
            var textBlockStoryboard1 = new Storyboard();
            textBlockStoryboard.Children.Add(textBlockFadeInAnimation1);
            textBlockStoryboard.Children.Add(textBlockTranslateAnimation1);

            var backgroundFadeInAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = new Duration(TimeSpan.FromSeconds(1)),
                BeginTime = TimeSpan.FromSeconds(1)
            };

            var backgroundTranslateAnimation = new DoubleAnimation
            {
                From = -50,
                To = 0,
                Duration = new Duration(TimeSpan.FromSeconds(1)),
                BeginTime = TimeSpan.FromSeconds(1)
            };

            Storyboard.SetTarget(backgroundFadeInAnimation, Animated_Background);
            Storyboard.SetTargetProperty(backgroundFadeInAnimation, new PropertyPath(Image.OpacityProperty));

            Storyboard.SetTarget(backgroundTranslateAnimation, Animated_Background);
            Storyboard.SetTargetProperty(backgroundTranslateAnimation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.Y)"));

            var backgroundStoryboard = new Storyboard();
            backgroundStoryboard.Children.Add(backgroundFadeInAnimation);
            backgroundStoryboard.Children.Add(backgroundTranslateAnimation);

            var bannerFadeInAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = new Duration(TimeSpan.FromSeconds(1)),
                BeginTime = TimeSpan.FromSeconds(2)
            };

            var bannerTranslateAnimation = new DoubleAnimation
            {
                From = -50,
                To = 0,
                Duration = new Duration(TimeSpan.FromSeconds(1)),
                BeginTime = TimeSpan.FromSeconds(2)
            };

            Storyboard.SetTarget(bannerFadeInAnimation, animated_Banner);
            Storyboard.SetTargetProperty(bannerFadeInAnimation, new PropertyPath(Image.OpacityProperty));

            Storyboard.SetTarget(bannerTranslateAnimation, animated_Banner);
            Storyboard.SetTargetProperty(bannerTranslateAnimation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.Y)"));

            var bannerStoryboard = new Storyboard();
            bannerStoryboard.Children.Add(bannerFadeInAnimation);
            bannerStoryboard.Children.Add(bannerTranslateAnimation);

            var textBlockTranslateAnimation3 = new DoubleAnimation
            {
                From = -50,
                To = 0,
                Duration = new Duration(TimeSpan.FromSeconds(1))
            };

            Storyboard.SetTarget(textBlockFadeInAnimation2, Other);
            Storyboard.SetTargetProperty(textBlockFadeInAnimation2, new PropertyPath(TextBlock.OpacityProperty));

            Storyboard.SetTarget(textBlockTranslateAnimation2, Other);
            Storyboard.SetTargetProperty(textBlockTranslateAnimation2, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)"));
            var textBlockStoryboard3 = new Storyboard();
            textBlockStoryboard.Children.Add(textBlockFadeInAnimation2);
            textBlockStoryboard.Children.Add(textBlockTranslateAnimation2);
            var moreButtonFadeInAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = new Duration(TimeSpan.FromSeconds(1)),
                BeginTime = TimeSpan.FromSeconds(3)
            };

            var moreButtonTranslateAnimation = new DoubleAnimation
            {
                From = -50,
                To = 0,
                Duration = new Duration(TimeSpan.FromSeconds(1)),
                BeginTime = TimeSpan.FromSeconds(3)
            };

            Storyboard.SetTarget(moreButtonFadeInAnimation, moreButton);
            Storyboard.SetTargetProperty(moreButtonFadeInAnimation, new PropertyPath(TextBlock.OpacityProperty));

            Storyboard.SetTarget(moreButtonTranslateAnimation, moreButton);
            Storyboard.SetTargetProperty(moreButtonTranslateAnimation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)"));

            var moreButtonStoryboard = new Storyboard();
            moreButtonStoryboard.Children.Add(moreButtonFadeInAnimation);
            moreButtonStoryboard.Children.Add(moreButtonTranslateAnimation);
            


            var borderFadeInAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = new Duration(TimeSpan.FromSeconds(1)),
                BeginTime = TimeSpan.FromSeconds(3)
            };

           
            var borderTranslateAnimation = new DoubleAnimation
            {
                From = -50,
                To = 0,
                Duration = new Duration(TimeSpan.FromSeconds(1)),
                BeginTime = TimeSpan.FromSeconds(3)
            };

            
            Storyboard.SetTarget(borderFadeInAnimation, Animated_Service);
            Storyboard.SetTargetProperty(borderFadeInAnimation, new PropertyPath(Border.OpacityProperty));

            
            Storyboard.SetTarget(borderTranslateAnimation, Animated_Service);
            Storyboard.SetTargetProperty(borderTranslateAnimation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.Y)"));

            var borderStoryboard = new Storyboard();
            borderStoryboard.Children.Add(borderFadeInAnimation);
            borderStoryboard.Children.Add(borderTranslateAnimation);
            textBlockStoryboard.Begin(this);
            backgroundStoryboard.Begin(this);
            bannerStoryboard.Begin(this);
            moreButtonStoryboard.Begin(this);
            backgroundStoryboard.Begin(this);
            borderStoryboard.Begin(this);


        }

        private void SignButton_Click(object sender, RoutedEventArgs e)
        {
            CoreNavigate.NavigatorCore.Navigate(new RecordPage());
        }

        private void VK_MouseDown(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void TG_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Service_button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SButton_Click(object sender, RoutedEventArgs e)
        {
            CoreNavigate.NavigatorCore.Navigate(new MastersPage());
        }

        private void Close_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
    }
