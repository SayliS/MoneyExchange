using System;
using MoneyExchangeWS.Endpoints;

namespace MoneyExchangeWS.Services
{
    public class RateService : IRateService
    {
        readonly IHaveRateEndpoint _rateEndPoint;
        public RateService(IHaveRateEndpoint rateEndPoint)
        {
            if (ReferenceEquals(rateEndPoint, null) == true)
                throw new ArgumentNullException(nameof(rateEndPoint));
            _rateEndPoint = rateEndPoint;
        }

        public float GetAskPrice(string term)
        {
            if (string.IsNullOrWhiteSpace(term) == true)
                throw new ArgumentException(nameof(term));

            return _rateEndPoint.GetAskPrice(term);
        }

        public float GetBidPrice(string term)
        {
            if (string.IsNullOrWhiteSpace(term) == true)
                throw new ArgumentException(nameof(term));

            return _rateEndPoint.GetBidPrice(term);
        }
    }
}
