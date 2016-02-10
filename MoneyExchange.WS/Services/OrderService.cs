using System;
using MoneyExchangeWS.Dtos;
using MoneyExchangeWS.Endpoints;
using Rabun.Oanda.Rest.Factories;
using Rabun.Oanda.Rest.Base;
using Rabun.Oanda.Rest.Endpoints;
using MoneyExchangeWS.Endpoints.Oanda;
using MoneyExchangeWS.Logging;

namespace MoneyExchangeWS.Services
{
    public class OrderService
    {
        readonly IHaveOrderEndpoint _orderEndpoint;
        readonly ILogDataToDb<Deal> _dealLogger;
        static readonly DefaultFactory factory = new DefaultFactory("0393f0fde4d0d4b20c09447c75c653e2-c89a9d13f747598753765dd346f2ffbb",
            AccountType.practice,
            7181960);

        public OrderService()
        {
            var ep = factory.GetEndpoint<OrderEndpoints>();
            var ep2 = new OandaOrderEndpoint(ep);
            _orderEndpoint = ep2;

            _dealLogger = new DealsDbLogger();
        }

        public void OpenOrder(Deal deal)
        {
            if (ReferenceEquals(deal, null) == true)
                throw new ArgumentNullException(nameof(deal));
            _orderEndpoint.CreateMarketOrder(deal, _dealLogger);
        }
    }
}
