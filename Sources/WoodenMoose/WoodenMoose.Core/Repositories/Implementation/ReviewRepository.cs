using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoodenMoose.Core.Models;

namespace WoodenMoose.Core.Repositories.Implementation
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(List<Review> items) : base(items)
        {
        }

        public override Task<Review> GetAsync(string id)
        {
            return Task.FromResult(Items.FirstOrDefault(i => i.Id == id));
        }

        public Task<Review[]> GetForApplicationMarketAsync(string applicationMarketId)
        {
            return Task.FromResult(Items.Where(i => i.ApplicationMarketId == applicationMarketId).ToArray());
        }
    }
}
