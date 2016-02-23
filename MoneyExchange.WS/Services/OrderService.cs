using System;
using MoneyExchangeWS.Dtos;
using MoneyExchangeWS.Endpoints;
using MoneyExchangeWS.Repositories.Logging;
using MoneyExchangeWS.Orders;

namespace MoneyExchangeWS.Services
{
    public class OrderService : IOrderService
    {
        readonly IHaveOrderEndpoint _orderEndpoint;
        readonly ILogToDbRepository<Deal> _dealLogger;
        readonly IRateService _rateService;

        public OrderService(IHaveOrderEndpoint orderEndpoint, IRateService rateService, ILogToDbRepository<Deal> dealLogger)
        {
            if (ReferenceEquals(dealLogger, null) == true)
                throw new ArgumentNullException(nameof(dealLogger));
            _dealLogger = dealLogger;

            if (ReferenceEquals(orderEndpoint, null) == true)
                throw new ArgumentNullException(nameof(orderEndpoint));
            _orderEndpoint = orderEndpoint;

            if (ReferenceEquals(rateService, null) == true)
                throw new ArgumentNullException(nameof(rateService));
            _rateService = rateService;
        }

        public void OpenOrder(IOrder order)
        {
            if (ReferenceEquals(order, null) == true)
                throw new ArgumentNullException(nameof(order));
            _orderEndpoint.CreateMarketOrder(order, null, _dealLogger);
        }

        public IOrder ConverFromDeal(Deal deal)
        {
            return new Order(deal, _rateService);
        }
    }
}
