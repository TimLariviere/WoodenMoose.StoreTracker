using SQLite.Net.Attributes;

namespace WoodenMoose.Core.Entities
{
    /// <summary>
    /// Represents an application
    /// </summary>
    public class ApplicationEntity : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the logo background color in hexadecimal
        /// </summary>
        public string LogoBackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the URL of the logo
        /// </summary>
        public string LogoUrl { get; set; }

        /// <summary>
        /// Gets or sets the application identifier on the Apple Store
        /// </summary>
        public string AppleStoreId { get; set; }

        /// <summary>
        /// Gets or sets the application identifier on the Google Play Store
        /// </summary>
        public string GooglePlayStoreId { get; set; }

        /// <summary>
        /// Gets or sets the application identifier on the Windows Store
        /// </summary>
        public string WindowsStoreId { get; set; }
    }
}
