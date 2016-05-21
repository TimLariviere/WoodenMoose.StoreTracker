using System;

namespace Microsoft.Marketplace.Storefront.Contracts.V3
{
    public class Review
    {
        public string DeviceFamily { get; set; }
        public string DeviceId { get; set; }
        public string DeviceType { get; set; }
        public int HelpfulNegative { get; set; }
        public int HelpfulPositive { get; set; }
        public bool IsAppInstalled { get; set; }
        public bool IsProductTrial { get; set; }
        public bool IsPublished { get; set; }
        public bool IsRevised { get; set; }
        public bool IsTakenDown { get; set; }
        public string Locale { get; set; }
        public string Market { get; set; }
        public string OSVersion { get; set; }
        public string PackageFullName { get; set; }
        public string ProductId { get; set; }
        public int Rating { get; set; }
        public string ReviewerName { get; set; }
        public Guid ReviewId { get; set; }
        public string ReviewText { get; set; }
        public DateTime SubmittedDateTimeUtc { get; set; }
        public string Title { get; set; }
        public bool UpdatedSinceResponse { get; set; }
        public UserResponse UserResponse { get; set; }
        public bool ViolationsFound { get; set; }

        // Unknown types
        public object DeviceModel { get; set; }
        public object DeviceName { get; set; }
        public object PackageFamily { get; set; }
        public object SkuId { get; set; }
    }
}
