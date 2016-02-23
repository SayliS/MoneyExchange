﻿using System;
using Rabun.Oanda.Rest.Endpoints;
using MoneyExchangeWS.Dtos;
using MoneyExchangeWS.Extensions;
using MoneyExchangeWS.Repositories.Logging;
using MoneyExchangeWS.Services;

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

        public void CreateMarketOrder(Deal deal, ILogToDbRepository<Deal> dealLogger, IRateService rateService)
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


}
