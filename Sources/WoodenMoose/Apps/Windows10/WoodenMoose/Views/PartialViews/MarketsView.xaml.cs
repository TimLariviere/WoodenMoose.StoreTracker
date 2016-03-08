using Windows.ApplicationModel;
using Windows.UI.Xaml.Controls;
using WoodenMoose.ViewModels.PartialViews;
using WoodenMoose.ViewModels.UserControls;

namespace WoodenMoose.Views.PartialViews
{
    public delegate void MarketSelectedEventHandler(string applicationId, string marketId);

    /// <summary>
    /// Partial view of markets
    /// </summary>
    public sealed partial class MarketsView
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class <see cref="MarketsView"/>
        /// </summary>
        public MarketsView()
        {
            InitializeComponent();
            DataContextChanged += (s, e) => Bindings.Update();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the ViewModel associated to this View
        /// </summary>
        public MarketsViewViewModel ViewModel => DataContext as MarketsViewViewModel;

        #endregion

        #region Events

        public event MarketSelectedEventHandler MarketSelected;

        #endregion

        #region Event methods

        private void OnListViewItemClick(object sender, ItemClickEventArgs e)
        {
            var vm = e.ClickedItem as MarketUserControlViewModel;
            if (vm != null)
            {
                MarketSelected?.Invoke(vm.ApplicationId, vm.MarketId);
            }
        }

        #endregion
    }
}
