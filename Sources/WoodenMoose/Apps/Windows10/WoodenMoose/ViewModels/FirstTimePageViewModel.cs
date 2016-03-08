using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Xaml.Navigation;
using WindowsStoreServices.V1;
using Microsoft.Practices.Unity;
using Template10.Mvvm;
using WoodenMoose.Views;
using WoodenMoose.Core.Services.Interfaces;
using WoodenMoose.Core.Models;
using Windows.UI.Popups;

namespace WoodenMoose.ViewModels
{
    /// <summary>
    /// ViewModel of FirstTimePage
    /// </summary>
    public class FirstTimePageViewModel : ViewModelBase
    {
        #region Fields

        /// <summary>
        /// Tenant Id of the Azure AD
        /// </summary>
        private string _tenantId;

        /// <summary>
        /// Client Id of the Azure AD App account
        /// </summary>
        private string _clientId;

        /// <summary>
        /// Secret Key of the Azure AD App account
        /// </summary>
        private string _secretKey;

        /// <summary>
        /// Resource URL of the Azure AD App account
        /// </summary>
        private string _resource;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class <see cref="FirstTimePageViewModel"/>
        /// </summary>
        public FirstTimePageViewModel()
        {
            GoNext = new DelegateCommand(ExecuteGoNextCommand, CanExecuteGoNextCommand);

            //TenantId = "edddb5c9-e2f2-4e91-90c9-48284f7538e1";
            //ClientId = "4d63ca44-6639-46ae-93e8-6fa47a7327df";
            //SecretKey = "Ji1YWjY/SCUhb2E9WVp2RnFnaT9jJGQwZlRAfVEub3w=";
            //Resource = "http://www.woodenmoose.com";
        }

        #endregion

        #region Injected properties

        [Dependency]
        public IAnalyticsClient AnalyticsService { get; set; }

        [Dependency]
        public IAccountService AccountService { get; set; }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the tenant Id of the Azure AD
        /// </summary>
        public string TenantId
        {
            get { return _tenantId; }
            set
            {
                if (Set(ref _tenantId, value))
                    GoNext.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Gets or sets the client id
        /// </summary>
        public string ClientId
        {
            get { return _clientId; }
            set
            {
                if (Set(ref _clientId, value))
                    GoNext.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Gets or sets the secret key
        /// </summary>
        public string SecretKey
        {
            get { return _secretKey; }
            set
            {
                if (Set(ref _secretKey, value))
                    GoNext.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Gets or sets the resource URL of the Azure AD App account
        /// </summary>
        public string Resource
        {
            get { return _resource; }
            set
            {
                if (Set(ref _resource, value))
                    GoNext.RaiseCanExecuteChanged();
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Gets the GoNext command
        /// </summary>
        public DelegateCommand GoNext { get; }

        #endregion

        #region Command methods

        /// <summary>
        /// GoNext command can be executed only when every fields have been filled
        /// </summary>
        /// <returns>True if every fields have been filled; False otherwise</returns>
        public bool CanExecuteGoNextCommand()
        {
            return !string.IsNullOrEmpty(_tenantId) &&
                   !string.IsNullOrEmpty(_clientId) &&
                   !string.IsNullOrEmpty(_secretKey) &&
                   !string.IsNullOrEmpty(_resource);
        }

        public async void ExecuteGoNextCommand()
        {
            if (TenantId == "StoreTest")
            {
                //await AccountService.CreateFakeAccount("Store Test");
                NavigationService.Navigate(typeof(MainPage));
            }
            else
            {
                var msg = new MessageDialog("Invalid identifiers");
                await msg.ShowAsync();
            }
        }

        public void SkipStep()
        {
            NavigationService.Navigate(typeof(MainPage));
        }

        public async void GetHelp()
        {
            await Launcher.LaunchUriAsync(new Uri("https://msdn.microsoft.com/en-us/windows/uwp/monetize/access-analytics-data-using-windows-store-services#associate-an-azure-ad-application-with-your-windows-dev-center-account", UriKind.Absolute));
        }

        #endregion

        #region Navigation methods

        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (state.Any())
            {
                TenantId = state[nameof(TenantId)] as string;
                ClientId = state[nameof(ClientId)] as string;
                SecretKey = state[nameof(SecretKey)] as string;
                Resource = state[nameof(Resource)] as string;
            }

            return Task.CompletedTask;
        }

        public override Task OnNavigatedFromAsync(IDictionary<string, object> pageState, bool suspending)
        {
            if (suspending)
            {
                pageState[nameof(TenantId)] = _tenantId;
                pageState[nameof(ClientId)] = _clientId;
                pageState[nameof(SecretKey)] = _secretKey;
                pageState[nameof(Resource)] = _resource;
            }

            return base.OnNavigatedFromAsync(pageState, suspending);
        }

        #endregion
    }
}
