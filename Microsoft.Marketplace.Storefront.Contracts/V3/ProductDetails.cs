using Microsoft.Marketplace.Storefront.Contracts.V2;
using System;

namespace Microsoft.Marketplace.Storefront.Contracts.V3
{
    public class ProductDetails : ProductSummary
    {
        public string[] Platforms { get; set; }
        public string PrivacyUrl { get; set; }
        public string LegalUrl { get; set; }
        public bool Accessible { get; set; }
        public bool IsDeviceCompanionApp { get; set; }
        public SupportUri[] SupportUris { get; set; }
        public string[] Features { get; set; }
        public string[] Notes { get; set; }
        public string[] SupportedLanguages { get; set; }
        public string PublisherCopyrightInformation { get; set; }
        public long ApproximateSizeInBytes { get; set; }
        public string AppWebsiteUrl { get; set; }
        public ProductRating[] ProductRatings { get; set; }
        public string[] PermissionsRequired { get; set; }
        public DateTime LastUpdateDateUtc { get; set; }
        public Sku[] Skus { get; set; }
        public string CategoryId { get; set; }
        public bool HasAddOns { get; set; }
        public bool HasThirdPartyIAPs { get; set; }
        public bool DeveloperOptOutOfSDCardInstall { get; set; }

        // Unknown types
        public object AdditionalLicenseTerms { get; set; }
        public object RequiredHardware { get; set; }
        public object RecommendedHardware { get; set; }
        public object HardwareWarnings { get; set; }
        public object Version { get; set; }
        public object OSProductInformation { get; set; }
        public object SubcategoryId { get; set; }
        public object AddOnPriceRange { get; set; }
        public object DeviceFamilyDisallowedReason { get; set; }
        public object IncompatibleReason { get; set; }
    }
}
