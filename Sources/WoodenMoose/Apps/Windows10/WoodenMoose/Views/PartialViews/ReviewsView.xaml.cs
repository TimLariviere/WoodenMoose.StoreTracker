using Windows.UI.Xaml;
using WoodenMoose.ViewModels.PartialViews;

namespace WoodenMoose.Views.PartialViews
{
    public sealed partial class ReviewsView
    {
        public double MaxItemWidth
        {
            get { return (double)GetValue(MaxItemWidthProperty); }
            set { SetValue(MaxItemWidthProperty, value); }
        }
        
        public static readonly DependencyProperty MaxItemWidthProperty = DependencyProperty.Register("MaxItemWidth", typeof(double), typeof(ReviewsView), new PropertyMetadata(double.NaN));
        
        public ReviewsView()
        {
            InitializeComponent();
            //DataContextChanged += (s, e) => Bindings.Update();
        }

        public ReviewsViewViewModel ViewModel => DataContext as ReviewsViewViewModel;
    }
}
