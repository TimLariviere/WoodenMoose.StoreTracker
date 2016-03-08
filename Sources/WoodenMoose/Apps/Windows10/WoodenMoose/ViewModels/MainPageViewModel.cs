using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;
using WoodenMoose.ViewModels.PartialViews;

namespace WoodenMoose.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        #region Fields

        private string _applicationId;
        private bool _isApplicationSelected;
        private bool _isMarketSelected;
        private DateTime _lastUpdatedDate;

        #endregion

        #region Injected properties

        [Dependency]
        public ApplicationsViewViewModel ApplicationsViewViewModel { get; set; }

        [Dependency]
        public MarketsViewViewModel MarketsViewViewModel { get; set; }

        [Dependency]
        public DetailViewViewModel DetailViewViewModel { get; set; }

        #endregion

        #region Properties

        public bool IsApplicationSelected
        {
            get { return _isApplicationSelected; }
            set { Set(ref _isApplicationSelected, value); }
        }

        public bool IsMarketSelected
        {
            get { return _isMarketSelected; }
            set { Set(ref _isMarketSelected, value); }
        }

        public DateTime LastUpdatedDate
        {
            get { return _lastUpdatedDate; }
            set { Set(ref _lastUpdatedDate, value); }
        }

        #endregion

        #region Navigation methods

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            LastUpdatedDate = DateTime.Now;
            await ApplicationsViewViewModel.LoadAsync();
        }

        #endregion

        #region Methods

        public async void SelectApplication(string applicationId)
        {
            _applicationId = applicationId;
            IsApplicationSelected = true;
            IsMarketSelected = false;
            await MarketsViewViewModel.LoadAsync(applicationId);
        }

        public async void SelectMarket(string marketId)
        {
            IsMarketSelected = true;
            await DetailViewViewModel.LoadAsync(_applicationId, marketId);
        }

        #endregion
    }
}
