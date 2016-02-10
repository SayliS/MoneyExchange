using System;
using System.Linq;
using Rabun.Oanda.Rest.Base;
using Rabun.Oanda.Rest.Factories;
using MoneyExchangeWS.Data;
using MoneyExchangeWS.Services;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace MoneyExchange.WS
{
    public class DataBaseObserver
    {
        static IWindsorContainer _container;
        static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(DataBaseObserver));
        static readonly DefaultFactory factory = new DefaultFactory("0393f0fde4d0d4b20c09447c75c653e2-c89a9d13f747598753765dd346f2ffbb",
            AccountType.practice,
            7181960);

        public static void Start(IWindsorContainer container)
        {

            try
            {
                if (ReferenceEquals(container, null) == true)
                    throw new ArgumentNullException(nameof(container));

                _container = container;

                log4net.Config.XmlConfigurator.Configure();
                log.Info(string.Format("Starting {0}", nameof(DataBaseObserver)));

                var dealsRepo = new DealsReadRepository();
                var deals = dealsRepo.GetAll;

                //var orderService = new OrderService(kernel.Get<IHaveOrderEndpoint>(), kernel.Get<ILogDataToDb<Deal>>());
                IOrderService orderService = _container.Resolve<IOrderService>();
                orderService.OpenOrder(deals.First());


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
