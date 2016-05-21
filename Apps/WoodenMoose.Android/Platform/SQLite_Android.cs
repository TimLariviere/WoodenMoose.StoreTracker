using System;
using WoodenMoose.Core.Platform;

namespace WoodenMoose.Android.Plaftorm
{
    public class SQLite_Android : ISQLite
    {
        public string GetPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        }
    }
}