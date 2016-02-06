using System;
using MoneyExchangeWS.Data;
using Rabun.Oanda.Rest.Endpoints;
using Rabun.Oanda.Rest.Base;
using Rabun.Oanda.Rest.Factories;
using static Rabun.Oanda.Rest.Models.OandaTypes;

namespace MoneyExchange.WS
{
    public class DataBaseObserver
    {
        static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(DataBaseObserver));
        static readonly DefaultFactory factory = new DefaultFactory("0393f0fde4d0d4b20c09447c75c653e2-c89a9d13f747598753765dd346f2ffbb",
            AccountType.practice,
            7181960);

        public static void Start()
        {
            try
            {
                log4net.Config.XmlConfigurator.Configure();
                log.Info(string.Format("Starting {0}", nameof(DataBaseObserver)));

                DealsReadRepository dealsRepo = new DealsReadRepository();
                //var deals = dealsRepo.GetAll;
                var deal = dealsRepo.GetById(311949);


                GetExchangeRates();
                OpenOrder();


            }
            catch (Exception ex)
            {

                log.Error(string.Format("Error in {0}", nameof(DataBaseObserver)), ex);
            }

        }

        private static void GetExchangeRates()
        {
            //var api = new ExchangeRates("9582de54ca17b129b523620868936c08-0e0c70e4675a07672685c74089b77b28");
            var x = factory.GetEndpoint<RateEndpoints>();

            var gg2 = x.GetPrices("EUR_USD,EUR_GBP,EUR_CHF,EUR_TRY,EUR_DKK,EUR_SEK,EUR_NOK").Result;



        }

        static void OpenOrder()
        {
            var x = factory.GetEndpoint<OrderEndpoints>();

            var data = x.CreateMarketOrder("EUR_USD", 100, Side.buy);
            var result = data.Result;

        }

        public static void Stop()
        {
            log.Info(string.Format("Stopping {0}", nameof(DataBaseObserver)));
        }
    }


}
