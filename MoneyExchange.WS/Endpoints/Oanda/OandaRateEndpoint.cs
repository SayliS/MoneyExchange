using System;
using System.Collections.Generic;
using System.Linq;
using Rabun.Oanda.Rest.Endpoints;
using Rabun.Oanda.Rest.Models;

namespace MoneyExchangeWS.Endpoints.Oanda
{
    public class OandaRateEndpoint : IHaveRateEndpoint
    {
        static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(OandaRateEndpoint));
        readonly RateEndpoints _rateEndPoint;
        readonly string supportedInstrument = "EUR_USD,EUR_GBP,EUR_CHF,EUR_TRY,EUR_DKK,EUR_SEK,EUR_NOK";

        List<Price> _cachePrices;
        DateTime _nextUpdate;

        public OandaRateEndpoint(RateEndpoints rateEndpoint)
        {
            if (ReferenceEquals(rateEndpoint, null) == true)
                throw new ArgumentNullException(nameof(rateEndpoint));
            _rateEndPoint = rateEndpoint;

            _cachePrices = new List<Price>();
            UpdatePrices();
        }

        void UpdatePrices()
        {
            if (_nextUpdate > DateTime.UtcNow)
                return;

            var prices = _rateEndPoint.GetPrices(supportedInstrument).Result;
            _cachePrices = prices;
            _nextUpdate = DateTime.UtcNow.AddMinutes(2);
        }

        public float GetSellPrice(string instrument)
        {
            UpdatePrices();

            var price = _cachePrices.FirstOrDefault(w => w.Instrument == instrument.ToUpper());
            if (ReferenceEquals(price, null) == true)
            {
                var errorMsg = $"Cannot get sell price for {instrument}";
                log.Error(errorMsg);
                throw new Exception(errorMsg);
            }

            return price.Ask;
        }

        public float GetBuyPrice(string instrument)
        {
            UpdatePrices();

            var price = _cachePrices.FirstOrDefault(w => w.Instrument == instrument.ToUpper());
            if (ReferenceEquals(price, null) == true)
            {
                var errorMsg = $"Cannot get sell price for {instrument}";
                log.Error(errorMsg);
                throw new Exception(errorMsg);
            }

            return price.Bid;
        }
    }
}