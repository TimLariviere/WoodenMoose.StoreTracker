using System;
using System.Threading.Tasks;
using SQLite.Net.Platform.XamarinIOS;
using UIKit;
using WoodenMoose.Core.Services;
using WoodenMoose.iOS.Platform;

namespace WoodenMoose.iOS.ViewControllers
{
	partial class SplashScreenViewController : UIViewController
	{
		public SplashScreenViewController (IntPtr handle) : base (handle)
		{
		}

	    public override async void ViewDidLoad()
	    {
	        await LoadAsync();

            PerformSegue("Loaded", null);
	    }

        private async Task LoadAsync()
        {
            await DependencyService.InitializeAsync();
            await DependencyService.RegisterCoreAsync();
            await DependencyService.RegisterPlatformSpecificAsync<SQLitePlatformIOS, SQLiteParameters>();
        }
    }
}
