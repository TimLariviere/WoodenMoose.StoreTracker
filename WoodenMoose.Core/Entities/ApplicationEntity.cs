namespace WoodenMoose.Core.Entities
{
    /// <summary>
    /// Represents an application
    /// </summary>
    public class ApplicationEntity
    {
        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        public int Id { get; set; }

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
    }
}
