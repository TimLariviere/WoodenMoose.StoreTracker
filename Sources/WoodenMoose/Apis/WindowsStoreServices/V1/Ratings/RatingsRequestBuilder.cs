namespace WindowsStoreServices.V1.Ratings
{
    public class RatingsRequestBuilder : RequestBuilder<RatingsRequestBuilder, RatingsRequest, RatingsOrderBy>
    {
        public RatingsRequestBuilder(string applicationId) : base(applicationId)
        {
        }
    }
}