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
        readonly RateEndpoints _endpoint;

        List<Price> _cachePrices;
        DateTime _nextUpdate;

        public OandaRateEndpoint(RateEndpoints endpoint)
        {
            if (ReferenceEquals(endpoint, null) == true)
                throw new ArgumentNullException(nameof(endpoint));
            _endpoint = endpoint;

            _cachePrices = new List<Price>();
            UpdatePrices();
        }

        void UpdatePrices()
        {
            if (_nextUpdate > DateTime.UtcNow)
                return;

            var prices = _endpoint.GetPrices("EUR_USD,EUR_GBP,EUR_CHF,EUR_TRY,EUR_DKK,EUR_SEK,EUR_NOK").Result;
            _cachePrices = prices;
            _nextUpdate = DateTime.UtcNow.AddMinutes(2);
        }

        public float GetAskPrice(string term)
        {
            UpdatePrices();

            var price = _cachePrices.FirstOrDefault(w => w.Instrument == term.ToUpper());
            if (ReferenceEquals(price, null) == true)
                throw new Exception("fix me");

            return price.Ask;
        }
    }
}