﻿using System;
using Castle.Windsor;
using Quartz;
using MoneyExchangeWS.Data;
using MoneyExchangeWS.Dtos;
using MoneyExchangeWS.Services;

namespace MoneyExchange.WS
{
    [DisallowConcurrentExecution]
    public class DataBaseObserver : IJob
    {
        static IWindsorContainer _container;
        static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(DataBaseObserver));

        public static void Start(IWindsorContainer container)
        {
            try
            {
                log4net.Config.XmlConfigurator.Configure();
                log.Info($"Starting {nameof(DataBaseObserver)}");

                if (ReferenceEquals(container, null) == true)
                    throw new ArgumentNullException(nameof(container));
                _container = container;

                var readonlyDealsRepository = _container.Resolve<IReadOnlyRepository<Deal>>();
                var orderService = _container.Resolve<IOrderService>();

                var deals = readonlyDealsRepository.GetAll;
                foreach (var deal in deals)
                {
                    var order = orderService.ConverFromDeal(deal);
                    orderService.OpenOrder(order);
                }
            }
            catch (Exception ex)
            {
                log.Error($"Error in {nameof(DataBaseObserver)}", ex);
            }
        }

        public static void Stop()
        {
            log.Info($"Stopping {nameof(DataBaseObserver)}");
        }

        public void Execute(IJobExecutionContext context)
        {
            var container = context.JobDetail.JobDataMap.Get("container") as IWindsorContainer;
            Start(container);
        }
    }
}
