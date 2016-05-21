using System;

namespace Microsoft.Marketplace.Storefront.Contracts.V3
{
    public class UserResponse
    {
        public string UserResponseId { get; set; }
        public string ResponderName { get; set; }
        public Guid ReviewId { get; set; }
        public string Text { get; set; }
        public bool IsTakenDown { get; set; }
        public bool ViolationsFound { get; set; }
        public string Market { get; set; }
        public string Locale { get; set; }
        public int CatalogId { get; set; }
        public object DeviceName { get; set; }
        public object DeviceId { get; set; }
        public object OSVersion { get; set; }
        public DateTime SubmittedDateTime { get; set; }
        public Guid Id { get; set; }
    }
}
