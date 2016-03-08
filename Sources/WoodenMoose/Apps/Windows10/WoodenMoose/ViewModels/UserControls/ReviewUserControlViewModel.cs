using System;
using Template10.Mvvm;

namespace WoodenMoose.ViewModels.UserControls
{
    public class ReviewUserControlViewModel : ViewModelBase
    {
        #region Fields

        private string _reviewId;
        private string _title;
        private string _content;
        private string _author;
        private DateTime _date;
        private int _rating;
        private bool _isNew;
        private string _marketImageUrl;
        private bool _showMarketFlag;

        #endregion

        #region Properties

        public string ReviewId
        {
            get { return _reviewId; }
            set { Set(ref _reviewId, value); }
        }

        public string Title
        {
            get { return _title; }
            set { Set(ref _title, value); }
        }

        public string Content
        {
            get { return _content; }
            set { Set(ref _content, value); }
        }

        public string Author
        {
            get { return _author; }
            set { Set(ref _author, value); }
        }

        public DateTime Date
        {
            get { return _date; }
            set { Set(ref _date, value); }
        }

        public int Rating
        {
            get { return _rating; }
            set { Set(ref _rating, value); }
        }

        public bool IsNew
        {
            get { return _isNew; }
            set { Set(ref _isNew, value); }
        }

        public string MarketImageUrl
        {
            get { return _marketImageUrl; }
            set { Set(ref _marketImageUrl, value); }
        }

        public bool ShowMarketFlag
        {
            get { return _showMarketFlag; }
            set { Set(ref _showMarketFlag, value); }
        }

        #endregion
    }
}
