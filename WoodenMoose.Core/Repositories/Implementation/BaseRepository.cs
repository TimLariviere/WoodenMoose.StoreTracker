using SQLite.Net.Async;
using System.Collections.Generic;
using System.Threading.Tasks;
using WoodenMoose.Core.Entities;
using WoodenMoose.Core.Services;

namespace WoodenMoose.Core.Repositories.Implementation
{
    /// <summary>
    /// Represent the base SQLite implementation of a repository
    /// </summary>
    /// <typeparam name="T">Type of the entity</typeparam>
    public abstract class BaseRepository<T> : IBaseRepository<T>
        where T : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets the SQLite connection
        /// </summary>
        protected SQLiteAsyncConnection Database { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// Create a new entry into the item store, or update the existing entry with the same id
        /// </summary>
        /// <param name="entity">Entity to use</param>
        /// <returns>True if create/update operation succeeded; False otherwise</returns>
        public async Task<bool> CreateOrUpdateAsync(T entity)
        {
            var existingEntity = await Database.Table<T>().Where(x => x.Id == entity.Id)
                                                          .FirstOrDefaultAsync();
            if (existingEntity == null)
            {
                var result = await Database.InsertAsync(entity);
                return result == 1;
            }
            else
            {
                if (existingEntity != entity)
                {
                    await UpdateEntityAsync(existingEntity, entity);
                }

                var result = await Database.UpdateAsync(entity);
                return result == 1;
            }
        }

        /// <summary>
        /// Delete an item based on its id
        /// </summary>
        /// <param name="id">Id to use</param>
        /// <returns>True if delete operation succeeded; False otherwise</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await Database.Table<T>().Where(x => x.Id == id)
                                                  .FirstOrDefaultAsync();
            if (entity == null)
                return false;

            var result = await Database.DeleteAsync<T>(entity);
            return result == 1;
        }

        /// <summary>
        /// Retrieve all items
        /// </summary>
        /// <returns>An enumeration of all items</returns>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Database.Table<T>().ToListAsync();
        }

        /// <summary>
        /// Retrieve an item based on its id
        /// </summary>
        /// <param name="id">Id to use</param>
        /// <returns>The retrieved item</returns>
        public async Task<T> GetAsync(int id)
        {
            return await Database.Table<T>().Where(x => x.Id == id)
                                            .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Initialize the repository
        /// </summary>
        /// <returns>True if initialization operation succeeded; False otherwise</returns>
        public async Task<bool> InitializeAsync()
        {
            Database = await SQLiteService.GetConnectionAsync();
            var result = await Database.CreateTableAsync<ApplicationEntity>();
            return result.Results.ContainsKey(typeof(T)) && result.Results[typeof(T)] == 1;
        }

        /// <summary>
        /// Update the existing entity with the new entity
        /// </summary>
        /// <param name="existingEntity">Existing entity</param>
        /// <param name="entity">Entity used to update</param>
        /// <returns></returns>
        protected abstract Task UpdateEntityAsync(T existingEntity, T entity);

        #endregion
    }
}
