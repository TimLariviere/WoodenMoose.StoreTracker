using System;
using System.IO;
using WoodenMoose.Core.Platform;

namespace WoodenMoose.iOS.Platform
{
    public class SQLite_iOS : ISQLite
    {
        public string GetPath()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(documentsPath, "..", "Library");
        }
    }
}
