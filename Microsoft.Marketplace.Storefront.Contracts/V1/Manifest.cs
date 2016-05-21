using System.Collections.Generic;

namespace Microsoft.Marketplace.Storefront.Contracts.V1
{
    public class Manifest
    {
        public IDictionary<string, object> Properties { get; set; }
        public Manifest[] Sections { get; set; }
        public string Layout { get; set; }
        public string TelemetryId { get; set; }
        public bool ShouldReturnErrorIfFailed { get; set; }

        // Unknown type
        public object CommandInfoTable { get; set; }
        public object DataSource { get; set; }
    }
}
