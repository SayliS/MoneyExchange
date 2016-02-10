using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rabun.Oanda.Rest.Base;
using Rabun.Oanda.Rest.Endpoints;
using Rabun.Oanda.Rest.Models;

namespace Rabun.Oanda.Rest.Test.Endpoints
{
    [TestClass]
    public class TradeEndpointsTest
    {
        private readonly TradeEndpoints _tradeEndpoints;
        public TradeEndpointsTest()
        {
            _tradeEndpoints = new TradeEndpoints("ec89b162d4a9922c8fa40769c2453d8b-cc1fb522857d46a08a90ef09730343a6", AccountType.practice, 4905675);
        }

        #region GetTradesTest

        [TestMethod]
        public async Task GetTradesTest()
        {
            List<Trade> trades = await _tradeEndpoints.GetTrades();
            Assert.IsNotNull(trades);
            Assert.IsTrue(trades.Count > 0);
        }

        [TestMethod]
        public async Task GetTradesByInstrumentTest()
        {
            List<Trade> trades = await _tradeEndpoints.GetTrades("EUR_USD");
            Assert.IsNotNull(trades);
            Assert.IsTrue(trades.Count > 0);

        }

        [TestMethod]
        public async Task GetTradesByInstrumentAndCountTest()
        {
            List<Trade> trades = await _tradeEndpoints.GetTrades("EUR_USD", 100);
            Assert.IsNotNull(trades);
            Assert.IsTrue(trades.Count > 0);

        }

        [TestMethod]
        public async Task GetTradesByAll()
        {
            List<Trade> trades = await _tradeEndpoints.GetTrades("EUR_USD", 100, null, null);
            Assert.IsNotNull(trades);
            Assert.IsTrue(trades.Count > 0);

        }

        #endregion

        #region GetTradeTest

        [TestMethod]
        public async Task GetTradeTest()
        {
            Trade trade = await _tradeEndpoints.GetTrade(968541259);
            Assert.IsNotNull(trade);
        }

        #endregion

        #region UpdateTradeTest

        [TestMethod]
        public async Task UpdateTradeTest()
        {
            Trade trade = await _tradeEndpoints.UpdateTrade(968541259, null, 1.29f, null);
            Assert.IsNotNull(trade);
            Assert.IsTrue(trade.TakeProfit == 1.29f);

        }

        #endregion

        #region CloseTradeTest

        [TestMethod]
        public async Task CloseTradeTest()
        {
            TradeClosed trade = await _tradeEndpoints.CloseTrade(968541259);
            Assert.IsNotNull(trade);
        }

        #endregion
    }
}
