using Windows.ApplicationModel.Resources.Core;

namespace WoodenMoose.Helpers
{
    /// <summary>
    /// Resource files
    /// </summary>
    public enum ResourcesFileEnum
    {
        /// <summary>
        /// Global resources
        /// </summary>
        Resources,

        /// <summary>
        /// Resources for countries
        /// </summary>
        CountriesResources,

        /// <summary>
        /// Resources for messages
        /// </summary>
        MessagesResources
    }

    /// <summary>
    /// Helper for accessing Resources
    /// </summary>
    public static class ResourceHelper
    {
        /// <summary>
        /// Get the string associated to the key in the default resource file
        /// </summary>
        /// <param name="key">Key to lookup</param>
        /// <returns>The text retrieved</returns>
        public static string GetString(string key)
        {
            return GetString(key, ResourcesFileEnum.Resources);
        }

        /// <summary>
        /// Get the string associated to the key in a resource file
        /// </summary>
        /// <param name="key">Key to lookup</param>
        /// <param name="file">File to search in</param>
        /// <returns>The text retrieved</returns>
        public static string GetString(string key, ResourcesFileEnum file)
        {
            var fileName = GetResourceFileName(file);
            return GetStringFromResourceFile(key, fileName);
        }

        /// <summary>
        /// Get the string associated to the key in the specified resource file
        /// </summary>
        /// <param name="key">Key to lookup</param>
        /// <param name="fileName">File to search in</param>
        /// <returns></returns>
        public static string GetStringFromResourceFile(string key, string fileName)
        {
            var resourceContext = new ResourceContext();
            var resourceManager = ResourceManager.Current.MainResourceMap;

            return resourceManager.GetSubtree(fileName).GetValue(key, resourceContext).ValueAsString;
        }

        /// <summary>
        /// Get the file name based on the enumeration
        /// </summary>
        /// <param name="file">File type</param>
        /// <returns>File name</returns>
        private static string GetResourceFileName(ResourcesFileEnum file)
        {
            switch (file)
            {
                case ResourcesFileEnum.Resources:
                    return "Resources";
                case ResourcesFileEnum.CountriesResources:
                    return "CountriesResources";
                case ResourcesFileEnum.MessagesResources:
                    return "MessagesResources";
            }

            return null;
        }
    }
}
