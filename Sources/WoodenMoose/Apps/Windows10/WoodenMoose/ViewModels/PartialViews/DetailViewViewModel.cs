using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Template10.Mvvm;

namespace WoodenMoose.ViewModels.PartialViews
{
    public class DetailViewViewModel : ViewModelBase
    {
        #region Injected properties

        [Dependency]
        public SummaryViewViewModel SummaryViewViewModel { get; set; }

        [Dependency]
        public ReviewsViewViewModel ReviewsViewViewModel { get; set; }

        #endregion

        #region Methods

        public async Task LoadAsync(string applicationId, string marketId)
        {
            await SummaryViewViewModel.LoadAsync(applicationId, marketId);
            await ReviewsViewViewModel.LoadAsync(applicationId, marketId);
        }

        #endregion
    }
}
