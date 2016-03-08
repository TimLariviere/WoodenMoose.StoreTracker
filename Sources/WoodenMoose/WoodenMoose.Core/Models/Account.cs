using System;
using Newtonsoft.Json;

namespace WoodenMoose.Core.Models
{
    public class Account
    {
        public Account()
        {
            LinkedApplications = new Application[0];
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string TenantId { get; set; }
        public string ClientId { get; set; }
        public string SecretKey { get; set; }
        public string Resource { get; set; }
        public string AccessToken { get; set; }
        public DateTime? AccessTokenExpirationDate { get; set; }

        [JsonIgnore]
        public Application[] LinkedApplications { get; internal set; }
    }
}
