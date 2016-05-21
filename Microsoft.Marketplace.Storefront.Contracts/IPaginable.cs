namespace Microsoft.Marketplace.Storefront.Contracts
{
    public interface IPaginable
    {
        string ContinuationToken { get; set; }
        int TotalItems { get; set; }
    }
}
