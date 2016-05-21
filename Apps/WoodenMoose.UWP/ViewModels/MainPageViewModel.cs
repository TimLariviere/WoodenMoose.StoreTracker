using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;
using WoodenMoose.Core.Repositories;

namespace WoodenMoose.UWP.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        #region Fields

        private IApplicationRepository _applicationRepository;

        #endregion

        #region Constructor

        public MainPageViewModel(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;

            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                // design-time experience
            }
            else
            {
                // runtime experience
            }
        }

        #endregion

        #region Properties

        #endregion

        #region Navigation methods

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (state.Any())
            {
                // restore state
                state.Clear();
            }
            else
            {
                // use parameter
            }
            await Task.CompletedTask;
        }

        public override async Task OnNavigatedFromAsync(IDictionary<string, object> state, bool suspending)
        {
            if (suspending)
            {
                // save state
            }
            await Task.CompletedTask;
        }

        #endregion

        #region Methods

        public async void TestSQLite()
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
