using Microsoft.Practices.Unity;
using System;
using System.Threading.Tasks;
using Template10.Mvvm;
using WoodenMoose.Core.Repositories;

namespace WoodenMoose.ViewModels.PartialViews
{
    public class SummaryViewViewModel : ViewModelBase
    {
        #region Fields

        private double _averageRating;
        private int _star1Count;
        private int _star2Count;
        private int _star3Count;
        private int _star4Count;
        private int _star5Count;
        private int _ratingsCount;
        private int _newRatingsCount;
        private int _reviewsCount;
        private int _newReviewsCount;
        private int _acquisitionsCount;
        private int _newAcquisitionsCount;

        #endregion

        #region Injected properties

        [Dependency]
        public IApplicationRepository ApplicationRepository { get; set; }

        [Dependency]
        public IApplicationMarketRepository ApplicationMarketRepository { get; set; }

        #endregion

        #region Properties

        public double AverageRating
        {
            get { return _averageRating; }
            set { Set(ref _averageRating, value); }
        }

        public int Star1Count
        {
            get { return _star1Count; }
            set { Set(ref _star1Count, value); }
        }

        public int Star2Count
        {
            get { return _star2Count; }
            set { Set(ref _star2Count, value); }
        }

        public int Star3Count
        {
            get { return _star3Count; }
            set { Set(ref _star3Count, value); }
        }

        public int Star4Count
        {
            get { return _star4Count; }
            set { Set(ref _star4Count, value); }
        }

        public int Star5Count
        {
            get { return _star5Count; }
            set { Set(ref _star5Count, value); }
        }

        public int RatingsCount
        {
            get { return _ratingsCount; }
            set { Set(ref _ratingsCount, value); }
        }

        public int NewRatingsCount
        {
            get { return _newRatingsCount; }
            set { Set(ref _newRatingsCount, value); }
        }

        public int ReviewsCount
        {
            get { return _reviewsCount; }
            set { Set(ref _reviewsCount, value); }
        }

        public int NewReviewsCount
        {
            get { return _newReviewsCount; }
            set { Set(ref _newReviewsCount, value); }
        }

        public int AcquisitionsCount
        {
            get { return _acquisitionsCount; }
            set { Set(ref _acquisitionsCount, value); }
        }

        public int NewAcquisitionsCount
        {
            get { return _newAcquisitionsCount; }
            set { Set(ref _newAcquisitionsCount, value); }
        }

        #endregion

        #region Methods

        public async Task LoadAsync(string applicationId, string marketId)
        {
            if (marketId == "ww")
            {
                var application = await ApplicationRepository.GetAsync(applicationId);
                if (application != null)
                {
                    AverageRating = Math.Round(application.AverageRating, 1, MidpointRounding.ToEven);
                    Star1Count = application.OneStarRatingsCount;
                    Star2Count = application.TwoStarsRatingsCount;
                    Star3Count = application.ThreeStarsRatingsCount;
                    Star4Count = application.FourStarsRatingsCount;
                    Star5Count = application.FiveStarsRatingsCount;
                    RatingsCount = application.TotalRatingsCount;
                    NewRatingsCount = 0;
                    ReviewsCount = application.TotalReviewsCount;
                    NewReviewsCount = application.UnreadReviewsCount;
                    AcquisitionsCount = 0;
                    NewAcquisitionsCount = 0;
                }
            }
            else
            {
                var market = await ApplicationMarketRepository.GetAsync(applicationId, marketId);
                if (market != null)
                {
                    AverageRating = Math.Round(market.AverageRating, 1, MidpointRounding.ToEven);
                    Star1Count = market.OneStarRatingsCount;
                    Star2Count = market.TwoStarsRatingsCount;
                    Star3Count = market.ThreeStarsRatingsCount;
                    Star4Count = market.FourStarsRatingsCount;
                    Star5Count = market.FiveStarsRatingsCount;
                    RatingsCount = market.TotalRatingsCount;
                    NewRatingsCount = 0;
                    ReviewsCount = market.TotalReviewsCount;
                    NewReviewsCount = market.UnreadReviewsCount;
                    AcquisitionsCount = 0;
                    NewAcquisitionsCount = 0;
                }
            }
        }

        #endregion
    }
}
