using Windows.UI.Xaml;
using Microsoft.Practices.Unity;
using WoodenMoose.ViewModels.PartialViews;
using WoodenMoose.ViewModels.UserControls;

namespace WoodenMoose.ViewModels
{
    public class ViewModelLocator
    {
        private IUnityContainer UnityContainer => (Application.Current as App)?.UnityContainer;

        #region Pages

        public MainPageViewModel MainPageViewModel => UnityContainer.Resolve<MainPageViewModel>();
        public MarketsPageViewModel MarketsPageViewModel => UnityContainer.Resolve<MarketsPageViewModel>();
        public DetailPageViewModel DetailPageViewModel => UnityContainer.Resolve<DetailPageViewModel>();

        #endregion

        #region Views

        public ApplicationsViewViewModel ApplicationsViewViewModel => UnityContainer.Resolve<ApplicationsViewViewModel>();
        public MarketsViewViewModel MarketsViewViewModel => UnityContainer.Resolve<MarketsViewViewModel>();
        public DetailViewViewModel DetailViewViewModel => UnityContainer.Resolve<DetailViewViewModel>();
        public SummaryViewViewModel SummaryViewViewModel => UnityContainer.Resolve<SummaryViewViewModel>();
        public ReviewsViewViewModel ReviewsViewViewModel => UnityContainer.Resolve<ReviewsViewViewModel>();

        #endregion

        #region UserControls

        public ApplicationUserControlViewModel ApplicationUserControlViewModel => UnityContainer.Resolve<ApplicationUserControlViewModel>();
        public MarketUserControlViewModel MarketUserControlViewModel => UnityContainer.Resolve<MarketUserControlViewModel>();
        public ReviewUserControlViewModel ReviewUserControlViewModel => UnityContainer.Resolve<ReviewUserControlViewModel>();

        #endregion
    }
}