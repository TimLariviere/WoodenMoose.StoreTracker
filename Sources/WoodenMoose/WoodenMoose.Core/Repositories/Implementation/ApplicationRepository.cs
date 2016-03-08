using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoodenMoose.Core.Models;

namespace WoodenMoose.Core.Repositories.Implementation
{
    /// <summary>
    /// Application repository
    /// </summary>
    public class ApplicationRepository : BaseRepository<Application>, IApplicationRepository
    {
        public ApplicationRepository(List<Application> items) : base(items)
        {
        }

        public override Task<Application> GetAsync(string id)
        {
            return Task.FromResult(Items.FirstOrDefault(i => i.Id == id));
        }
    }
}
