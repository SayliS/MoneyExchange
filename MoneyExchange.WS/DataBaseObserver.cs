using System;
using MoneyExchangeWS.Data;

namespace MoneyExchange.WS
{
    public class DataBaseObserver
    {
        static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(DataBaseObserver));

        public static void Start()
        {
            try
            {
                log4net.Config.XmlConfigurator.Configure();
                log.Info(string.Format("Starting {0}", nameof(DataBaseObserver)));

                DealsReadRepository dealsRepo = new DealsReadRepository();
                //var deals = dealsRepo.GetAll;
                var deal = dealsRepo.GetById(311949);


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
