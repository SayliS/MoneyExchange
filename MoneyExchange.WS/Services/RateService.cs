using System;
using MoneyExchangeWS.Endpoints;

namespace MoneyExchangeWS.Services
{
    public class RateService : IRateService
    {
        readonly IHaveRateEndpoint rateEndPoint;
        public RateService(IHaveRateEndpoint rateEndPoint)
        {
            if (ReferenceEquals(rateEndPoint, null) == true)
                throw new ArgumentNullException(nameof(rateEndPoint));
            this.rateEndPoint = rateEndPoint;
        }

        public float GetSellPrice(string instrument)
        {
            if (string.IsNullOrWhiteSpace(instrument) == true)
                throw new ArgumentException(nameof(instrument));

            return rateEndPoint.GetSellPrice(instrument);
        }

        public float GetBuyPrice(string instrument)
        {
            if (string.IsNullOrWhiteSpace(instrument) == true)
                throw new ArgumentException(nameof(instrument));

            return rateEndPoint.GetBuyPrice(instrument);
        }
    }
}
