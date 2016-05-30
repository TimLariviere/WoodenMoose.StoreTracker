using Windows.Storage;
using WoodenMoose.Core.Platform;

namespace WoodenMoose.UWP.Platform
{
    /// <summary>
    /// Windows implementation of SQLite parameters
    /// </summary>
    public class SQLiteParameters : ISQLiteParameters
    {
        /// <summary>
        /// Retrieve the path where the db file is saved
        /// </summary>
        /// <returns>The path where the db file is saved</returns>
        public string GetPath()
        {
            return ApplicationData.Current.LocalFolder.Path;
        }
    }
}
