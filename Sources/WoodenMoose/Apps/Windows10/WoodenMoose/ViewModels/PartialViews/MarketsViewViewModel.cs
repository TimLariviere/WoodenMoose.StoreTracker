using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Template10.Mvvm;
using WoodenMoose.Core.Repositories;
using WoodenMoose.Helpers;
using System.Linq;
using WoodenMoose.ViewModels.UserControls;

namespace WoodenMoose.ViewModels.PartialViews
{
    /// <summary>
    /// ViewModel of MarketsView
    /// </summary>
    public class MarketsViewViewModel : ViewModelBase
    {
        #region Fields

        /// <summary>
        /// List of all markets where the application has ratings
        /// </summary>
        private ObservableCollection<MarketUserControlViewModel> _markets = new ObservableCollection<MarketUserControlViewModel>();

        #endregion

        #region Injected properties

        [Dependency]
        public IApplicationRepository ApplicationRepository { get; set; }

        [Dependency]
        public ViewModelLocator ViewModelLocator { get; set; }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the list of all markets where the application has ratings
        /// </summary>
        public ObservableCollection<MarketUserControlViewModel> Markets
        {
            get { return _markets; }
            set { Set(ref _markets, value); }
        }

        #endregion

        #region Methods

        public async Task LoadAsync(string applicationId)
        {
            _markets.Clear();

            var application = await ApplicationRepository.GetAsync(applicationId);
            if (application != null)
            {
                var worldwideMarket = ViewModelLocator.MarketUserControlViewModel;
                worldwideMarket.ApplicationId = applicationId;
                worldwideMarket.MarketId = "ww";
                worldwideMarket.Name = ResourceHelper.GetString("ww", ResourcesFileEnum.CountriesResources);
                worldwideMarket.ImageUrl = $"ms-appx:///Assets/Flags/ww.png";
                worldwideMarket.AverageRating = application.Markets.Average(m => m.AverageRating);
                worldwideMarket.Ratings = application.Markets.Sum(m => m.TotalRatingsCount);
                worldwideMarket.Reviews = application.Markets.Sum(m => m.TotalReviewsCount);
                worldwideMarket.UnreadReviews = application.Markets.Sum(m => m.UnreadReviewsCount);

                _markets.Add(worldwideMarket);

                foreach (var market in application.Markets.Select(m => m.ToViewModel()))
                {
                    _markets.Add(market);
                }
            }
        }

        #endregion
    }
}
