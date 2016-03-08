using Microsoft.Practices.Unity;
using WoodenMoose.Core.Models;
using WoodenMoose.ViewModels;
using WoodenMoose.ViewModels.UserControls;

namespace WoodenMoose.Helpers
{
    public static class MapperHelper
    {
        public static ApplicationUserControlViewModel ToViewModel(this Application application)
        {
            var viewModelLocator = (App.Current as App)?.UnityContainer?.Resolve<ViewModelLocator>();
            var viewModel = viewModelLocator?.ApplicationUserControlViewModel;

            if (viewModel != null)
            {
                viewModel.ApplicationId = application.Id;
                viewModel.Name = application.Name;
                viewModel.ImageUrl = application.ImageUrl;
                viewModel.Background = BrushHelper.ColorToBrush(application.Background);
                viewModel.AverageRating = application.AverageRating;
                viewModel.Ratings = application.TotalRatingsCount;
                viewModel.Reviews = application.TotalReviewsCount;
                viewModel.UnreadReviews = application.UnreadReviewsCount;
            }

            return viewModel;
        }

        public static MarketUserControlViewModel ToViewModel(this ApplicationMarket applicationMarket)
        {
            var viewModelLocator = (App.Current as App)?.UnityContainer?.Resolve<ViewModelLocator>();
            var viewModel = viewModelLocator?.MarketUserControlViewModel;

            if (viewModel != null)
            {
                viewModel.ApplicationId = applicationMarket.ApplicationId;
                viewModel.MarketId = applicationMarket.MarketId;
                viewModel.Name = ResourceHelper.GetString(applicationMarket.MarketId, ResourcesFileEnum.CountriesResources);
                viewModel.ImageUrl = $"ms-appx:///Assets/Flags/{applicationMarket.MarketId}.png";
                viewModel.AverageRating = applicationMarket.AverageRating;
                viewModel.Ratings = applicationMarket.TotalRatingsCount;
                viewModel.Reviews = applicationMarket.TotalReviewsCount;
                viewModel.UnreadReviews = applicationMarket.UnreadReviewsCount;
            }

            return viewModel;
        }

        public static ReviewUserControlViewModel ToViewModel(this Review review, string marketId, bool showMarketFlag)
        {
            var viewModelLocator = (App.Current as App)?.UnityContainer?.Resolve<ViewModelLocator>();
            var viewModel = viewModelLocator?.ReviewUserControlViewModel;

            if (viewModel != null)
            {
                viewModel.ReviewId = review.Id;
                viewModel.Title = review.Title;
                viewModel.Content = review.Content;
                viewModel.Rating = review.Rating;
                viewModel.Author = review.Author;
                viewModel.Date = review.Date;
                viewModel.IsNew = review.IsNew;
                viewModel.MarketImageUrl = $"ms-appx:///Assets/Flags/{marketId}.png";
                viewModel.ShowMarketFlag = showMarketFlag;
            }

            return viewModel;
        }
    }
}
