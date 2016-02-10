using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rabun.Oanda.Rest.Base;
using Rabun.Oanda.Rest.Endpoints;
using Rabun.Oanda.Rest.Models;

namespace Rabun.Oanda.Rest.Test.Endpoints
{
    [TestClass]
    public class TransactionEndpointsTest
    {
        private readonly TransactionEndpoints _transactionEndpoints;
        public TransactionEndpointsTest()
        {
            _transactionEndpoints = new TransactionEndpoints("ec89b162d4a9922c8fa40769c2453d8b-cc1fb522857d46a08a90ef09730343a6", AccountType.practice, 4905675);
        }

        [TestMethod]
        public async Task GetTransactionsTest()
        {
            List<Transaction> transactions = await _transactionEndpoints.GetTransactions(null, null, null, "EUR_USD", "");
            Assert.IsNotNull(transactions);
            Assert.IsTrue(transactions.Count > 0);
        }
    }
}
