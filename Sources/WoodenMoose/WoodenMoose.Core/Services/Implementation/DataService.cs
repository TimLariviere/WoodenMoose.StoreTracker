using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using WoodenMoose.Core.Models;

namespace WoodenMoose.Core.Services.Implementation
{
    public class DataService : IDataService
    {
        private readonly IStorageService _storageService;

        public DataService(IStorageService storageService)
        {
            _storageService = storageService;
        }

        public async Task<JsonData> GetDataAsync()
        {
            var json = await _storageService.GetDataAsync();
            var data = json != null ? JsonConvert.DeserializeObject<JsonData>(json) : new JsonData();

            foreach (var account in data.Accounts)
            {
                account.LinkedApplications = (from application in data.Applications
                                             from accountToApplication in data.AccountToApplicationLinks
                                             where accountToApplication.AccountId == account.Id && accountToApplication.ApplicationId == application.Id
                                             select application).ToArray();
            }

            foreach (var application in data.Applications)
            {
                application.Markets = data.Markets.Where(m => m.ApplicationId == application.Id).ToArray();
            }

            foreach (var applicationMarket in data.Markets)
            {
                applicationMarket.Reviews = data.Reviews.Where(r => r.ApplicationMarketId == applicationMarket.Id).ToArray();
            }

            return data;
        }

        public async Task<bool> SetDataAsync(JsonData data)
        {
            var json = JsonConvert.SerializeObject(data);
            return await _storageService.SetDataAsync(json);
        }
    }
}
