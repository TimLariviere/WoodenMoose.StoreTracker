namespace Microsoft.Marketplace.Storefront.Contracts.V1
{
    public class ResponseItem
    {
        public string Path { get; set; }
        public string ExpiryUtc { get; set; }
        public object Payload { get; set; }
    }
}
