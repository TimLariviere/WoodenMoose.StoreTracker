namespace Microsoft.Marketplace.Storefront.Contracts.V3
{
    public class Sku
    {
        public string SkuId { get; set; }
        public string[] Actions { get; set; }
        public string AvailabiltyId { get; set; }
        public string SkuType { get; set; }
        public double Price { get; set; }
        public object StrikethroughPrice { get; set; }
        public object PromoMessage { get; set; }
        public object PromoEndDateUtc { get; set; }
        public object CurrencyCode { get; set; }
        public object CurrencySymbol { get; set; }
        public string ResourceSetId { get; set; }
        public string ContentId { get; set; }
        public bool IsWin32 { get; set; }
        public bool IsPaymentInstrumentRequired { get; set; }
        public string FulfillmentData { get; set; }
        public PackageRequirements[] PackageRequirements { get; set; }
        public object TimedTrialMessage { get; set; }
        public int RemainingDaysInTrial { get; set; }
        public object[] HardwareRequirements { get; set; }
        public object[] HardwareWarnings { get; set; }
        public object Images { get; set; }
        public object StartDate { get; set; }
        public object EndDate { get; set; }
        public object RequiredEntitlementKeys { get; set; }
        public object ContentIds { get; set; }
        public object UpgradeToProductId { get; set; }
    }
}
