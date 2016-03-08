using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using WoodenMoose.Core.Services;

namespace WoodenMoose.Services
{
    public class StorageService : IStorageService
    {
        private const string DataFileName = "data.json";

        public async Task<string> GetDataAsync()
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            var dataFile = await localFolder.TryGetItemAsync(DataFileName);
            var data = dataFile != null
                ? await FileIO.ReadTextAsync(dataFile as IStorageFile, UnicodeEncoding.Utf16LE)
                : null;

            return data;
        }

        public async Task<bool> SetDataAsync(string data)
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            var dataFile = await localFolder.CreateFileAsync(DataFileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(dataFile, data);
            return true;
        }
    }
}
