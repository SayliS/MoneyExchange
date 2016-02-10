using System;
using Rabun.Oanda.Rest.Base;
using Rabun.Oanda.Rest.Endpoints;
using Rabun.Oanda.Rest.Factories;
using MoneyExchangeWS.Endpoints;
using MoneyExchangeWS.Endpoints.Oanda;

namespace MoneyExchangeWS.Services
{
    public class RateService
    {
        readonly IHaveRateEndpoint _rateEndPoint;
        static readonly DefaultFactory factory = new DefaultFactory("0393f0fde4d0d4b20c09447c75c653e2-c89a9d13f747598753765dd346f2ffbb",
            AccountType.practice,
            7181960);

        public RateService()
        {
            var ep = factory.GetEndpoint<RateEndpoints>();
            var ep2 = new OandaRateEndpoint(ep);
            _rateEndPoint = ep2;

        }

        public float GetAskPrice(string term)
        {
            if (string.IsNullOrWhiteSpace(term) == true)
                throw new ArgumentException(nameof(term));

            return _rateEndPoint.GetAskPrice(term);
        }
    }
}
