using WoodenMoose.ViewModels;

namespace WoodenMoose.Views
{
    public sealed partial class FirstTimePage
    {
        public FirstTimePage()
        {
            InitializeComponent();
        }

        #region Properties

        public FirstTimePageViewModel ViewModel => DataContext as FirstTimePageViewModel;

        #endregion
    }
}
