using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Rabun.Oanda.Rest.Base;
using Rabun.Oanda.Rest.Endpoints;
using MoneyExchangeWS.Data;
using MoneyExchangeWS.Dtos;
using MoneyExchangeWS.Endpoints;
using MoneyExchangeWS.Endpoints.Oanda;
using MoneyExchangeWS.Repositories.Logging;
using MoneyExchangeWS.Services;

namespace MoneyExchangeWS
{
    public class Installers : IWindsorInstaller
    {
        static readonly string _key = "0393f0fde4d0d4b20c09447c75c653e2-c89a9d13f747598753765dd346f2ffbb";
        static readonly AccountType _аccountType = AccountType.practice;
        static readonly int _accountId = 7181960;

        Dependency[] oandaDependencies = {
            Dependency.OnValue("key", _key),
            Dependency.OnValue("accountType", _аccountType),
            Dependency.OnValue("accountId", _accountId)
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
                .Register(Component.For<ILogToDbRepository<Deal>>().ImplementedBy<DealsLogRepository>().LifestyleTransient())
                .Register(Component.For<IReadOnlyRepository<Deal>>().ImplementedBy<DealsReadRepository>().LifestyleTransient())
                .Register(Component.For<IOrderService>().ImplementedBy<OrderService>().LifestyleTransient())
                .Register(Component.For<IRateService>().ImplementedBy<RateService>().LifestyleTransient());
        }

    }
}