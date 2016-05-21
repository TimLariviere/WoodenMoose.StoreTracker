using SQLite.Net.Platform.WinRT;
using System.Threading.Tasks;
using Template10.Common;
using Windows.ApplicationModel.Activation;
using WoodenMoose.Core.Services;
using WoodenMoose.UWP.Platform;
using WoodenMoose.UWP.Views;

namespace WoodenMoose.UWP
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public sealed partial class App : BootStrapper
    {
        public App()
        {
            InitializeComponent();
        }

        public override async Task OnInitializeAsync(IActivatedEventArgs args)
        {
            await DependencyService.InitializeAsync();
            await DependencyService.RegisterCoreAsync();
            await DependencyService.RegisterPlatformSpecificAsync<SQLitePlatformWinRT, SQLite_Windows>();
        }

        public override Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
        {
            NavigationService.Navigate(typeof(MainPage));
            return Task.CompletedTask;
        }
    }
}
