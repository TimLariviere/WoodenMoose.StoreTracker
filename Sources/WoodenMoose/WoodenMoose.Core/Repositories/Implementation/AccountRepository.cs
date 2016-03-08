using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoodenMoose.Core.Models;

namespace WoodenMoose.Core.Repositories.Implementation
{
    /// <summary>
    /// Account repository
    /// </summary>
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(List<Account> items) : base(items)
        {
        }

        public override Task<Account> GetAsync(string id)
        {
            return Task.FromResult(Items.FirstOrDefault(i => i.Id == id));
        }
    }
}
