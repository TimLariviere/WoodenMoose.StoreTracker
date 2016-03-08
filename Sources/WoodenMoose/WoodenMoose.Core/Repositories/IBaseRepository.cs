using System.Threading.Tasks;

namespace WoodenMoose.Core.Repositories
{
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item">Item to add</param>
        /// <returns>True if the item has been added; False otherwise</returns>
        Task<bool> AddAsync(T item);

        /// <summary>
        /// Indicates whether the item is already present
        /// </summary>
        /// <param name="item">Item to check</param>
        /// <returns>True if the item is already present; False otherwise</returns>
        Task<bool> ContainsAsync(T item);

        /// <summary>
        /// Get all the saved items
        /// </summary>
        /// <returns>An array containing all items</returns>
        Task<T[]> GetAllAsync();

        /// <summary>
        /// Get an item by its id
        /// </summary>
        /// <param name="id">Id to find</param>
        /// <returns>The item</returns>
        Task<T> GetAsync(string id);

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item">Item to update</param>
        /// <returns>True if the item has been updated; False otherwise</returns>
        Task<bool> UpdateAsync(T item);

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item">Item to remove</param>
        /// <returns>True if the item has been removed; False otherwise</returns>
        Task<bool> RemoveAsync(T item);
    }
}
