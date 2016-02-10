using MoneyExchangeWS.Endpoints.Oanda;
using Rabun.Oanda.Rest.Models;
using System;

namespace MoneyExchangeWS.Extensions
{
    public static class SideExtensions
    {
        public static OrderOperation ToOperationType(this OandaTypes.Side value)
        {
            switch (value)
            {
                case OandaTypes.Side.buy:
                    return OrderOperation.Buy;
                case OandaTypes.Side.sell:
                    return OrderOperation.Sell;
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
