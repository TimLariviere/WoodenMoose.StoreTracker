using WoodenMoose.ViewModels;

namespace WoodenMoose.Views
{
    public sealed partial class DetailPage
    {
        public DetailPage()
        {
            InitializeComponent();
            DataContextChanged += (s, e) => Bindings.Update();
        }

        public DetailPageViewModel ViewModel => DataContext as DetailPageViewModel;
    }
}
