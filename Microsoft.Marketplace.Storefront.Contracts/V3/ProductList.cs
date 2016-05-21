namespace Microsoft.Marketplace.Storefront.Contracts.V3
{
    public class ProductList : IPaginable
    {
        public string ContinuationToken { get; set; }
        public ProductSummary[] Products { get; set; }
        public bool HasThirdPartyIAPs { get; set; }
        public int TotalItems { get; set; }
        public int PageSize { get; set; }

        // Unknown type
        public object ListType { get; set; }
        public object ListId { get; set; }
        public object Anid { get; set; }
        public object Title { get; set; }
        public object AddOnPriceRange { get; set; }
    }
}
