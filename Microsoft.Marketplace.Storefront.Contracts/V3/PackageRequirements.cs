namespace Microsoft.Marketplace.Storefront.Contracts.V3
{
    public class PackageRequirements
    {
        public object[] HardwareRequirements { get; set; }
        public object HardwareDependencies { get; set; }
        public string[] SupportedArchitectures { get; set; }
        public Platform[] PlatformDependencies { get; set; }
    }
}
