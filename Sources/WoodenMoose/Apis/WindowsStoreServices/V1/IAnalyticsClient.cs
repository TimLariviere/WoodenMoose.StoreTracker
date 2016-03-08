using System.Threading.Tasks;
using WindowsStoreServices.OAuth;
using WindowsStoreServices.V1.AppAcquisitions;
using WindowsStoreServices.V1.ErrorReportingData;
using WindowsStoreServices.V1.IapAcquisitions;
using WindowsStoreServices.V1.Ratings;
using WindowsStoreServices.V1.Reviews;

namespace WindowsStoreServices.V1
{
    public interface IAnalyticsClient
    {
        Task<AppAcquisitionsResponse> GetAppAcquisitionsAsync(OAuthToken token, AppAcquisitionsRequestBuilder builder);

        Task<IapAcquisitionsResponse> GetIapAcquisitionsAsync(OAuthToken token, IapAcquisitionsRequestBuilder builder);

        Task<ErrorReportingDataResponse> GetErrorReportingDataAsync(OAuthToken token, ErrorReportingDataRequestBuilder builder);

        Task<RatingsResponse> GetRatingsAsync(OAuthToken token, RatingsRequestBuilder builder);

        Task<ReviewsResponse> GetReviewsAsync(OAuthToken token, ReviewsRequestBuilder builder);
    }
}
