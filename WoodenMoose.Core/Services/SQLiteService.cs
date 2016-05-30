using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Interop;
using System;
using System.IO;
using System.Threading.Tasks;
using WoodenMoose.Core.Platform;

namespace WoodenMoose.Core.Services
{
    /// <summary>
    /// SQLite service
    /// </summary>
    public static class SQLiteService
    {
        /// <summary>
        /// SQLite db file name
        /// </summary>
        private const string Filename = "WoodenMoose.db3";

        /// <summary>
        /// SQLite connection
        /// </summary>
        private static SQLiteAsyncConnection _connection;

        /// <summary>
        /// Retrieve the current connection to the SQLite database, create it otherwise
        /// </summary>
        /// <returns>A SQLite connection</returns>
        public static async Task<SQLiteAsyncConnection> GetConnectionAsync()
        {
            if (_connection != null)
                return _connection;

            var sqlitePlatform = await DependencyService.ResolveAsync<ISQLitePlatform>();
            var sqlite = await DependencyService.ResolveAsync<ISQLiteParameters>();

            var path = Path.Combine(sqlite.GetPath(), Filename);
            var connectionFactory = new Func<SQLiteConnectionWithLock>(() => new SQLiteConnectionWithLock(sqlitePlatform, new SQLiteConnectionString(path, storeDateTimeAsTicks: false)));
            return _connection ?? (_connection = new SQLiteAsyncConnection(connectionFactory));
        }
    }
}
