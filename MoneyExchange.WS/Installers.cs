using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Rabun.Oanda.Rest.Base;
using Rabun.Oanda.Rest.Endpoints;
using MoneyExchangeWS.Data;
using MoneyExchangeWS.Dtos;
using MoneyExchangeWS.Endpoints;
using MoneyExchangeWS.Endpoints.Oanda;
using MoneyExchangeWS.Loggers;
using MoneyExchangeWS.Services;
using MoneyExchangeWS.Orders;
using System.Configuration;
using System;

namespace MoneyExchangeWS
{
    public class Installers : IWindsorInstaller
    {
        static readonly string apiKey = ConfigurationManager.AppSettings.Get("OandaApiKey");
        static readonly AccountType аccountType = (AccountType)Enum.Parse(typeof(AccountType), ConfigurationManager.AppSettings.Get("OandaAccountType"), true);
        static readonly int accountId = int.Parse(ConfigurationManager.AppSettings.Get("OandaAccountId"));

        Dependency[] oandaDependencies = {
            Dependency.OnValue("key", apiKey),
            Dependency.OnValue("accountType", аccountType),
            Dependency.OnValue("accountId", accountId)
        };
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container
                .Register(Component.For<OrderEndpoints>().ImplementedBy<OrderEndpoints>().LifestyleTransient()
                    .DependsOn(oandaDependencies))
                .Register(Component.For<RateEndpoints>().ImplementedBy<RateEndpoints>().LifestyleTransient()
                    .DependsOn(oandaDependencies))
                .Register(Component.For<IHaveRateEndpoint>().ImplementedBy<OandaRateEndpoint>().LifestyleTransient())
                .Register(Component.For<IHaveOrderEndpoint>().ImplementedBy<OandaOrderEndpoint>().LifestyleTransient())
                .Register(Component.For<ICanLogToDataBase<IOrder>>().ImplementedBy<OrderLogger>().LifestyleTransient())
                .Register(Component.For<IOrderService>().ImplementedBy<OrderService>().LifestyleTransient())
                .Register(Component.For<IRateService>().ImplementedBy<RateService>().LifestyleTransient())
                .Register(Component.For<IReadOnlyRepository<Deal>>().ImplementedBy<DealsReadRepository>().LifestyleTransient());
            //.Register(Component.For<IReadOnlyRepository<Deal>>().ImplementedBy<MockedReadRepository>().LifestyleTransient());
        }
    }
}