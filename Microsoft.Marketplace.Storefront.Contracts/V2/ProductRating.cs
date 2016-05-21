namespace Microsoft.Marketplace.Storefront.Contracts.V2
{
    public class ProductRating
    {
        public string RatingSystem { get; set; }
        public string RatingSystemId { get; set; }
        public string RatingSystemUrl { get; set; }
        public string RatingValue { get; set; }
        public string RatingId { get; set; }
        public string RatingValueLogoUrl { get; set; }
        public int RatingAge { get; set; }
        public bool RestrictMetadata { get; set; }
        public bool RestrictPurchase { get; set; }
        public object RatingDescriptors { get; set; }
        public object RatingDescriptorLogoUrls { get; set; }
        public object[] RatingDisclamers { get; set; }
        public string LongName { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
    }
}
