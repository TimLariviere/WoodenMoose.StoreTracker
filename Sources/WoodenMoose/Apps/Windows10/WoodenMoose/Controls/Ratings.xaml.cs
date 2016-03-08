using System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace WoodenMoose.Controls
{
    public sealed partial class Ratings
    {
        #region Static methods

        private static void CreateStars(Ratings control)
        {
            control.Root.Children.Clear();
            control.Root.ColumnDefinitions.Clear();

            for (int i = 0; i < control.NumberOfStars; i++)
            {
                control.Root.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int i = 0; i < control.NumberOfStars; i++)
            {
                var value = Math.Min((control.Value - i), 1);

                var star = new StarControl()
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    Value = value
                };

                star.SetBinding(StarControl.OutlineBrushProperty, new Binding()
                {
                    Source = control,
                    Path = new PropertyPath(nameof(OutlineBrush))
                });
                star.SetBinding(StarControl.OutlineThicknessProperty, new Binding()
                {
                    Source = control,
                    Path = new PropertyPath(nameof(OutlineThickness))
                });
                star.SetBinding(StarControl.FilledBrushProperty, new Binding()
                {
                    Source = control,
                    Path = new PropertyPath(nameof(FilledBrush))
                });
                star.SetBinding(StarControl.UnfilledBrushProperty, new Binding()
                {
                    Source = control,
                    Path = new PropertyPath(nameof(UnfilledBrush))
                });

                Grid.SetColumn(star, i);

                control.Root.Children.Add(star);
            }
        }

        #endregion

        #region Dependency properties

        public static readonly DependencyProperty OutlineBrushProperty =
            DependencyProperty.Register("OutlineBrush", typeof(Brush), typeof(Ratings), new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));

        public static readonly DependencyProperty OutlineThicknessProperty =
            DependencyProperty.Register("OutlineThickness", typeof(double), typeof(Ratings), new PropertyMetadata(0d));

        public static readonly DependencyProperty FilledBrushProperty =
            DependencyProperty.Register("FilledBrush", typeof(Brush), typeof(Ratings), new PropertyMetadata(new SolidColorBrush(Colors.Gold)));

        public static readonly DependencyProperty UnfilledBrushProperty =
            DependencyProperty.Register("UnfilledBrush", typeof(Brush), typeof(Ratings), new PropertyMetadata(new SolidColorBrush(Colors.Gray)));

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(Ratings), new PropertyMetadata(0d, OnValuePropertyChanged));

        public static readonly DependencyProperty NumberOfStarsProperty =
            DependencyProperty.Register("NumberOfStars", typeof(int), typeof(Ratings), new PropertyMetadata(5, OnNumberOfStarsPropertyChanged));
        
        private static void OnNumberOfStarsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var Ratings = d as Ratings;
            if (Ratings != null)
            {
                var newValue = (int)e.NewValue;
                if (newValue < 0)
                {
                    Ratings.NumberOfStars = 0;
                    return;
                }

                CreateStars(Ratings);
            }
        }
        
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var Ratings = d as Ratings;
            if (Ratings != null)
            {
                var newValue = (double)e.NewValue;
                if (newValue < 0 || newValue > Ratings.NumberOfStars)
                {
                    Ratings.Value = Math.Min(Math.Max(0, newValue), Ratings.NumberOfStars);
                    return;
                }

                CreateStars(Ratings);
            }
        }

        #endregion

        #region Constructor

        public Ratings()
        {
            InitializeComponent();
            CreateStars(this);
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

        public int NumberOfStars
        {
            get { return (int)GetValue(NumberOfStarsProperty); }
            set { SetValue(NumberOfStarsProperty, value); }
        }

        #endregion
    }
}
