using System;
using Rabun.Oanda.Rest.Endpoints;
using MoneyExchangeWS.Extensions;
using MoneyExchangeWS.Loggers;
using MoneyExchangeWS.Orders;

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

        public void CreateMarketOrder(IOrder order, ICanLogToDataBase<IOrder> orderLogger)
        {
            if (ReferenceEquals(order, null) == true)
                throw new ArgumentNullException(nameof(order));

            if (ReferenceEquals(orderLogger, null) == true)
                throw new ArgumentNullException(nameof(orderLogger));

            try
            {
                var res = _orderEndpoint.CreateMarketOrder(order.Instrument,
                        order.Units,
                        order.Operation.ToSide());

                order.SetExternalId(res.Result.TradeOpened.Id);
                orderLogger.Info(order);
                log.Info($"Order {order.ExternalId} created. Instrument={order.Instrument}, Units={order.Units} Operation={order.Operation}");
            }
            catch (Exception ex)
            {
                var errorMessage = $"Cannot create order for Instrument={order.Instrument}, Units={order.Units} Operation={order.Operation}";
                log.Error(errorMessage, ex);
                orderLogger.Error(order, ex.InnerException.Message);
            }
        }
    }


}
