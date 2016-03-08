using Newtonsoft.Json;

namespace WindowsStoreServices.V1.Common
{
    public class Response<T>
    {
        [JsonProperty("Value")]
        T[] Values { get; set; }
        [JsonProperty("@nextLink")]
        string NextLink { get; set; }
        [JsonProperty("TotalCount")]
        int TotalCount { get; set; }
    }
}
