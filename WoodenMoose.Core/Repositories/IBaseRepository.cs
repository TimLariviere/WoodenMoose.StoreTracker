using System.Collections.Generic;
using System.Threading.Tasks;
using WoodenMoose.Core.Entities;

namespace WoodenMoose.Core.Repositories
{
    /// <summary>
    /// Describe the base repository
    /// </summary>
    /// <typeparam name="T">Type of the entity</typeparam>
    public interface IBaseRepository<T>
        where T : BaseEntity
    {
        /// <summary>
        /// Initialize the repository
        /// </summary>
        /// <returns>True if initialization operation succeeded; False otherwise</returns>
        Task<bool> InitializeAsync();

        /// <summary>
        /// Create a new entry into the item store, or update the existing entry with the same id
        /// </summary>
        /// <param name="entity">Entity to use</param>
        /// <returns>True if create/update operation succeeded; False otherwise</returns>
        Task<bool> CreateOrUpdateAsync(T entity);

        /// <summary>
        /// Retrieve an item based on its id
        /// </summary>
        /// <param name="id">Id to use</param>
        /// <returns>The retrieved item</returns>
        Task<T> GetAsync(int id);

        /// <summary>
        /// Retrieve all items
        /// </summary>
        /// <returns>An enumeration of all items</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Delete an item based on its id
        /// </summary>
        /// <param name="id">Id to use</param>
        /// <returns>True if delete operation succeeded; False otherwise</returns>
        Task<bool> DeleteAsync(int id);
    }
}
