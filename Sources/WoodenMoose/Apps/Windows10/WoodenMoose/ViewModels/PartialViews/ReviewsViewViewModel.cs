using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Template10.Mvvm;
using WoodenMoose.Core.Models;
using WoodenMoose.Core.Repositories;
using WoodenMoose.Helpers;
using WoodenMoose.ViewModels.UserControls;

namespace WoodenMoose.ViewModels.PartialViews
{
    public class ReviewsViewViewModel : ViewModelBase
    {
        #region Fields

        private ObservableCollection<ReviewUserControlViewModel> _reviews = new ObservableCollection<ReviewUserControlViewModel>();

        #endregion

        #region Injected properties

        [Dependency]
        public IApplicationRepository ApplicationRepository { get; set; }

        [Dependency]
        public IApplicationMarketRepository ApplicationMarketRepository { get; set; }

        #endregion

        #region Properties

        public ObservableCollection<ReviewUserControlViewModel> Reviews
        {
            get { return _reviews; }
            set { Set(ref _reviews, value); }
        }

        #endregion

        #region Methods

        public async Task LoadAsync(string applicationId, string marketId)
        {
            _reviews.Clear();

            var showMarketFlag = false;
            var reviews = new List<Tuple<Review, string>>();
            if (marketId == "ww")
            {
                showMarketFlag = true;

                var application = await ApplicationRepository.GetAsync(applicationId);
                if (application != null)
                {
                    foreach (var market in application.Markets)
                    {
                        reviews.AddRange(market.Reviews.Select(r => Tuple.Create(r, market.MarketId)));
                    }
                }
            }
            else
            {
                var market = await ApplicationMarketRepository.GetAsync(applicationId, marketId);
                if (market != null)
                {
                    reviews.AddRange(market.Reviews.Select(r => Tuple.Create(r, market.MarketId)));
                }
            }

            var viewModels = reviews.Select(r => r.Item1.ToViewModel(r.Item2, showMarketFlag))
                                    .OrderByDescending(r => r.Date);
            foreach (var viewModel in viewModels)
            {
                _reviews.Add(viewModel);
            }
        }

        #endregion
    }
}
