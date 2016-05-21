using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Interop;
using System;
using System.IO;
using System.Threading.Tasks;
using WoodenMoose.Core.Platform;

namespace WoodenMoose.Core.Services
{
    public static class SQLiteService
    {
        private const string FILENAME = "WoodenMoose.db3";
        private static SQLiteAsyncConnection Connection = null;

        public static async Task<SQLiteAsyncConnection> GetConnectionAsync()
        {
            if (Connection != null)
                return Connection;

            var sqlitePlatform = await DependencyService.ResolveAsync<ISQLitePlatform>();
            var sqlite = await DependencyService.ResolveAsync<ISQLite>();

            var path = Path.Combine(sqlite.GetPath(), FILENAME);
            var connectionFactory = new Func<SQLiteConnectionWithLock>(() => new SQLiteConnectionWithLock(sqlitePlatform, new SQLiteConnectionString(path, storeDateTimeAsTicks: false)));
            return Connection ?? (Connection = new SQLiteAsyncConnection(connectionFactory));
        }
    }
}
