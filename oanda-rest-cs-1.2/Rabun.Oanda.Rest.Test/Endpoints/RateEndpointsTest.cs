using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rabun.Oanda.Rest.Base;
using Rabun.Oanda.Rest.Endpoints;
using Rabun.Oanda.Rest.Models;

namespace Rabun.Oanda.Rest.Test.Endpoints
{
    [TestClass]
    public class RateEndpointsTest
    {
        private readonly RateEndpoints _rateEndpoints;
        public RateEndpointsTest()
        {
            _rateEndpoints = new RateEndpoints("59026b50358c8f948391ab5110ad42b4-6e8cc7fbbc6879c170bfa65d8a0b136b", AccountType.practice, 4905675);
        }

        #region GetInstrumentsTest

        [TestMethod]
        public async Task GetInstrumentsTest()
        {
            List<InstrumentModel> instruments = await _rateEndpoints.GetInstruments();
            Assert.IsNotNull(instruments);
            Assert.IsTrue(instruments.Count > 0);
        }

        [TestMethod]
        public async Task GetInstrumentsByInstrumentTest()
        {
            List<InstrumentModel> instruments = await _rateEndpoints.GetInstruments("EUR_USD,CHF_JPY");
            Assert.IsNotNull(instruments);
            Assert.IsTrue(instruments.Count == 2);
        }

        [TestMethod]
        public async Task GetInstrumentsByFielsAndInstumentsTest()
        {
            List<InstrumentModel> instruments = await _rateEndpoints.GetInstruments("instrument", "EUR_USD");
            Assert.IsNotNull(instruments);
            Assert.IsTrue(instruments.Count > 0);
        }

        #endregion

        #region GetPricesTest

        [TestMethod]
        public async Task GetPricesTest()
        {
            List<Price> prices = await _rateEndpoints.GetPrices("EUR_USD,CHF_JPY");
            Assert.IsNotNull(prices);
            Assert.IsTrue(prices.Count == 2);
        }

        #endregion

        #region GetCandlesTest

        [TestMethod]
        public async Task GetCandlesByInstrumentTest()
        {
            Candle<CandleBidAsk> candle = await _rateEndpoints.GetCandles("EUR_USD");
            Assert.IsNotNull(candle);
            Assert.IsTrue(candle.Candles.Count > 0);
        }

        [TestMethod]
        public async Task GetCandlesByInstrumentAndGranuariryTest()
        {
            Candle<CandleBidAsk> candle = await _rateEndpoints.GetCandles("EUR_USD", OandaTypes.GranularityType.D);
            Assert.IsNotNull(candle);
            Assert.IsTrue(candle.Candles.Count > 0);
        }

        [TestMethod]
        public async Task GetCandlesByInstrumentAndGranuariryAndCountTest()
        {
            Candle<CandleBidAsk> candle = await _rateEndpoints.GetCandles("EUR_USD", OandaTypes.GranularityType.M, 10);
            Assert.IsNotNull(candle);
            Assert.IsTrue(candle.Candles.Count == 10);
        }

        [TestMethod]
        public async Task GetCandlesByInstrumentAndGranuariryAndStartAndEndTest()
        {
            DateTime start = DateTime.UtcNow.AddDays(-1);
            DateTime end = DateTime.UtcNow;

            Candle<CandleBidAsk> candle = await _rateEndpoints.GetCandles("EUR_USD", OandaTypes.GranularityType.H1, start, end);
            Assert.IsNotNull(candle);
            Assert.IsTrue(candle.Candles.Count > 0);
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        [TestMethod]
        public async Task GetCandlesMidByInstrumentTest()
        {
            Candle<CandleMid> candle = await _rateEndpoints.GetCandlesMid("EUR_USD");
            Assert.IsNotNull(candle);
            Assert.IsTrue(candle.Candles.Count > 0);
        }

        [TestMethod]
        public async Task GetCandlesMidByInstrumentAndGranuariryTest()
        {
            Candle<CandleMid> candle = await _rateEndpoints.GetCandlesMid("EUR_USD", OandaTypes.GranularityType.S5);
            Assert.IsNotNull(candle);
            Assert.IsTrue(candle.Candles.Count > 0);
        }

        [TestMethod]
        public async Task GetCandlesMidByInstrumentAndGranuariryAndCountTest()
        {
            Candle<CandleMid> candle = await _rateEndpoints.GetCandlesMid("EUR_USD", OandaTypes.GranularityType.M, 10);
            Assert.IsNotNull(candle);
            Assert.IsTrue(candle.Candles.Count == 10);
        }

        [TestMethod]
        public async Task GetCandlesMidByInstrumentAndGranuariryAndStartAndEndTest()
        {
            DateTime start = DateTime.UtcNow.AddDays(-1);
            DateTime end = DateTime.UtcNow;

            Candle<CandleMid> candle = await _rateEndpoints.GetCandlesMid("EUR_USD", OandaTypes.GranularityType.H1, start, end);
            Assert.IsNotNull(candle);
            Assert.IsTrue(candle.Candles.Count > 0);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public async Task GetCandlesByAllWithCountParams()
        {
            object candle =
                await
                    _rateEndpoints.GetCandles("EUR_USD", OandaTypes.GranularityType.M, 100,
                        OandaTypes.CandleFormat.bidask,
                        true, null, OandaTypes.WeeklyAlignment.Friday);


            Assert.IsTrue(candle is Candle<CandleBidAsk>);
            Candle<CandleBidAsk> cba = candle as Candle<CandleBidAsk>;

            Assert.IsNotNull(cba);
            Assert.IsTrue(cba.Candles.Count == 100);
        }

        [TestMethod]
        public async Task GetCandlesByAllWithStartEndParams()
        {
            DateTime start = DateTime.UtcNow.AddDays(-1);
            DateTime end = DateTime.UtcNow;

            object candle =
                await
                    _rateEndpoints.GetCandles("EUR_USD", OandaTypes.GranularityType.M, start, end,
                        OandaTypes.CandleFormat.midpoint,
                        true, null, OandaTypes.WeeklyAlignment.Friday);


            Assert.IsTrue(candle is Candle<CandleMid>);
            Candle<CandleMid> cba = candle as Candle<CandleMid>;

            Assert.IsNotNull(cba);
            Assert.IsTrue(cba.Candles.Count > 0);
        }

        #endregion
    }
}
