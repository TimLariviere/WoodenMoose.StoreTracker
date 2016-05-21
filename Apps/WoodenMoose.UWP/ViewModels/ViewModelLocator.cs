using WoodenMoose.Core.Services;

namespace WoodenMoose.UWP.ViewModels
{
    public static class ViewModelLocator
    {
        public static MainPageViewModel MainPageViewModel => DependencyService.Resolve<MainPageViewModel>();
    }
}
