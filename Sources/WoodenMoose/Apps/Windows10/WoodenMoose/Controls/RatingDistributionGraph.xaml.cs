using Windows.UI.Xaml;

namespace WoodenMoose.Controls
{
    public sealed partial class RatingDistributionGraph
    {
        #region Dependency properties

        public static readonly DependencyProperty Star1CountProperty = DependencyProperty.Register("Star1Count", typeof(int), typeof(RatingDistributionGraph), new PropertyMetadata(0));

        public static readonly DependencyProperty Star2CountProperty = DependencyProperty.Register("Star2Count", typeof(int), typeof(RatingDistributionGraph), new PropertyMetadata(0));

        public static readonly DependencyProperty Star3CountProperty = DependencyProperty.Register("Star3Count", typeof(int), typeof(RatingDistributionGraph), new PropertyMetadata(0));

        public static readonly DependencyProperty Star4CountProperty = DependencyProperty.Register("Star4Count", typeof(int), typeof(RatingDistributionGraph), new PropertyMetadata(0));

        public static readonly DependencyProperty Star5CountProperty = DependencyProperty.Register("Star5Count", typeof(int), typeof(RatingDistributionGraph), new PropertyMetadata(0));

        public static readonly DependencyProperty TotalStarCountProperty = DependencyProperty.Register("TotalStarCount", typeof(int), typeof(RatingDistributionGraph), new PropertyMetadata(0));

        #endregion

        #region Constructor

        public RatingDistributionGraph()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public int Star1Count
        {
            get { return (int)GetValue(Star1CountProperty); }
            set { SetValue(Star1CountProperty, value); }
        }

        public int Star2Count
        {
            get { return (int)GetValue(Star2CountProperty); }
            set { SetValue(Star2CountProperty, value); }
        }

        public int Star3Count
        {
            get { return (int)GetValue(Star3CountProperty); }
            set { SetValue(Star3CountProperty, value); }
        }

        public int Star4Count
        {
            get { return (int)GetValue(Star4CountProperty); }
            set { SetValue(Star4CountProperty, value); }
        }

        public int Star5Count
        {
            get { return (int)GetValue(Star5CountProperty); }
            set { SetValue(Star5CountProperty, value); }
        }

        public int TotalStarCount
        {
            get { return (int)GetValue(TotalStarCountProperty); }
            set { SetValue(TotalStarCountProperty, value); }
        }

        #endregion
    }
}
