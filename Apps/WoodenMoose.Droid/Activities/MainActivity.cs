using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using SQLite.Net.Platform.XamarinAndroid;
using System;
using WoodenMoose.Core.Repositories;
using WoodenMoose.Core.Services;
using WoodenMoose.Droid.Platform;

namespace WoodenMoose.Droid.Activities
{
    [Activity(Label = "MyApp", Theme = "@android:style/Theme.Holo",
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Activity
    {
        #region Fields

        private IApplicationRepository _applicationRepository;

        #endregion

        #region Methods

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            DependencyService.InitializeAsync().GetAwaiter().GetResult();
            DependencyService.RegisterCoreAsync().GetAwaiter().GetResult();
            DependencyService.RegisterPlatformSpecificAsync<SQLitePlatformAndroid, SQLite_Android>().GetAwaiter().GetResult();

            _applicationRepository = DependencyService.Resolve<IApplicationRepository>();

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += OnButtonClicked;
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            var result = await _applicationRepository.InitializeAsync();
            var all = await _applicationRepository.GetAllAsync();
            result = await _applicationRepository.CreateOrUpdateAsync(new Core.Entities.ApplicationEntity()
            {
                Name = "Bibliovore"
            });
        }

        #endregion
    }
}

