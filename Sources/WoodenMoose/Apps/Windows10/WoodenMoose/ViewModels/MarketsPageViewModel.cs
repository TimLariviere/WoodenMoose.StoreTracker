using Template10.Mvvm;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Practices.Unity;
using WoodenMoose.Core.Repositories;
using WoodenMoose.Helpers;
using WoodenMoose.ViewModels.PartialViews;

namespace WoodenMoose.ViewModels
{
    public class MarketsPageViewModel : ViewModelBase
    {
        #region Fields

        /// <summary>
        /// Identifier of the application
        /// </summary>
        private string _applicationId;

        /// <summary>
        /// Name of the application
        /// </summary>
        private string _applicationName;

        /// <summary>
        /// Background color of the application
        /// </summary>
        private Brush _applicationBackground;

        /// <summary>
        /// Image URL of the application
        /// </summary>
        private string _applicationImageUrl = "https://store-images.s-microsoft.com/image/apps.50574.9007199266245907.9d973991-3e76-4c85-93ee-bbde711eac4c.584c662d-d95b-41b5-81fc-117e169aaac0?w=80&h=80&q=60";

        #endregion

        #region Injected properties

        [Dependency]
        public IApplicationRepository ApplicationRepository { get; set; }

        [Dependency]
        public MarketsViewViewModel MarketsViewViewModel { get; set; }

        #endregion

        #region Properties

        public string ApplicationId
        {
            get { return _applicationId; }
            set { Set(ref _applicationId, value); }
        }

        public string ApplicationName
        {
            get { return _applicationName; }
            set { Set(ref _applicationName, value); }
        }

        public Brush ApplicationBackground
        {
            get { return _applicationBackground; }
            set { Set(ref _applicationBackground, value); }
        }

        public string ApplicationImageUrl
        {
            get { return _applicationImageUrl; }
            set { Set(ref _applicationImageUrl, value); }
        }

        #endregion

        #region Methods

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var applicationId = parameter as string;

            if (!string.IsNullOrEmpty(applicationId))
            {
                await InitializeAsync(applicationId);
                await MarketsViewViewModel.LoadAsync(applicationId);
            }
        }

        public async Task InitializeAsync(string applicationId)
        {
            var application = await ApplicationRepository.GetAsync(applicationId);

            if (application != null)
            {
                ApplicationId = applicationId;
                ApplicationName = application.Name;
                ApplicationBackground = BrushHelper.ColorToBrush(application.Background);
                ApplicationImageUrl = application.ImageUrl;
            }
        }

        #endregion
    }
}
