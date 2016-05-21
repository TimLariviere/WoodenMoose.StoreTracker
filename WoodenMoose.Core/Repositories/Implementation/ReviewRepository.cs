using System.Threading.Tasks;
using WoodenMoose.Core.Entities;
using WoodenMoose.Core.Utilities;

namespace WoodenMoose.Core.Repositories.Implementation
{
    /// <summary>
    /// Represent the SQLite implementation of ReviewRepository
    /// </summary>
    public class ReviewRepository : BaseRepository<ReviewEntity>, IReviewRepository
    {
        #region Methods

        /// <summary>
        /// Update the existing entity with the new entity
        /// </summary>
        /// <param name="existingEntity">Existing entity</param>
        /// <param name="entity">Entity used to update</param>
        /// <returns></returns>
        protected override Task UpdateEntityAsync(ReviewEntity existingEntity, ReviewEntity entity)
        {
            existingEntity.ApplicationId = entity.ApplicationId;
            existingEntity.Market = entity.Market;
            existingEntity.Rating = entity.Rating;
            existingEntity.ReviewerName = entity.ReviewerName;
            existingEntity.Store = entity.Store;
            existingEntity.StoreReviewId = entity.StoreReviewId;
            existingEntity.SubmittedDateTimeUtc = entity.SubmittedDateTimeUtc;
            existingEntity.Text = entity.Text;
            existingEntity.Title = entity.Title;
            return TaskUtilities.CompletedTask;
        }

        #endregion
    }
}
