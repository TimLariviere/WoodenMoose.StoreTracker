using SQLite.Net.Attributes;
using System;
using WoodenMoose.Core.Enums;

namespace WoodenMoose.Core.Entities
{
    /// <summary>
    /// Represents a review
    /// </summary>
    public class ReviewEntity
    {
        /// <summary>
        /// Gets or sets the identifier of the review
        /// </summary>
        [PrimaryKey]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the application
        /// </summary>
        public int ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets the store
        /// </summary>
        public StoreType Store { get; set; }

        /// <summary>
        /// Gets or sets the market
        /// </summary>
        public string Market { get; set; }

        /// <summary>
        /// Gets or sets the store-internal review identifier
        /// </summary>
        public string StoreReviewId { get; set; }

        /// <summary>
        /// Gets or sets the submission date (UTC)
        /// </summary>
        public DateTime SubmittedDateTimeUtc { get; set; }
        
        /// <summary>
        /// Gets or sets the reviewer name
        /// </summary>
        public string ReviewerName { get; set; }

        /// <summary>
        /// Gets or sets the rating
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// Gets or sets the title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the text
        /// </summary>
        public string Text { get; set; }
    }
}
