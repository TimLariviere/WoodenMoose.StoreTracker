using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using WoodenMoose.Core.Models;

namespace WoodenMoose.Core.Repositories
{
    /// <summary>
    /// ApplicationMarket repository
    /// </summary>
    public interface IApplicationMarketRepository : IBaseRepository<ApplicationMarket>
    {
        Task<ApplicationMarket> GetAsync(string applicationId, string marketId);
    }
}
