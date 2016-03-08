using Newtonsoft.Json;
using System.Linq;

namespace WoodenMoose.Core.Models
{
    public class ApplicationMarket
    {
        public ApplicationMarket()
        {
            Reviews = new Review[0];
        }

        public string Id => $"{ApplicationId}_{MarketId}";
        public string ApplicationId { get; set; }
        public string MarketId { get; set; }
        public double AverageRating => (OneStarRatingsCount + TwoStarsRatingsCount*2d + ThreeStarsRatingsCount*3d +
                                        FourStarsRatingsCount*4d + FiveStarsRatingsCount*5d)/TotalRatingsCount;
        public int OneStarRatingsCount { get; set; }
        public int OneStarReviewsCount => Reviews.Count(r => r.Rating == 1);
        public int TwoStarsRatingsCount { get; set; }
        public int TwoStarsReviewsCount => Reviews.Count(r => r.Rating == 2);
        public int ThreeStarsRatingsCount { get; set; }
        public int ThreeStarsReviewsCount => Reviews.Count(r => r.Rating == 3);
        public int FourStarsRatingsCount { get; set; }
        public int FourStarsReviewsCount => Reviews.Count(r => r.Rating == 4);
        public int FiveStarsRatingsCount { get; set; }
        public int FiveStarsReviewsCount => Reviews.Count(r => r.Rating == 5);
        public int UnreadReviewsCount => Reviews.Count(r => r.IsNew);


        [JsonIgnore]
        public int TotalRatingsCount => OneStarRatingsCount + TwoStarsRatingsCount + ThreeStarsRatingsCount + FourStarsRatingsCount + FiveStarsRatingsCount;

        [JsonIgnore]
        public int TotalReviewsCount => OneStarReviewsCount + TwoStarsReviewsCount + ThreeStarsReviewsCount + FourStarsReviewsCount + FiveStarsReviewsCount;

        [JsonIgnore]
        public Review[] Reviews { get; internal set; }
    }
}
