namespace WoodenMoose.Core.Platform
{
    /// <summary>
    /// Describe the platform specific parameters for SQLite
    /// </summary>
    public interface ISQLiteParameters
    {
        /// <summary>
        /// Retrieve the path where the db file is saved
        /// </summary>
        /// <returns>The path where the db file is saved</returns>
        string GetPath();
    }
}
