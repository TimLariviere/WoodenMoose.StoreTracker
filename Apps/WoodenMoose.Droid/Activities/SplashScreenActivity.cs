using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using SQLite.Net.Platform.XamarinAndroid;
using WoodenMoose.Core.Services;
using WoodenMoose.Droid.Platform;

namespace WoodenMoose.Droid.Activities
{
    [Activity(Label = "Wooden Moose", MainLauncher = true, NoHistory = true, Theme = "@style/Theme.Splash",
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SplashScreen : Activity
    {
        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            await LoadAsync();

            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
            Finish();
        }

        private async Task LoadAsync()
        {
            await DependencyService.InitializeAsync();
            await DependencyService.RegisterCoreAsync();
            await DependencyService.RegisterPlatformSpecificAsync<SQLitePlatformAndroid, SQLiteParameters>();
        }
    }
}