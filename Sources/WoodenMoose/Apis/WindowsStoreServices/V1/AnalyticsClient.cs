using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WindowsStoreServices.OAuth;
using WindowsStoreServices.V1.AppAcquisitions;
using WindowsStoreServices.V1.ErrorReportingData;
using WindowsStoreServices.V1.IapAcquisitions;
using WindowsStoreServices.V1.Ratings;
using WindowsStoreServices.V1.Reviews;
using Newtonsoft.Json;

namespace WindowsStoreServices.V1
{
    public class AnalyticsClient : IAnalyticsClient
    {
        public async Task<AppAcquisitionsResponse> GetAppAcquisitionsAsync(OAuthToken token, AppAcquisitionsRequestBuilder builder)
        {
            var request = builder.GetResult().GetUriParameters();
            var uri = new Uri($"https://manage.devcenter.microsoft.com/v1.0/my/analytics/appacquisitions?{request}");

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.TokenType, token.AccessToken);

            var response = await httpClient.GetAsync(uri);
            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<AppAcquisitionsResponse>(json);
        }

        public Task<IapAcquisitionsResponse> GetIapAcquisitionsAsync(OAuthToken token, IapAcquisitionsRequestBuilder builder)
        {
            throw new System.NotImplementedException();
        }

        public Task<ErrorReportingDataResponse> GetErrorReportingDataAsync(OAuthToken token, ErrorReportingDataRequestBuilder builder)
        {
            throw new System.NotImplementedException();
        }

        public async Task<RatingsResponse> GetRatingsAsync(OAuthToken token, RatingsRequestBuilder builder)
        {
            var request = builder.GetResult().GetUriParameters();
            var uri = new Uri($"https://manage.devcenter.microsoft.com/v1.0/my/analytics/ratings?{request}");

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.TokenType, token.AccessToken);

            var response = await httpClient.GetAsync(uri);
            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<RatingsResponse>(json);
        }

        public async Task<ReviewsResponse> GetReviewsAsync(OAuthToken token, ReviewsRequestBuilder builder)
        {
            var request = builder.GetResult().GetUriParameters();
            var uri = new Uri($"https://manage.devcenter.microsoft.com/v1.0/my/analytics/reviews?{request}");

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.TokenType, token.AccessToken);

            var response = await httpClient.GetAsync(uri);
            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ReviewsResponse>(json);
        }
    }
}
