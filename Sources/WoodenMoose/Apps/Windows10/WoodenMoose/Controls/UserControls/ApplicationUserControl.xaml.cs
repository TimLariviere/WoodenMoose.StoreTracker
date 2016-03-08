using WoodenMoose.ViewModels.UserControls;

namespace WoodenMoose.Controls.UserControls
{
    public sealed partial class ApplicationUserControl
    {
        public ApplicationUserControl()
        {
            InitializeComponent();
            DataContextChanged += (sender, args) => Bindings.Update();
        }

        public ApplicationUserControlViewModel ViewModel => DataContext as ApplicationUserControlViewModel;
    }
}
