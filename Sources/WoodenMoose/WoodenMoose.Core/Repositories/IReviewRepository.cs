using System.Threading.Tasks;
using WoodenMoose.Core.Models;

namespace WoodenMoose.Core.Repositories
{
    public interface IReviewRepository : IBaseRepository<Review>
    {
        Task<Review[]> GetForApplicationMarketAsync(string applicationMarketId);
    }
}
