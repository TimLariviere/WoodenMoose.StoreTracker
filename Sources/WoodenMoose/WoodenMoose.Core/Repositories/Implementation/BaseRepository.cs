using System.Collections.Generic;
using System.Threading.Tasks;

namespace WoodenMoose.Core.Repositories.Implementation
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
    {
        /// <summary>
        /// List of items
        /// </summary>
        protected List<T> Items { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{T}"/> class
        /// </summary>
        /// <param name="items">Data source</param>
        protected BaseRepository(List<T> items)
        {
            Items = items;
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item">Item to add</param>
        /// <returns>True if the item has been added; False otherwise</returns>
        public Task<bool> AddAsync(T item)
        {
            if (item == null)
                return Task.FromResult(false);

            if (Items.Contains(item))
                return Task.FromResult(false);

            Items.Add(item);
            return Task.FromResult(true);
        }

        /// <summary>
        /// Indicates whether the item is already present
        /// </summary>
        /// <param name="item">Item to check</param>
        /// <returns>True if the item is already present; False otherwise</returns>
        public Task<bool> ContainsAsync(T item)
        {
            return Task.FromResult(Items.Contains(item));
        }

        /// <summary>
        /// Get all the items
        /// </summary>
        /// <returns>An array containing all items</returns>
        public Task<T[]> GetAllAsync()
        {
            return Task.FromResult(Items.ToArray());
        }

        /// <summary>
        /// Get an item by its id
        /// </summary>
        /// <param name="id">Id to find</param>
        /// <returns>The item</returns>
        public abstract Task<T> GetAsync(string id);

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item">Item to update</param>
        /// <returns>True if the item has been updated; False otherwise</returns>
        public Task<bool> RemoveAsync(T item)
        {
            if (!Items.Contains(item))
                return Task.FromResult(false);

            var result = Items.Remove(item);
            return Task.FromResult(result);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item">Item to remove</param>
        /// <returns>True if the item has been removed; False otherwise</returns>
        public Task<bool> UpdateAsync(T item)
        {
            // We can only check if the item to update is part of the list
            // because we can't update anything as we use references
            if (!Items.Contains(item))
                return Task.FromResult(false);

            return Task.FromResult(true);
        }
    }
}
