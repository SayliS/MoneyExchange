using System;
using MoneyExchangeWS.Dtos;
using MoneyExchangeWS.Endpoints;
using MoneyExchangeWS.Loggers;
using MoneyExchangeWS.Orders;

namespace MoneyExchangeWS.Services
{
    public class OrderService : IOrderService
    {
        readonly IHaveOrderEndpoint orderEndpoint;
        readonly IRateService rateService;
        readonly ICanLogToDataBase<IOrder> orderLogger;
        public OrderService(IHaveOrderEndpoint orderEndpoint,
                            IRateService rateService,
                            ICanLogToDataBase<IOrder> orderLogger)
        {
            if (ReferenceEquals(orderEndpoint, null) == true)
                throw new ArgumentNullException(nameof(orderEndpoint));
            this.orderEndpoint = orderEndpoint;

            if (ReferenceEquals(rateService, null) == true)
                throw new ArgumentNullException(nameof(rateService));
            this.rateService = rateService;

            if (ReferenceEquals(orderLogger, null) == true)
                throw new ArgumentNullException(nameof(orderLogger));
            this.orderLogger = orderLogger;
        }

        public void OpenOrder(IOrder order)
        {
            if (ReferenceEquals(order, null) == true)
                throw new ArgumentNullException(nameof(order));

            orderEndpoint.CreateMarketOrder(order, orderLogger);
        }

        public IOrder ConverFromDeal(Deal deal)
        {
            return new Order(deal, rateService);
        }
    }
}
