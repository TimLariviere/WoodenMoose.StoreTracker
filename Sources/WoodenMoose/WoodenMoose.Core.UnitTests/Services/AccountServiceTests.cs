using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using WindowsStoreServices.OAuth;
using WoodenMoose.Core.Models;
using WoodenMoose.Core.Repositories.Interfaces;
using WoodenMoose.Core.Services;

namespace WoodenMoose.Core.UnitTests.Services
{
    public class AccountServiceTests
    {
        #region LoginAsync

        [TestClass]
        public class LoginAsync
        {
            [TestMethod]
            public void AccountServiceTests_LoginAsync_TenantIdNull()
            {
                string tenantId = null;
                string clientId = "ClientId";
                string secretKey = "SecretKey";
                string resource = "Resource";

                var accountRepository = Mock.Of<IAccountRepository>();
                var oauthClient = Mock.Of<IOAuthClient>();

                var service = new AccountService(accountRepository, oauthClient);
                var actual = service.LoginAsync(tenantId, clientId, secretKey, resource).GetAwaiter().GetResult();

                Assert.IsNull(actual);

                Mock.Get(oauthClient).Verify(c => c.GetTokenAsync(tenantId, clientId, secretKey, resource), Times.Never());
                Mock.Get(accountRepository).Verify(r => r.AddAsync(It.IsAny<Account>()), Times.Never());
            }

            [TestMethod]
            public void AccountServiceTests_LoginAsync_ClientIdNull()
            {
                string tenantId = "TenantId";
                string clientId = null;
                string secretKey = "SecretKey";
                string resource = "Resource";

                var accountRepository = Mock.Of<IAccountRepository>();
                var oauthClient = Mock.Of<IOAuthClient>();

                var service = new AccountService(accountRepository, oauthClient);
                var actual = service.LoginAsync(tenantId, clientId, secretKey, resource).GetAwaiter().GetResult();

                Assert.IsNull(actual);

                Mock.Get(oauthClient).Verify(c => c.GetTokenAsync(tenantId, clientId, secretKey, resource), Times.Never());
                Mock.Get(accountRepository).Verify(r => r.AddAsync(It.IsAny<Account>()), Times.Never());
            }

            [TestMethod]
            public void AccountServiceTests_LoginAsync_SecretKeyNull()
            {
                string tenantId = "TenantId";
                string clientId = "ClientId";
                string secretKey = null;
                string resource = "Resource";

                var accountRepository = Mock.Of<IAccountRepository>();
                var oauthClient = Mock.Of<IOAuthClient>();

                var service = new AccountService(accountRepository, oauthClient);
                var actual = service.LoginAsync(tenantId, clientId, secretKey, resource).GetAwaiter().GetResult();

                Assert.IsNull(actual);

                Mock.Get(oauthClient).Verify(c => c.GetTokenAsync(tenantId, clientId, secretKey, resource), Times.Never());
                Mock.Get(accountRepository).Verify(r => r.AddAsync(It.IsAny<Account>()), Times.Never());
            }

            [TestMethod]
            public void AccountServiceTests_LoginAsync_ResourceNull()
            {
                string tenantId = "TenantId";
                string clientId = "ClientId";
                string secretKey = "SecretKey";
                string resource = null;

                var accountRepository = Mock.Of<IAccountRepository>();
                var oauthClient = Mock.Of<IOAuthClient>();

                var service = new AccountService(accountRepository, oauthClient);
                var actual = service.LoginAsync(tenantId, clientId, secretKey, resource).GetAwaiter().GetResult();

                Assert.IsNull(actual);

                Mock.Get(oauthClient).Verify(c => c.GetTokenAsync(tenantId, clientId, secretKey, resource), Times.Never());
                Mock.Get(accountRepository).Verify(r => r.AddAsync(It.IsAny<Account>()), Times.Never());
            }

