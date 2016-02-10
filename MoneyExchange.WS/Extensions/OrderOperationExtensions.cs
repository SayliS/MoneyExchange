using MoneyExchangeWS.Endpoints.Oanda;
using Rabun.Oanda.Rest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
