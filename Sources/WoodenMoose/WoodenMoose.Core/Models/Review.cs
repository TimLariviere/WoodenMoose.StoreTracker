using System;

namespace WoodenMoose.Core.Models
{
    public class Review
    {
        public string Id { get; set; }
        public string ApplicationMarketId { get; set; }
        public string Author { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public PlatformType Platform { get; set; }
        public bool IsNew { get; set; }
    }
}
