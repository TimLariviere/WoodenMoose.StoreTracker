using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using WoodenMoose.Core.Models;
using WoodenMoose.Core.Repositories;

namespace WoodenMoose.Core.UnitTests.Repositories
{
    public class InMemoryAccountRepositoryTests
    {
        #region AddAccountAsync

        [TestClass]
        public class AddAccountAsync
        {
            [TestMethod]
            public void InMemoryAccountRepository_AddAccountAsync_AccountNull()
            {
                var accounts = new List<Account>()
                {
                    new Account(),
                    new Account()
                };
                Account account = null;
                var expectedResult = false;
                var expectedCount = accounts.Count;
                var expectedLastAccount = accounts.Last();

                var repository = new InMemoryAccountRepository(accounts);

                var actual = repository.AddAsync(account).GetAwaiter().GetResult();
                var actualCount = accounts.Count;
                var actualLastAccount = accounts.Last();

                Assert.AreEqual(expectedResult, actual);
                Assert.AreEqual(expectedCount, actualCount);
                Assert.AreSame(expectedLastAccount, actualLastAccount);
            }

            [TestMethod]
            public void InMemoryAccountRepository_AddAccountAsync_Valid()
            {
                var accounts = new List<Account>()
                {
                    new Account(),
                    new Account()
                };
                Account account = new Account();
                var expectedResult = true;
                var expectedCount = accounts.Count + 1;
                var expectedLastAccount = account;

                var repository = new InMemoryAccountRepository(accounts);

                var actual = repository.AddAsync(account).GetAwaiter().GetResult();
                var actualCount = accounts.Count;
                var actualLastAccount = accounts.Last();

                Assert.AreEqual(expectedResult, actual);
                Assert.AreEqual(expectedCount, actualCount);
                Assert.AreSame(expectedLastAccount, actualLastAccount);
            }

            [TestMethod]
            public void InMemoryAccountRepository_AddAccountAsync_AccountAlreadyAdded()
            {
                var accounts = new List<Account>()
                {
                    new Account(),
                    new Account()
                };
                Account account = new Account();
                var expectedResult1 = true;
                var expectedResult2 = false;
                var expectedCount = accounts.Count + 1;
                var expectedLastAccount = account;

                var repository = new InMemoryAccountRepository(accounts);

                var actual1 = repository.AddAsync(account).GetAwaiter().GetResult();
                var actual2 = repository.AddAsync(account).GetAwaiter().GetResult();
                var actualCount = accounts.Count;
                var actualLastAccount = accounts.Last();

                Assert.AreEqual(expectedResult1, actual1);
                Assert.AreEqual(expectedResult2, actual2);
                Assert.AreEqual(expectedCount, actualCount);
                Assert.AreSame(expectedLastAccount, actualLastAccount);
            }
        }

        #endregion

        #region ContainsAsync

        [TestClass]
        public class ContainsAsync
        {
            [TestMethod]
            public void InMemoryAccountRepository_ContainsAsync_True()
            {
                var account = new Account();
                var accounts = new List<Account>()
                {
                    new Account(),
                    account,
                    new Account()
                };
                var repository = new InMemoryAccountRepository(accounts);
                var expected = true;

                var actual = repository.ContainsAsync(account).GetAwaiter().GetResult();

                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void InMemoryAccountRepository_ContainsAsync_False()
            {
                var account = new Account();
                var accounts = new List<Account>()
                {
                    new Account(),
                    new Account(),
                    new Account()
                };
                var repository = new InMemoryAccountRepository(accounts);
                var expected = false;

                var actual = repository.ContainsAsync(account).GetAwaiter().GetResult();

                Assert.AreEqual(expected, actual);
            }
        }

        #endregion

        #region GetAllAccountsAsync

        [TestClass]
        public class GetAllAccountsAsync
        {
            [TestMethod]
            public void InMemoryAccountRepository_GetAllAccountsAsync()
            {
                var accounts = new List<Account>()
                {
                    new Account(),
                    new Account(),
                    new Account()
                };
                var repository = new InMemoryAccountRepository(accounts);

                var actualAccounts = repository.GetAllAsync().GetAwaiter().GetResult();

                Assert.AreEqual(accounts.Count, actualAccounts.Length);
                for (int i = 0; i < accounts.Count; i++)
                {
                    Assert.AreSame(accounts[i], actualAccounts[i]);
                }
            }
        }

