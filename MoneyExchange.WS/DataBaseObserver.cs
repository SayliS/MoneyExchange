using System;
using System.Linq;
using Castle.Windsor;
using MoneyExchangeWS.Data;
using MoneyExchangeWS.Dtos;
using MoneyExchangeWS.Services;

namespace MoneyExchange.WS
{
    public class DataBaseObserver
    {
        static IWindsorContainer _container;
        static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(DataBaseObserver));

        public static void Start(IWindsorContainer container)
        {
            try
            {
                log4net.Config.XmlConfigurator.Configure();
                log.Info(string.Format("Starting {0}", nameof(DataBaseObserver)));

                if (ReferenceEquals(container, null) == true)
                    throw new ArgumentNullException(nameof(container));
                _container = container;

                var readonlyDealsRepository = _container.Resolve<IReadOnlyRepository<Deal>>();
                var deals = readonlyDealsRepository.GetAll;

                IOrderService orderService = _container.Resolve<IOrderService>();
                var order = orderService.ConverFromDeal(deals.First());//todo fix
                orderService.OpenOrder(order);
            }
            catch (Exception ex)
            {

                log.Error(string.Format("Error in {0}", nameof(DataBaseObserver)), ex);
            }

        }

        public static void Stop()
        {
            log.Info(string.Format("Stopping {0}", nameof(DataBaseObserver)));
        }
    }
}
