namespace WindowsStoreServices.V1.Reviews
{
    public class ReviewsRequestBuilder : RequestBuilder<ReviewsRequestBuilder, ReviewsRequest, ReviewsOrderBy>
    {
        public ReviewsRequestBuilder(string applicationId) : base(applicationId)
        {
        }
    }
}