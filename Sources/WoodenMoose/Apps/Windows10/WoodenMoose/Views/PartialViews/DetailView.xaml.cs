using Windows.UI.Xaml;
using WoodenMoose.ViewModels.PartialViews;

namespace WoodenMoose.Views.PartialViews
{
    /// <summary>
    /// Partial view of detail
    /// </summary>
    public sealed partial class DetailView
    {
        public double MaxReviewItemWidth
        {
            get { return (double)GetValue(MaxReviewItemWidthProperty); }
            set { SetValue(MaxReviewItemWidthProperty, value); }
        }
        
        public static readonly DependencyProperty MaxReviewItemWidthProperty = DependencyProperty.Register("MaxReviewItemWidth", typeof(double), typeof(DetailView), new PropertyMetadata(double.NaN));
        
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class <see cref="DetailView"/>
        /// </summary>
        public DetailView()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the ViewModel associated to this View
        /// </summary>
        public DetailViewViewModel ViewModel => DataContext as DetailViewViewModel;

        #endregion
    }
}
