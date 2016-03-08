using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WoodenMoose.Core.UnitTests.Services
{
    [TestClass]
    public class AnalyticsTest
    {
        [TestMethod]
        public void Test()
        {
            var oAuthClient = new WindowsStoreServices.OAuth.OAuthClient();
            string tenantId = "edddb5c9-e2f2-4e91-90c9-48284f7538e1", clientId = "4d63ca44-6639-46ae-93e8-6fa47a7327df", secretKey = "L2NXQVgmVlR5T2dUcUNvOClHQyFFRWNrQSl8SDQpWDg=";
            var oAuthToken = oAuthClient.GetTokenAsync(tenantId, clientId, secretKey).Result;

            string appId = "9NBLGGH4M646";
            var requestBuilder = new WindowsStoreServices.V1.Ratings.RatingsRequestBuilder(appId);
            requestBuilder.Between(new DateTime(2016, 1, 1), new DateTime(2016, 12, 31))
                          .Take(1000)
                          .Skip(0);
            var analyticsClient = new WindowsStoreServices.V1.AnalyticsClient();

            var result = analyticsClient.GetRatingsAsync(oAuthToken, requestBuilder).Result;
        }

        [TestMethod]
        public void Test2()
        {
            var oAuthClient = new WindowsStoreServices.OAuth.OAuthClient();
            string tenantId = "edddb5c9-e2f2-4e91-90c9-48284f7538e1", clientId = "4d63ca44-6639-46ae-93e8-6fa47a7327df", secretKey = "L2NXQVgmVlR5T2dUcUNvOClHQyFFRWNrQSl8SDQpWDg=";
            var oAuthToken = oAuthClient.GetTokenAsync(tenantId, clientId, secretKey).Result;

            string appId = "9NBLGGH4M646";
            var requestBuilder = new WindowsStoreServices.V1.Reviews.ReviewsRequestBuilder(appId)
                                                                    .Between(new DateTime(2016, 1, 1), new DateTime(2016, 12, 31))
                                                                    .Take(1000)
                                                                    .Skip(0);
            var analyticsClient = new WindowsStoreServices.V1.AnalyticsClient();

            var result = analyticsClient.GetReviewsAsync(oAuthToken, requestBuilder).Result;
        }
    }
}
