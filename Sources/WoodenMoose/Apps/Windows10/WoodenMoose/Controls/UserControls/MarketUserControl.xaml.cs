using WoodenMoose.ViewModels.UserControls;

namespace WoodenMoose.Controls.UserControls
{
    public sealed partial class MarketUserControl
    {
        public MarketUserControl()
        {
            InitializeComponent();
            DataContextChanged += (sender, args) => Bindings.Update();
        }

        public MarketUserControlViewModel ViewModel => DataContext as MarketUserControlViewModel;
    }
}
