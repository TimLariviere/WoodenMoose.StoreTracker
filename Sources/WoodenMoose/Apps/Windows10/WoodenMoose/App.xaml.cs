using Microsoft.Practices.Unity;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using WindowsStoreServices.OAuth;
using WindowsStoreServices.V1;
using WoodenMoose.Core.Repositories;
using WoodenMoose.Core.Repositories.Implementation;
using WoodenMoose.Core.Services;
using WoodenMoose.Core.Services.Implementation;
using WoodenMoose.Services;
using WoodenMoose.Views;

namespace WoodenMoose
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class..
    /// </summary>
    public sealed partial class App
    {
        public readonly IUnityContainer UnityContainer = new UnityContainer();

        public App()
        {
            InitializeComponent();
        }

        public override async Task OnInitializeAsync(IActivatedEventArgs args)
        {
            var dataService = new DataService(new StorageService());
            var data = await dataService.GetDataAsync();
            
            UnityContainer.RegisterType<IAnalyticsClient, AnalyticsClient>();
            UnityContainer.RegisterType<IOAuthClient, OAuthClient>();
            UnityContainer.RegisterType<IAccountRepository, AccountRepository>(new InjectionConstructor(data.Accounts));
            UnityContainer.RegisterType<IApplicationRepository, ApplicationRepository>(new InjectionConstructor(data.Applications));
            UnityContainer.RegisterType<IApplicationMarketRepository, ApplicationMarketRepository>(new InjectionConstructor(data.Markets));
            UnityContainer.RegisterType<IReviewRepository, ReviewRepository>(new InjectionConstructor(data.Reviews));
            UnityContainer.RegisterType<IAccountService, AccountService>();

            var fake = new FakeService();
            await fake.AddFakeAccounts(UnityContainer.Resolve<IAccountRepository>(), UnityContainer.Resolve<IApplicationRepository> (), UnityContainer.Resolve<IApplicationMarketRepository> (), UnityContainer.Resolve<IReviewRepository> ());
        }

        public override async Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
        {
            NavigationService.Navigate(typeof(MainPage));
            await Task.CompletedTask;
        }
    }
}
