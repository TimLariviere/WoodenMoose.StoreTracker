namespace Microsoft.Marketplace.Storefront.Contracts.V1
{
    public class ErrorResponse
    {
        public string ErrorContext { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
        public string ErrorLongDescription { get; set; }

        // Unknown types
        public object ErrorLinkDescription { get; set; }
        public object ErrorLink { get; set; }
        public object OpsMessage { get; set; }
        public object UserMitigation { get; set; }
    }
}
