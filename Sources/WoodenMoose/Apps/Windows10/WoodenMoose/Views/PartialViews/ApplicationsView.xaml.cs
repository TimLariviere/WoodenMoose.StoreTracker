using Windows.ApplicationModel;
using Windows.UI.Xaml.Controls;
using WoodenMoose.ViewModels.PartialViews;
using WoodenMoose.ViewModels.UserControls;

namespace WoodenMoose.Views.PartialViews
{
    public delegate void ApplicationSelectedEventHandler(string applicationId);

    /// <summary>
    /// Partial view of applications
    /// </summary>
    public sealed partial class ApplicationsView
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class <see cref="ApplicationsView"/>
        /// </summary>
        public ApplicationsView()
        {
            InitializeComponent();

            if (!DesignMode.DesignModeEnabled)
            {
                DataContextChanged += (s, e) => Bindings.Update();
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the ViewModel associated to this View
        /// </summary>
        public ApplicationsViewViewModel ViewModel => DataContext as ApplicationsViewViewModel;

        #endregion

        #region Events

        public event ApplicationSelectedEventHandler ApplicationSelected;

        #endregion

        #region Event methods

        private void OnApplicationsListViewItemClick(object sender, ItemClickEventArgs e)
        {
            var vm = e.ClickedItem as ApplicationUserControlViewModel;
            if (vm != null)
            {
                ApplicationSelected?.Invoke(vm.ApplicationId);
            }
        }

        #endregion
    }
}
