using System.Threading.Tasks;

namespace WoodenMoose.Core.Services
{
    public interface IStorageService
    {
        Task<string> GetDataAsync();
        Task<bool> SetDataAsync(string data);
    }
}
