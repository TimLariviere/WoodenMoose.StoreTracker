using Windows.Storage;
using WoodenMoose.Core.Platform;

namespace WoodenMoose.UWP.Platform
{
    public class SQLite_Windows : ISQLite
    {
        public string GetPath()
        {
            return ApplicationData.Current.LocalFolder.Path;
        }
    }
}
