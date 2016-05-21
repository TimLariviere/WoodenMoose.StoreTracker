using Microsoft.Marketplace.Storefront.Contracts.V2;

namespace Microsoft.Marketplace.Storefront.Contracts.V3
{
    public class ProductSummary
    {
        public string[] Categories { get; set; }
        public ImageItem[] Images { get; set; }
        public string ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PublisherName { get; set; }
        public string PublisherId { get; set; }
        public bool IsUniversal { get; set; }
        public string Language { get; set; }
        public double Price { get; set; }
        public string DisplayPrice { get; set; }
        public MediaType MediaType { get; set; }
        public string PackageFamilyName { get; set; }
        public string XapPackageFamilyName { get; set; }
        public string[] PackageFamilyNames { get; set; }
        public string SubcategoryName { get; set; }
        public int NumberOfSeasons { get; set; }
        public int DurationInSeconds { get; set; }
        public bool? IsCompatible { get; set; }
        public double AverageRating { get; set; }

        // Unknown type
        public string BGColor { get; set; }
        public object FGColor { get; set; }
        public object StrikethroughPrice { get; set; }
        public object PromoMessage { get; set; }
        public object PromoEndDateUtc { get; set; }
        public object RecommendationReason { get; set; }
        public object ReleaseNotes { get; set; }
        public object AlternateId { get; set; }
        public object CuratedBGColor { get; set; }
        public object CuratedFGColor { get; set; }
        public object CuratedImageUrl { get; set; }
        public object CuratedTitle { get; set; }
        public object CuratedDescription { get; set; }
        public object DoNotFilter { get; set; }
        public object ArtistName { get; set; }
        public object ArtistId { get; set; }
        public object AlbumTitle { get; set; }
        public object AlbumProductId { get; set; }
        public object IsExplicit { get; set; }
        public object ReleaseDateUtc { get; set; }
    }
}
