using System.Linq;
using Newtonsoft.Json;

namespace WoodenMoose.Core.Models
{
    public class Application
    {
        public Application()
        {
            Markets = new ApplicationMarket[0];
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Background { get; set; }

        [JsonIgnore]
        public int TotalRatingsCount => OneStarRatingsCount + TwoStarsRatingsCount + ThreeStarsRatingsCount + FourStarsRatingsCount + FiveStarsRatingsCount;

        [JsonIgnore]
        public int TotalReviewsCount => OneStarReviewsCount + TwoStarsReviewsCount + ThreeStarsReviewsCount + FourStarsReviewsCount + FiveStarsReviewsCount;

        [JsonIgnore]
        public double AverageRating => (OneStarRatingsCount + TwoStarsRatingsCount * 2d + ThreeStarsRatingsCount * 3d +
                                FourStarsRatingsCount * 4d + FiveStarsRatingsCount * 5d) / TotalRatingsCount;

        [JsonIgnore]
        public int OneStarRatingsCount => Markets?.Sum(m => m.OneStarRatingsCount) ?? 0;

        [JsonIgnore]
        public int OneStarReviewsCount => Markets?.Sum(m => m.OneStarReviewsCount) ?? 0;

        [JsonIgnore]
        public int TwoStarsRatingsCount => Markets?.Sum(m => m.TwoStarsRatingsCount) ?? 0;

        [JsonIgnore]
        public int TwoStarsReviewsCount => Markets?.Sum(m => m.TwoStarsReviewsCount) ?? 0;

        [JsonIgnore]
        public int ThreeStarsRatingsCount => Markets?.Sum(m => m.ThreeStarsRatingsCount) ?? 0;

        [JsonIgnore]
        public int ThreeStarsReviewsCount => Markets?.Sum(m => m.ThreeStarsReviewsCount) ?? 0;

        [JsonIgnore]
        public int FourStarsRatingsCount => Markets?.Sum(m => m.FourStarsRatingsCount) ?? 0;

        [JsonIgnore]
        public int FourStarsReviewsCount => Markets?.Sum(m => m.FourStarsReviewsCount) ?? 0;

        [JsonIgnore]
        public int FiveStarsRatingsCount => Markets?.Sum(m => m.FiveStarsRatingsCount) ?? 0;
        
        [JsonIgnore]
        public int FiveStarsReviewsCount => Markets?.Sum(m => m.FiveStarsReviewsCount) ?? 0;
        
        [JsonIgnore]
        public int UnreadReviewsCount => Markets?.Sum(m => m.UnreadReviewsCount) ?? 0;

        [JsonIgnore]
        public ApplicationMarket[] Markets { get; internal set; } 
    }
}
