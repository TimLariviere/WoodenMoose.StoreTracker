using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoodenMoose.Core.Models;

namespace WoodenMoose.Core.Repositories.Implementation
{
    /// <summary>
    /// ApplicationMarket repository
    /// </summary>
    public class ApplicationMarketRepository : BaseRepository<ApplicationMarket>, IApplicationMarketRepository
    {
        public ApplicationMarketRepository(List<ApplicationMarket> items) : base(items)
        {
        }

        public override Task<ApplicationMarket> GetAsync(string id)
        {
            return Task.FromResult(Items.FirstOrDefault(i => i.Id == id));
        }

        public Task<ApplicationMarket> GetAsync(string applicationId, string marketId)
        {
            return Task.FromResult(Items.FirstOrDefault(i => i.ApplicationId == applicationId && i.MarketId == marketId));
        }
    }
}
