namespace Microsoft.Marketplace.Storefront.Contracts.V3
{
    public class Platform
    {
        public string PlatformName { get; set; }
        public long MinVersion { get; set; }
        public long MaxTested { get; set; }
    }
}
