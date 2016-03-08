using System.Linq;
using Windows.UI.Xaml.Media.Animation;
using Template10.Common;
using WoodenMoose.ViewModels;

namespace WoodenMoose.Views
{
    public sealed partial class MarketsPage
    {
        public MarketsPage()
        {
            InitializeComponent();
            DataContextChanged += (s, e) => Bindings.Update();
        }

        public MarketsPageViewModel ViewModel => DataContext as MarketsPageViewModel;

        private void OnMarketSelected(string applicationId, string marketId)
        {
            var nav = WindowWrapper.Current().NavigationServices.FirstOrDefault();
            nav.Navigate(typeof(DetailPage), $"{applicationId}|{marketId}", new DrillInNavigationTransitionInfo());
        }
    }
}
