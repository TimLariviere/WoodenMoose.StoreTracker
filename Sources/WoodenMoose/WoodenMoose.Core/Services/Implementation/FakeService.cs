using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WoodenMoose.Core.Models;
using WoodenMoose.Core.Repositories;

namespace WoodenMoose.Core.Services.Implementation
{
    public class FakeService
    {
        public async Task AddFakeAccounts(IAccountRepository accountRepository, IApplicationRepository applicationRepository, IApplicationMarketRepository applicationMarketRepository, IReviewRepository reviewRepository)
        {
            var accountNames = new[]
            {
                "Facebook Inc",
                "Netflix, Inc.",
                "Pandora Media Inc.",
                "Adobe Systems Incorporated",
                "VideoLAN",
                "Microsoft Research",
                "Hulu.",
                "Fitbit",
                "Amazon.com",
                "iHeartMedia."
            };

            var applicationNames = new[]
            {
                new { Name = "Facebook", ImageUrl = "https://store-images.s-microsoft.com/image/apps.50574.9007199266245907.9d973991-3e76-4c85-93ee-bbde711eac4c.584c662d-d95b-41b5-81fc-117e169aaac0?w=80&h=80&q=60", Background = "#3b5998" },
                new { Name = "Pandora", ImageUrl = "https://store-images.s-microsoft.com/image/apps.39973.9007199266244713.f6abb82b-6782-41a7-a34a-57c4d97ec180.569ff74f-6187-4a99-ba9b-763b31ddd0c4?w=80&h=80&q=60", Background = "#202853" },
                new { Name = "Adobe Photoshop Express", ImageUrl = "https://store-images.s-microsoft.com/image/apps.61459.9007199266243449.8f05265e-eccb-4ac9-bbd4-a37acf4854e1.f59067c7-79bc-4384-a65c-398c6ff14739?w=80&h=80&q=60", Background = "#001d26" },
                new { Name = "VLC for Windows Store", ImageUrl = "https://store-images.s-microsoft.com/image/apps.28962.9007199266246349.76e1eb40-047a-4029-a6d5-6b4259422f79.55ff382f-d25a-4f83-8501-a6436eaf9fe6?w=80&h=80&q=60", Background = "#ff8800" },
                new { Name = "Network Speed Test", ImageUrl = "https://store-images.s-microsoft.com/image/apps.13863.9007199266247335.56f360b7-b4ea-40cb-a5e7-aad3a9b4d929.5011315f-6bfb-45e4-83ff-36aa145ffa8b?w=80&h=80&q=60", Background = "#009e49" },
                new { Name = "Hulu", ImageUrl = "https://store-images.s-microsoft.com/image/apps.24514.9007199266246590.00622cf5-f1da-43a1-a307-98c6bc7b088c.597ce205-1312-47f5-9247-144187518994?w=80&h=80&q=60", Background = "#66aa33" },
                new { Name = "Fitbit", ImageUrl = "https://store-images.s-microsoft.com/image/apps.21291.9007199266242687.5fef8bc5-feb9-4940-8a73-069542147062.a9e33f29-2ee6-4869-87eb-d86f2dd88d82?w=80&h=80&q=60", Background = "#0078d7" },
                new { Name = "Amazon", ImageUrl = "https://store-images.s-microsoft.com/image/apps.19478.9007199266244431.1a006e6e-3298-41fe-9d87-8197e2b317d7.fca03ef1-0609-47af-bb7b-cd8de4fa11e9?w=80&h=80&q=60", Background = "#ffffff" },
                new { Name = "iHeartRadio", ImageUrl = "https://store-images.microsoft.com/image/apps.64216.9007199266242576.b72d2256-9211-4202-9f4c-a8164999beee.3d5eaaf9-3282-43cf-b682-3defd0dc569b?w=80&h=80&q=60", Background = "#c6002b" },
            };

            var marketNames = new[]
            {
                "us",
                "gb",
                "fr",
                "de",
                "be",
                "ma",
                "jp",
                "cn",
                "ca",
                "it"
            };

            var lorem = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit.Nulla sed nibh et nulla eleifend finibus.Nullam pellentesque sagittis arcu, at ullamcorper massa tincidunt vitae. Ut ullamcorper facilisis purus, vel posuere tellus elementum a. Sed fringilla magna eget lectus congue, ac dignissim mauris semper.Aenean metus tellus, scelerisque non nisl ac, scelerisque efficitur ex. Phasellus eleifend ullamcorper mi eget tristique. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Aliquam at magna et ligula cursus rutrum a ut leo.
Integer mollis justo et risus mattis varius.Nulla ac dignissim lectus. Pellentesque id nulla in est imperdiet placerat nec non est. Nulla vel laoreet magna, id mollis justo. Nulla lectus orci, viverra eget leo ac, volutpat luctus dolor. Proin sit amet tincidunt nisl, nec imperdiet tortor.Vivamus et sem quis libero pretium faucibus non eget lacus. Nam pharetra vestibulum dolor et ornare.
Nullam quis erat non ipsum vehicula interdum.Mauris egestas et est non volutpat. Nullam faucibus mattis odio vitae elementum. Cras dui ante, euismod bibendum justo eu, rhoncus dapibus urna. In volutpat tortor urna, quis tempor nibh dapibus eget. Pellentesque hendrerit felis mi. Mauris pulvinar massa et nulla accumsan tempor.Nunc dictum cursus erat, nec cursus libero eleifend id. Praesent porta dignissim ligula, eget dignissim libero porttitor vel. Suspendisse viverra diam sed metus pulvinar tempus.Nulla facilisi. Aenean rutrum, nisl et pellentesque lacinia, nisl magna dictum neque, ac placerat turpis leo at elit.Vivamus vitae enim tellus. Morbi molestie sed quam ac mollis. Donec pulvinar elit sit amet finibus tempus.
Vestibulum pellentesque sapien nec leo tempus hendrerit.Nam aliquam tellus vitae neque ultricies laoreet.Donec porta dui at consectetur dignissim. Duis porta maximus ullamcorper. Maecenas aliquet fringilla maximus. Mauris interdum consectetur eros molestie porta. Donec et urna convallis, facilisis quam in, sodales dolor.
Nam sagittis accumsan lectus et cursus. Fusce ac interdum mi, vitae tempus quam. Aenean eget laoreet erat. Nulla facilisi. Pellentesque purus lectus, elementum eu tempor sed, pulvinar sed diam. In tortor metus, pretium id est et, sodales tincidunt lacus. Aenean placerat leo non lorem eleifend, eget pharetra ex finibus.Phasellus viverra ornare leo nec blandit. Mauris sem lorem, pretium ac leo ac, feugiat egestas orci. Aenean sodales lacus sed nisl convallis condimentum quis ut odio. Mauris ligula nulla, imperdiet ac magna at, iaculis faucibus elit. Integer elementum blandit orci, quis maximus elit placerat ut. Integer placerat mi sapien, in tristique tellus luctus eleifend. Aenean sed pharetra velit. Curabitur ac magna urna. Fusce in nulla pellentesque, blandit erat non, sagittis neque.";

            var random = new Random();
            var accountsCount = random.Next(1, accountNames.Length);
            for (int i = 0; i < accountsCount; i++)
            {
                // Account
                var account = new Account()
                {
                    Name = accountNames[i]
                };
                await accountRepository.AddAsync(account);

                // Application
                var applications = new List<Application>();
                var applicationsCount = random.Next(1, applicationNames.Length);
                for (int j = 0; j < applicationsCount; j++)
                {
                    var application = new Application()
                    {
                        Id = accountNames[i] + "_" + applicationNames[j].Name,
                        Name = applicationNames[j].Name,
                        ImageUrl = applicationNames[j].ImageUrl,
                        Background = applicationNames[j].Background
                    };
                    await applicationRepository.AddAsync(application);
                    
                    // Market
                    var markets = new List<ApplicationMarket>();
                    var marketsCount = random.Next(1, marketNames.Length);
                    for (int k = 0; k < marketsCount; k++)
                    {
                        var applicationMarket = new ApplicationMarket()
                        {
                            ApplicationId = application.Id,
                            MarketId = marketNames[k],
                            FiveStarsRatingsCount = random.Next(1000000),
                            FourStarsRatingsCount = random.Next(1000000),
                            OneStarRatingsCount = random.Next(1000000),
                            ThreeStarsRatingsCount = random.Next(1000000),
                            TwoStarsRatingsCount = random.Next(1000000),
                        };
                        await applicationMarketRepository.AddAsync(applicationMarket);

                        // Reviews
                        var reviews = new List<Review>();
                        var reviewsCount = random.Next(1, 100);
                        for (int l = 0; l < reviewsCount; l++)
                        {

                            var review = new Review()
                            {
                                Id = l.ToString(),
                                ApplicationMarketId = applicationMarket.Id,
                                Author = lorem.Remove(random.Next(2, 50)),
                                Rating = random.Next(1, 6),
                                Platform = (PlatformType) random.Next(0, 5),
                                Date = DateTime.Now.Date.AddDays(random.Next(-1000, 1000)),
                                IsNew = random.Next(0, 2) == 1,
                                Title = lorem.Remove(random.Next(2, 250)),
                                Content = lorem.Remove(random.Next(0, lorem.Length))
                            };
                            await reviewRepository.AddAsync(review);

                            reviews.Add(review);
                        }

                        applicationMarket.Reviews = reviews.ToArray();
                        markets.Add(applicationMarket);
                    }

                    application.Markets = markets.ToArray();
                    applications.Add(application);
                }

                account.LinkedApplications = applications.ToArray();
            }
        }
    }
}
