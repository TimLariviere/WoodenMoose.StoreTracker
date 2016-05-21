using Microsoft.Practices.Unity;
using SQLite.Net.Interop;
using System.Threading.Tasks;
using WoodenMoose.Core.Platform;
using WoodenMoose.Core.Repositories;
using WoodenMoose.Core.Repositories.Implementation;
using WoodenMoose.Core.Utilities;

namespace WoodenMoose.Core.Services
{
    /// <summary>
    /// Service handling dependency injection
    /// </summary>
    public static class DependencyService
    {
        /// <summary>
        /// Unity container
        /// </summary>
        private static IUnityContainer UnityContainer;
        
        /// <summary>
        /// Initialize the dependency service
        /// </summary>
        /// <returns></returns>
        public static Task InitializeAsync()
        {
            UnityContainer = new UnityContainer();
            return TaskUtilities.CompletedTask;
        }

        /// <summary>
        /// Register all platform specific implementations available within the Core namespace
        /// </summary>
        /// <typeparam name="TSQLitePlatform">Implementation of platform-specific SQLitePlatform</typeparam>
        /// <typeparam name="TSQLite">Implementation of platform-specific SQLite</typeparam>
        /// <returns></returns>
        public static Task RegisterPlatformSpecificAsync<TSQLitePlatform, TSQLite>()
            where TSQLitePlatform : ISQLitePlatform
            where TSQLite : ISQLite, new()
        {
            UnityContainer.RegisterType<ISQLitePlatform, TSQLitePlatform>();
            UnityContainer.RegisterType<ISQLite, TSQLite>();
            return TaskUtilities.CompletedTask;
        }

        /// <summary>
        /// Register all implementations available within the Core namespace
        /// </summary>
        /// <returns></returns>
        public static Task RegisterCoreAsync()
        {
            UnityContainer.RegisterType<IApplicationRepository, ApplicationRepository>();
            UnityContainer.RegisterType<IReviewRepository, ReviewRepository>();
            return TaskUtilities.CompletedTask;
        }

        /// <summary>
        /// Register a type mapping
        /// </summary>
        /// <typeparam name="TFrom"><see cref="System.Type"/> that will be requested.</typeparam>
        /// <typeparam name="TTo"><see cref="System.Type"/> that will actually be returned.</typeparam>
        /// <returns></returns>
        public static Task RegisterTypeAsync<TFrom, TTo>()
            where TTo : TFrom, new()
        {
            UnityContainer.RegisterType<TFrom, TTo>();
            return TaskUtilities.CompletedTask;
        }

        /// <summary>
        /// Resolve an instance of the default requested type
        /// </summary>
        /// <typeparam name="T"><see cref="System.Type"/> of object to get.</typeparam>
        /// <returns>The retrieved object</returns>
        public static T Resolve<T>()
        {
            return UnityContainer.Resolve<T>();
        }

        /// <summary>
        /// Resolve an instance of the default requested type
        /// </summary>
        /// <typeparam name="T"><see cref="System.Type"/> of object to get.</typeparam>
        /// <returns>The retrieved object</returns>
        public static Task<T> ResolveAsync<T>()
        {
            return Task.FromResult(Resolve<T>());
        }
    }
}
