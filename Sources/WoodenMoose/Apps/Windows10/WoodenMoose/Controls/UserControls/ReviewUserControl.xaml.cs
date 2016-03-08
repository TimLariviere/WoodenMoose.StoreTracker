using WoodenMoose.ViewModels.UserControls;

namespace WoodenMoose.Controls.UserControls
{
    public sealed partial class ReviewUserControl
    {
        public ReviewUserControl()
        {
            InitializeComponent();
            DataContextChanged += (sender, args) => Bindings.Update();
        }

        public ReviewUserControlViewModel ViewModel => DataContext as ReviewUserControlViewModel;
    }
}
