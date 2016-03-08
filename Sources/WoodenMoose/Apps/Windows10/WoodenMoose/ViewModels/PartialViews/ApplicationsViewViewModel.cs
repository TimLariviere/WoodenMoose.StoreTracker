using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Template10.Mvvm;
using WoodenMoose.Core.Models;
using WoodenMoose.Core.Repositories;
using WoodenMoose.Core.Services.Implementation;
using WoodenMoose.Helpers;
using WoodenMoose.ViewModels.UserControls;

namespace WoodenMoose.ViewModels.PartialViews
{
    /// <summary>
    /// ViewModel of ApplicationsView
    /// </summary>
    public class ApplicationsViewViewModel : ViewModelBase
    {
        #region Fields

        /// <summary>
        /// Accounts list
        /// </summary>
        private List<Account> _accounts = new List<Account>();

        #endregion

        #region Injected properties

        /// <summary>
        /// Gets or sets the account repository
        /// </summary>
        [Dependency]
        public IAccountRepository AccountRepository { get; set; }

        /// <summary>
        /// Gets or sets the application repository
        /// </summary>
        [Dependency]
        public IApplicationRepository ApplicationRepository { get; set; }

        /// <summary>
        /// Gets or sets the ApplicationMarket repository
        /// </summary>
        [Dependency]
        public IApplicationMarketRepository ApplicationMarketRepository { get; set; }

        /// <summary>
        /// Gets or sets the Review repository
        /// </summary>
        [Dependency]
        public IReviewRepository ReviewRepository { get; set; }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the accounts
        /// </summary>
        public List<Account> Accounts
        {
            get { return _accounts; }
            set
            {
                if (Set(ref _accounts, value))
                {
                    RaisePropertyChanged(() => Applications);
                }
            }
        }

        /// <summary>
        /// Gets the grouped list of applications
        /// </summary>
        public List<IGrouping<Account, ApplicationUserControlViewModel>> Applications
        {
            get
            {
                return _accounts.SelectMany(acc => acc.LinkedApplications, (acc, app) => new { Account = acc, Application = app })
                                .GroupBy(a => a.Account, a => a.Application.ToViewModel())
                                .OrderBy(a => a.Key.Name)
                                .ToList();
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Loads the data
        /// </summary>
        public async Task LoadAsync()
        {
            var accounts = await AccountRepository.GetAllAsync();
            Accounts = new List<Account>(accounts);
        }

        #endregion
    }
}
