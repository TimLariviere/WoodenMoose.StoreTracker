using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Practices.Unity;
using Template10.Mvvm;
using WoodenMoose.Core.Repositories;
using WoodenMoose.Helpers;
using WoodenMoose.ViewModels.PartialViews;

namespace WoodenMoose.ViewModels
{
    public class DetailPageViewModel : ViewModelBase
    {
        #region Fields

        private string _applicationId;
        private string _marketId;
        private string _applicationImageUrl = "https://store-images.s-microsoft.com/image/apps.50574.9007199266245907.9d973991-3e76-4c85-93ee-bbde711eac4c.584c662d-d95b-41b5-81fc-117e169aaac0?w=80&h=80&q=60";
        private Brush _applicationBackground;
        private string _marketName;

        #endregion

        #region Injected properties

        [Dependency]
        public IApplicationRepository ApplicationRepository { get; set; }

        [Dependency]
        public DetailViewViewModel DetailViewViewModel { get; set; }

        #endregion

        #region Properties

        public string ApplicationId
        {
            get { return _applicationId; }
            set { Set(ref _applicationId, value); }
        }

        public string MarketId
        {
            get { return _marketId; }
            set { Set(ref _marketId, value); }
        }

        public string ApplicationImageUrl
        {
            get { return _applicationImageUrl; }
            set { Set(ref _applicationImageUrl, value); }
        }

        public Brush ApplicationBackground
        {
            get { return _applicationBackground; }
            set { Set(ref _applicationBackground, value); }
        }

        public string MarketName
        {
            get { return _marketName; }
            set { Set(ref _marketName, value); }
        }

        #endregion

        #region Navigation methods

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var param = (parameter as string).Split('|');
            await InitializeAsync(param[0], param[1]);
            await DetailViewViewModel.LoadAsync(param[0], param[1]);
        }

        public async Task InitializeAsync(string applicationId, string marketId)
        {
            ApplicationId = _applicationId;
            MarketId = _marketId;
            MarketName = ResourceHelper.GetString(marketId, ResourcesFileEnum.CountriesResources);

            var application = await ApplicationRepository.GetAsync(applicationId);
            if (application != null)
            {
                ApplicationBackground = BrushHelper.ColorToBrush(application.Background);
                ApplicationImageUrl = application.ImageUrl;
            }
        }

        #endregion
    }
}
