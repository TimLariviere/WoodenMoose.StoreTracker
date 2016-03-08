using System.Threading.Tasks;
using WoodenMoose.Core.Models;

namespace WoodenMoose.Core.Services
{
    public interface IDataService
    {
        Task<JsonData> GetDataAsync();
        Task<bool> SetDataAsync(JsonData data);
    }
}
