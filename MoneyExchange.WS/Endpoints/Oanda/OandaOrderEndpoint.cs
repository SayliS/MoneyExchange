using System;
using Rabun.Oanda.Rest.Endpoints;
using Rabun.Oanda.Rest.Models;
using MoneyExchangeWS.Dtos;
using MoneyExchangeWS.Logging;
using MoneyExchangeWS.Extensions;

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

        public void CreateMarketOrder(Deal deal, ILogDataToDb<Deal> dealLogger)
        {
            try
            {
                var res = _orderEndpoint.CreateMarketOrder(deal.Instrument,
                    deal.Units,
                    deal.Operation.ToSide());

                var x = res.Result.TradeOpened.Id;
                dealLogger.Info(deal);
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Cannot create order for {0} {1} {2}", deal.Instrument, deal.Units, deal.Operation), ex);
                dealLogger.Error(deal);
            }
        }
    }

    public enum OrderOperation
    {
        Sell = 1,
        Buy = 2
    }
}
