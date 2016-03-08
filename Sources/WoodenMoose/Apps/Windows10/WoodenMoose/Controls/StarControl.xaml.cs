using System;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace WoodenMoose.Controls
{
    public sealed partial class StarControl
    {
        #region Dependency properties

        public static readonly DependencyProperty OutlineBrushProperty =
            DependencyProperty.Register("OutlineBrush", typeof(Brush), typeof(StarControl), new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));

        public static readonly DependencyProperty OutlineThicknessProperty =
            DependencyProperty.Register("OutlineThickness", typeof(double), typeof(StarControl), new PropertyMetadata(0d));

        public static readonly DependencyProperty FilledBrushProperty =
            DependencyProperty.Register("FilledBrush", typeof(Brush), typeof(StarControl), new PropertyMetadata(new SolidColorBrush(Colors.Gold)));

        public static readonly DependencyProperty UnfilledBrushProperty =
            DependencyProperty.Register("UnfilledBrush", typeof(Brush), typeof(StarControl), new PropertyMetadata(new SolidColorBrush(Colors.Gray)));

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(StarControl), new PropertyMetadata(0d, OnValuePropertyChanged));
        
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var starControl = d as StarControl;
            if (starControl != null)
            {
                var newValue = (double)e.NewValue;
                if (newValue < 0 || newValue > 1)
                {
                    starControl.Value = Math.Min(Math.Max(0, newValue), 1);
                    return;
                }

                var clipWidth = 11 * newValue;
                starControl.ClipGeometry.Rect = new Rect(0, 0, clipWidth, 11);
            }
        }

        #endregion

        #region Constructor

        public StarControl()
        {
            InitializeComponent();
        } 

        #endregion

        #region Properties

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

        public Brush FilledBrush
        {
            get { return (Brush)GetValue(FilledBrushProperty); }
            set { SetValue(FilledBrushProperty, value); }
        }

        public Brush UnfilledBrush
        {
            get { return (Brush)GetValue(UnfilledBrushProperty); }
            set { SetValue(UnfilledBrushProperty, value); }
        }

        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        #endregion
    }
}
