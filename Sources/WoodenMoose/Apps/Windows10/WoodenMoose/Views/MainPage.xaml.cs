using System.Linq;
using Windows.UI.Xaml.Media.Animation;
using Template10.Common;
using WoodenMoose.ViewModels;

namespace WoodenMoose.Views
{
    /// <summary>
    /// Main page
    /// </summary>
    public sealed partial class MainPage
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            DataContextChanged += (s, e) => Bindings.Update();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the ViewModel associated to this View
        /// </summary>
        public MainPageViewModel ViewModel => DataContext as MainPageViewModel;

        #endregion

        private void OnApplicationSelected(string applicationId)
        {
            if (WindowStates.CurrentState == NarrowState)
            {
                var nav = WindowWrapper.Current().NavigationServices.FirstOrDefault();
                nav.Navigate(typeof (MarketsPage), applicationId, new DrillInNavigationTransitionInfo());
            }
            else
            {
                ViewModel.SelectApplication(applicationId);
            }
        }

        private void OnMarketSelected(string applicationId, string marketId)
        {
            if (WindowStates.CurrentState == MediumState)
            {
                var nav = WindowWrapper.Current().NavigationServices.FirstOrDefault();
                nav.Navigate(typeof(DetailPage), $"{applicationId}|{marketId}", new DrillInNavigationTransitionInfo());
            }
            else
            {
                ViewModel.SelectMarket(marketId);
            }
        }
    }
}