        #endregion

        #region RemoveAccountAsync

        [TestClass]
        public class RemoveAccountAsync
        {
            [TestMethod]
            public void InMemoryAccountRepository_RemoveAccountAsync_AccountNull()
            {
                var accounts = new List<Account>()
                {
                    new Account(),
                    new Account()
                };
                Account account = null;
                var expectedResult = false;
                var expectedCount = accounts.Count;
                var expectedLastAccount = accounts.Last();

                var repository = new InMemoryAccountRepository(accounts);

                var actual = repository.RemoveAsync(account).GetAwaiter().GetResult();
                var actualCount = accounts.Count;
                var actualLastAccount = accounts.Last();

                Assert.AreEqual(expectedResult, actual);
                Assert.AreEqual(expectedCount, actualCount);
                Assert.AreSame(expectedLastAccount, actualLastAccount);
            }

            [TestMethod]
            public void InMemoryAccountRepository_RemoveAccountAsync_AccountNotInList()
            {
                var account = new Account();
                var accounts = new List<Account>()
                {
                    new Account(),
                    new Account()
                };
                var expectedResult = false;
                var expectedCount = accounts.Count;
                var expectedLastAccount = accounts.Last();

                var repository = new InMemoryAccountRepository(accounts);

                var actual = repository.RemoveAsync(account).GetAwaiter().GetResult();
                var actualCount = accounts.Count;
                var actualLastAccount = accounts.Last();

                Assert.AreEqual(expectedResult, actual);
                Assert.AreEqual(expectedCount, actualCount);
                Assert.AreSame(expectedLastAccount, actualLastAccount);
            }

            [TestMethod]
            public void InMemoryAccountRepository_RemoveAccountAsync_Valid()
            {
                var account = new Account();
                var accounts = new List<Account>()
                {
                    new Account(),
                    new Account(),
                    account
                };
                var expectedResult = true;
                var expectedCount = accounts.Count - 1;
                var expectedLastAccount = accounts[expectedCount - 1];

                var repository = new InMemoryAccountRepository(accounts);

                var actual = repository.RemoveAsync(account).GetAwaiter().GetResult();
                var actualCount = accounts.Count;
                var actualLastAccount = accounts.Last();

                Assert.AreEqual(expectedResult, actual);
                Assert.AreEqual(expectedCount, actualCount);
                Assert.AreSame(expectedLastAccount, actualLastAccount);
            }
        }

        #endregion

        #region UpdateAccountAsync

        [TestClass]
        public class UpdateAccountAsync
        {
            [TestMethod]
            public void InMemoryAccountRepository_UpdateAccountAsync_AccountNull()
            {
                var accounts = new List<Account>()
                {
                    new Account(),
                    new Account()
                };
                Account account = null;
                var expectedResult = false;

                var repository = new InMemoryAccountRepository(accounts);

                var actual = repository.UpdateAsync(account).GetAwaiter().GetResult();

                Assert.AreEqual(expectedResult, actual);
            }

            [TestMethod]
            public void InMemoryAccountRepository_RemoveAccountAsync_AccountNotInList()
            {
                var account = new Account();
                var accounts = new List<Account>()
                {
                    new Account(),
                    new Account()
                };
                var expectedResult = false;

                var repository = new InMemoryAccountRepository(accounts);

                var actual = repository.UpdateAsync(account).GetAwaiter().GetResult();

                Assert.AreEqual(expectedResult, actual);
            }

            [TestMethod]
            public void InMemoryAccountRepository_RemoveAccountAsync_Valid()
            {
                var account = new Account();
                var accounts = new List<Account>()
                {
                    new Account(),
                    new Account(),
                    account
                };
                var expectedResult = true;

                var repository = new InMemoryAccountRepository(accounts);

                var actual = repository.UpdateAsync(account).GetAwaiter().GetResult();

                Assert.AreEqual(expectedResult, actual);
            }
        }

        #endregion
    }
}
