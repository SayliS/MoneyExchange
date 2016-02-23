using System;
using Rabun.Oanda.Rest.Endpoints;
using MoneyExchangeWS.Extensions;
using MoneyExchangeWS.Orders;
using MoneyExchangeWS.Repositories.Logging;
using MoneyExchangeWS.Dtos;

namespace MoneyExchangeWS.Endpoints.Oanda
{
    public class OandaOrderEndpoint : IHaveOrderEndpoint
    {
        readonly OrderEndpoints _orderEndpoint;
        static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(OandaOrderEndpoint));

        public OandaOrderEndpoint(OrderEndpoints orderEndpoint)
        {
            if (ReferenceEquals(orderEndpoint, null) == true)
                throw new ArgumentNullException(nameof(orderEndpoint));
            _orderEndpoint = orderEndpoint;
        }

        public void CreateMarketOrder(IOrder order, ILogToDbRepository<IOrder> orderLogger, ILogToDbRepository<Deal> dealLogger)
        {
            try
            {
                var res = _orderEndpoint.CreateMarketOrder(order.Instrument,
                        order.Units,
                        order.Operation.ToSide());

                var x = res.Result.TradeOpened.Id;
                //orderLogger.Info(order);
                dealLogger.Info(order.Deal);
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Cannot create order for {0} {1} {2}", order.Instrument, order.Units, order.Operation), ex);
                orderLogger.Error(order);
                dealLogger.Error(order.Deal);
            }
        }
    }


}
