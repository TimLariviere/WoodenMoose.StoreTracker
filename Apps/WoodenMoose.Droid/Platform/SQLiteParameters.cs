using System;
using WoodenMoose.Core.Platform;

namespace WoodenMoose.Droid.Platform
{
    /// <summary>
    /// Android implementation of SQLite parameters
    /// </summary>
    public class SQLiteParameters : ISQLiteParameters
    {
        /// <summary>
        /// Retrieve the path where the db file is saved
        /// </summary>
        /// <returns>The path where the db file is saved</returns>
        public string GetPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        }
    }
}