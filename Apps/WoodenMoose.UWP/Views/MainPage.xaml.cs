using WoodenMoose.UWP.ViewModels;

namespace WoodenMoose.UWP.Views
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = ViewModelLocator.MainPageViewModel;
            //DataContextChanged += (s, e) => Bindings.Update();
        }

        public MainPageViewModel ViewModel => DataContext as MainPageViewModel;
    }
}
