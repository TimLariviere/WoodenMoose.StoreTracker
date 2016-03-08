using System;
using System.Threading.Tasks;
using WindowsStoreServices.OAuth;
using WoodenMoose.Core.Models;
using WoodenMoose.Core.Repositories;

namespace WoodenMoose.Core.Services.Implementation
{
    /// <summary>
    /// Account service
    /// </summary>
    public class AccountService : IAccountService
    {
        #region Fields

        /// <summary>
        /// Account repository
        /// </summary>
        private IAccountRepository _accountRepository;

        /// <summary>
        /// OAuth client
        /// </summary>
        private IOAuthClient _oAuthClient;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the class <see cref="AccountService"/>
        /// </summary>
        /// <param name="accountRepository">Account repository</param>
        /// <param name="oAuthClient">OAuth client</param>
        public AccountService(IAccountRepository accountRepository, IOAuthClient oAuthClient)
        {
            _accountRepository = accountRepository;
            _oAuthClient = oAuthClient;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Log in an account and add it to the list of connected accounts
        /// </summary>
        /// <param name="tenantId">Active Directory Tenant Id</param>
        /// <param name="clientId">Client Id of the Azure AD App</param>
        /// <param name="secretKey">Secret Key of the Azure AD App</param>
        /// <returns>The created Account entity</returns>
        public async Task<Account> LoginAsync(string tenantId, string clientId, string secretKey)
        {
            if (string.IsNullOrEmpty(tenantId) ||
                string.IsNullOrEmpty(clientId) ||
                string.IsNullOrEmpty(secretKey))
            {
                return null;
            }

            try
            {
                var token = await _oAuthClient.GetTokenAsync(tenantId, clientId, secretKey);
                if (token == null)
                {
                    return null;
                }

                var account = new Account()
                {
                    Name = tenantId,
                    TenantId = tenantId,
                    ClientId = clientId,
                    SecretKey = secretKey,
                    AccessToken = token.AccessToken,
                    AccessTokenExpirationDate = DateTime.Now.Add(token.ExpiresIn)
                };

                var isAdded = await _accountRepository.AddAsync(account);
                return isAdded ? account : null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Renew the account's access token
        /// </summary>
        /// <param name="account">Account which needs a renewed access token</param>
        /// <returns>The account with its renewed access token</returns>
        public async Task<Account> RenewLoginAsync(Account account)
        {
            var token = await _oAuthClient.GetTokenAsync(account.TenantId, account.ClientId, account.SecretKey);
            account.AccessToken = token.AccessToken;
            account.AccessTokenExpirationDate = DateTime.Now.Add(token.ExpiresIn);
            return account;
        }

        #endregion
    }
}
