using Windows.UI.Xaml.Media;
using Template10.Mvvm;

namespace WoodenMoose.ViewModels.UserControls
{
    public class ApplicationUserControlViewModel : ViewModelBase
    {
        #region Fields

        private string _applicationId;
        private string _name;
        private string _imageUrl;
        private Brush _background;
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

        public Brush Background
        {
            get { return _background; }
            set { Set(ref _background, value); }
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