            [TestMethod]
            public void AccountServiceTests_LoginAsync_AuthenticationFailed()
            {
                var tenantId = "TenantId";
                var clientId = "ClientId";
                var secretKey = "SecretKey";
                var resource = "Resource";
                
                var accountRepository = Mock.Of<IAccountRepository>();
                var oauthClient = Mock.Of<IOAuthClient>();

                Mock.Get(oauthClient).Setup(c => c.GetTokenAsync(tenantId, clientId, secretKey, resource))
                                     .ReturnsAsync(null);

                var service = new AccountService(accountRepository, oauthClient);
                var actual = service.LoginAsync(tenantId, clientId, secretKey, resource).GetAwaiter().GetResult();

                Assert.IsNull(actual);

                Mock.Get(oauthClient).Verify(c => c.GetTokenAsync(tenantId, clientId, secretKey, resource), Times.Once());
                Mock.Get(accountRepository).Verify(r => r.AddAsync(It.IsAny<Account>()), Times.Never());
            }

            [TestMethod]
            public void AccountServiceTests_LoginAsync_AuthenticationSucceeded_AddFailed()
            {
                var tenantId = "TenantId";
                var clientId = "ClientId";
                var secretKey = "SecretKey";
                var resource = "Resource";

                var accountRepository = Mock.Of<IAccountRepository>();
                var oauthClient = Mock.Of<IOAuthClient>();

                var oauthToken = new OAuthToken()
                {
                    AccessToken = "AccessToken",
                    ExpiresIn = DateTime.UtcNow
                };

                Mock.Get(oauthClient).Setup(c => c.GetTokenAsync(tenantId, clientId, secretKey, resource))
                                     .ReturnsAsync(oauthToken);

                Mock.Get(accountRepository).Setup(r => r.AddAsync(It.IsAny<Account>()))
                                           .ReturnsAsync(false);

                var service = new AccountService(accountRepository, oauthClient);
                var actual = service.LoginAsync(tenantId, clientId, secretKey, resource).GetAwaiter().GetResult();

                Assert.IsNull(actual);

                Mock.Get(oauthClient).Verify(c => c.GetTokenAsync(tenantId, clientId, secretKey, resource), Times.Once());
                Mock.Get(accountRepository).Verify(r => r.AddAsync(It.IsAny<Account>()), Times.Once());
            }

            [TestMethod]
            public void AccountServiceTests_LoginAsync_AuthenticationSucceeded_AddSucceeded()
            {
                var tenantId = "TenantId";
                var clientId = "ClientId";
                var secretKey = "SecretKey";
                var resource = "Resource";

                var accountRepository = Mock.Of<IAccountRepository>();
                var oauthClient = Mock.Of<IOAuthClient>();

                var oauthToken = new OAuthToken()
                {
                    AccessToken = "AccessToken",
                    ExpiresIn = DateTime.UtcNow
                };

                Mock.Get(oauthClient).Setup(c => c.GetTokenAsync(tenantId, clientId, secretKey, resource))
                                     .ReturnsAsync(oauthToken);

                Mock.Get(accountRepository).Setup(r => r.AddAsync(It.IsAny<Account>()))
                                           .ReturnsAsync(true);

                var service = new AccountService(accountRepository, oauthClient);
                var actual = service.LoginAsync(tenantId, clientId, secretKey, resource).GetAwaiter().GetResult();

                Assert.IsNotNull(actual);
                Assert.AreEqual(tenantId, actual.Name);
                Assert.AreEqual(tenantId, actual.TenantId);
                Assert.AreEqual(clientId, actual.ClientId);
                Assert.AreEqual(secretKey, actual.SecretKey);
                Assert.AreEqual(resource, actual.Resource);
                Assert.AreEqual(oauthToken.AccessToken, actual.AccessToken);
                Assert.IsTrue(actual.AccessTokenExpirationDate.HasValue);
                Assert.AreEqual(oauthToken.ExpiresOn, actual.AccessTokenExpirationDate.Value);

                Mock.Get(oauthClient).Verify(c => c.GetTokenAsync(tenantId, clientId, secretKey, resource), Times.Once());
                Mock.Get(accountRepository).Verify(r => r.AddAsync(It.IsAny<Account>()), Times.Once());
            }
        }

        #endregion
    }
}
