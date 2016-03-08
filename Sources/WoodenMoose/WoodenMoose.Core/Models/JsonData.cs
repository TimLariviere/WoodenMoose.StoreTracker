using System.Collections.Generic;

namespace WoodenMoose.Core.Models
{
    public class JsonData
    {
        public JsonData()
        {
            Accounts = new List<Account>();
            Applications = new List<Application>();
            Markets = new List<ApplicationMarket>();
            AccountToApplicationLinks = new List<AccountToApplication>();
            Reviews = new List<Review>();
        }

        public List<Account> Accounts { get; set; }
        public List<Application> Applications { get; set; }
        public List<ApplicationMarket> Markets { get; set; }
        public List<AccountToApplication> AccountToApplicationLinks { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
