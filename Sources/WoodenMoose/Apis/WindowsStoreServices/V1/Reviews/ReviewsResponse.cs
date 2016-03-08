using System;
using WindowsStoreServices.V1.Common;

namespace WindowsStoreServices.V1.Reviews
{
    public class ReviewsResponse : Response<Review>
    {
    }

    public class Review
    {
        public string date { get; set; }
        public string applicationId { get; set; }
        public string applicationName { get; set; }
        public string market { get; set; }
        public string osVersion { get; set; }
        public string deviceType { get; set; }
        public bool isRevised { get; set; }
        public string packageVersion { get; set; }
        public string deviceModel { get; set; }
        public string productFamily { get; set; }
        public int deviceRAM { get; set; }
        public string deviceScreenResolution { get; set; }
        public int deviceStorageCapacity { get; set; }
        public bool isTouchEnabled { get; set; }
        public string reviewerName { get; set; }
        public int rating { get; set; }
        public string reviewTitle { get; set; }
        public string reviewText { get; set; }
        public int helpfulCount { get; set; }
        public int notHelpfulCount { get; set; }
        public DateTime responseDate { get; set; }
        public string responseText { get; set; }
    }
}