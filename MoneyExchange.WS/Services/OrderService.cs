using System;
using Rabun.Oanda.Rest.Base;
using Rabun.Oanda.Rest.Factories;
using MoneyExchangeWS.Dtos;
using MoneyExchangeWS.Endpoints;
using MoneyExchangeWS.Logging;

namespace MoneyExchangeWS.Services
{
    public class OrderService : IOrderService
    {
        readonly IHaveOrderEndpoint _orderEndpoint;
        readonly ILogDataToDb<Deal> _dealLogger;

        public OrderService(IHaveOrderEndpoint orderEndpoint, ILogDataToDb<Deal> dealLogger)
        {
            if (ReferenceEquals(dealLogger, null) == true)
                throw new ArgumentNullException(nameof(dealLogger));
            _dealLogger = dealLogger;

            if (ReferenceEquals(orderEndpoint, null) == true)
                throw new ArgumentNullException(nameof(orderEndpoint));
            _orderEndpoint = orderEndpoint;
        }

        public void OpenOrder(Deal deal)
        {
            if (ReferenceEquals(deal, null) == true)
                throw new ArgumentNullException(nameof(deal));
            _orderEndpoint.CreateMarketOrder(deal, _dealLogger);
        }
    }
}
