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

        public StartPage()
        {
            InitializeComponent();
            InitializeTimer();
            InitializeContentItems();
        }
        private void InitializeContentItems()
        {
            Style titleMainStyle = (Style)FindResource("SliderBar");

            _contentItems = new List<UIElement> {
            new TextBlock { Text = "Татуировщики рекомендуют\nделать татуировки, а так же пирсинг,\nне в жаркое время\nгода т. е. осенью ,зимой, весной! ", TextWrapping=TextWrapping.Wrap, Style = titleMainStyle  },
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

        }

        private void VK_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CoreNavigate.NavigatorCore.Navigate(new RecordPage());
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
    }
    }
