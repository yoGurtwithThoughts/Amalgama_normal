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

namespace Amalgama.UserControls
{
    /// <summary>
    /// Логика взаимодействия для TxtEffects.xaml
    /// </summary>
    public partial class TxtEffects : UserControl
    {
        public TxtEffects()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(TxtEffects), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty TextBrushProperty =
            DependencyProperty.Register("TextBrush", typeof(Brush), typeof(TxtEffects), new FrameworkPropertyMetadata(Brushes.Black, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty OutlineBrushProperty =
            DependencyProperty.Register("OutlineBrush", typeof(Brush), typeof(TxtEffects), new FrameworkPropertyMetadata(Brushes.Black, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty OutlineThicknessProperty =
            DependencyProperty.Register("OutlineThickness", typeof(double), typeof(TxtEffects), new FrameworkPropertyMetadata(1.0, FrameworkPropertyMetadataOptions.AffectsRender));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public Brush TextBrush
        {
            get { return (Brush)GetValue(TextBrushProperty); }
            set { SetValue(TextBrushProperty, value); }
        }

        public Brush OutlineBrush
        {
            get { return (Brush)GetValue(OutlineBrushProperty); }
            set { SetValue(OutlineBrushProperty, value); }
        }

        public double OutlineThickness
        {
            get { return (double)GetValue(OutlineThicknessProperty); }
            set { SetValue(OutlineThicknessProperty, value); }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            var formattedText = new FormattedText(
                Text,
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface(new FontFamily("CustomFont"), FontStyles.Normal, FontWeights.Normal, FontStretches.Normal),
                12,
                TextBrush);

            var geometry = formattedText.BuildGeometry(new Point(0, 0));

            var pen = new Pen(OutlineBrush, OutlineThickness);
            drawingContext.DrawGeometry(null, pen, geometry);
            drawingContext.DrawText(formattedText, new Point(0, 0));
        }
    }
}
