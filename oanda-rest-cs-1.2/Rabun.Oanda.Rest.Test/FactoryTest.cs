using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rabun.Oanda.Rest.Base;
using Rabun.Oanda.Rest.Endpoints;
using Rabun.Oanda.Rest.Factories;
using Rabun.Oanda.Rest.Models;

namespace Rabun.Oanda.Rest.Test
{
    [TestClass]
    public class FactoryTest
    {
        [TestMethod]
        public async Task DefaultFactoryTest()
        {
            DefaultFactory factory = new DefaultFactory("ec89b162d4a9922c8fa40769c2453d8b-cc1fb522857d46a08a90ef09730343a6", AccountType.practice, 4905675);
            RateEndpoints rateEndpoints = factory.GetEndpoint<RateEndpoints>();

            Assert.IsNotNull(rateEndpoints);

            List<Price> prices = await rateEndpoints.GetPrices("EUR_USD");
            Assert.IsNotNull(prices);
            Assert.IsTrue(prices.Count > 0);
        }
    }
}
