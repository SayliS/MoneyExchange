using System;
using Rabun.Oanda.Rest.Models;
using MoneyExchangeWS.Orders;

namespace MoneyExchangeWS.Extensions
{
    public static class OrderOperationExtensions
    {
        public static OandaTypes.Side ToSide(this OrderOperation value)
        {
            switch (value)
            {
                case OrderOperation.Buy:
                    return OandaTypes.Side.buy;
                case OrderOperation.Sell:
                    return OandaTypes.Side.sell;
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
