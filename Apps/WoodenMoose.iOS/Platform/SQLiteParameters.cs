using System;
using System.IO;
using WoodenMoose.Core.Platform;

namespace WoodenMoose.iOS.Platform
{
    /// <summary>
    /// iOS implementation of SQLite parameters
    /// </summary>
    public class SQLiteParameters : ISQLiteParameters
    {
        /// <summary>
        /// Retrieve the path where the db file is saved
        /// </summary>
        /// <returns>The path where the db file is saved</returns>
        public string GetPath()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(documentsPath, "..", "Library");
        }
    }
}
