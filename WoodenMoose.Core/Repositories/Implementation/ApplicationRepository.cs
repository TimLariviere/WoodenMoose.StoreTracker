using System.Threading.Tasks;
using WoodenMoose.Core.Entities;
using WoodenMoose.Core.Utilities;

namespace WoodenMoose.Core.Repositories.Implementation
{
    /// <summary>
    /// Represent the SQLite implementation of ApplicationRepository
    /// </summary>
    public class ApplicationRepository : BaseRepository<ApplicationEntity>, IApplicationRepository
    {
        #region Methods

        /// <summary>
        /// Update the existing entity with the new entity
        /// </summary>
        /// <param name="existingEntity">Existing entity</param>
        /// <param name="entity">Entity used to update</param>
        /// <returns></returns>
        protected override Task UpdateEntityAsync(ApplicationEntity existingEntity, ApplicationEntity entity)
        {
            existingEntity.AppleStoreId = entity.AppleStoreId;
            existingEntity.GooglePlayStoreId = entity.GooglePlayStoreId;
            existingEntity.LogoBackgroundColor = entity.LogoBackgroundColor;
            existingEntity.LogoUrl = entity.LogoUrl;
            existingEntity.Name = entity.Name;
            existingEntity.WindowsStoreId = entity.WindowsStoreId;
            return TaskUtilities.CompletedTask;
        }

        #endregion
    }
}
