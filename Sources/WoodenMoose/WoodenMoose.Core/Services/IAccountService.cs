using System.Threading.Tasks;
using WoodenMoose.Core.Models;

namespace WoodenMoose.Core.Services
{
    /// <summary>
    /// Account service
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Log in an account and add it to the list of connected accounts
        /// </summary>
        /// <param name="tenantId">Active Directory Tenant Id</param>
        /// <param name="clientId">Client Id of the Azure AD App</param>
        /// <param name="secretKey">Secret Key of the Azure AD App</param>
        /// <returns>The created Account entity</returns>
        Task<Account> LoginAsync(string tenantId, string clientId, string secretKey);

        /// <summary>
        /// Renew the account's access token
        /// </summary>
        /// <param name="account">Account which needs a renewed access token</param>
        /// <returns>The account with its renewed access token</returns>
        Task<Account> RenewLoginAsync(Account account);
    }
}
