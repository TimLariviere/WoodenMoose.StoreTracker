namespace Microsoft.Marketplace.Storefront.Contracts.V3
{
    public class ReviewList : IPaginable
    {
        public string ContinuationToken { get; set; }
        public string ListId { get; set; }
        public string ListType { get; set; }
        public int PageSize { get; set; }
        public Review[] Reviews { get; set; }
        public int TotalItems { get; set; }
    }
}
