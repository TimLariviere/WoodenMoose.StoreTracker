using Windows.UI.Xaml.Media;
using Template10.Mvvm;

namespace WoodenMoose.ViewModels.UserControls
{
    public class MarketUserControlViewModel : ViewModelBase
    {
        #region Fields

        private string _applicationId;
        private string _marketId;
        private string _name;
        private string _imageUrl;
        private double _averageRating;
        private int _ratings;
        private int _reviews;
        private int _unreadReviews;

        #endregion

        #region Properties

        public string ApplicationId
        {
            get { return _applicationId; }
            set { Set(ref _applicationId, value); }
        }

        public string MarketId
        {
            get { return _marketId; }
            set { Set(ref _marketId, value); }
        }

        public string Name
        {
            get { return _name; }
            set { Set(ref _name, value); }
        }

        public string ImageUrl
        {
            get { return _imageUrl; }
            set { Set(ref _imageUrl, value); }
        }

        public double AverageRating
        {
            get { return _averageRating; }
            set { Set(ref _averageRating, value); }
        }

        public int Ratings
        {
            get { return _ratings; }
            set { Set(ref _ratings, value); }
        }

        public int Reviews
        {
            get { return _reviews; }
            set { Set(ref _reviews, value); }
        }

        public int UnreadReviews
        {
            get { return _unreadReviews; }
            set { Set(ref _unreadReviews, value); }
        }

        #endregion
    }
}
