using System;
using WoodenMoose.Core.Platform;

namespace WoodenMoose.Droid.Platform
{
    public class SQLite_Android : ISQLite
    {
        public string GetPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        }
    }
}