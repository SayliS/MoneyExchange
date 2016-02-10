using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MoneyExchangeWS.Dtos;
using MoneyExchangeWS.Endpoints;
using MoneyExchangeWS.Endpoints.Oanda;
using MoneyExchangeWS.Logging;
using MoneyExchangeWS.Services;
using Rabun.Oanda.Rest.Base;
using Rabun.Oanda.Rest.Endpoints;
using Rabun.Oanda.Rest.Factories;

namespace MoneyExchangeWS
{
    public class Installers : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container
                .Register(Component.For<OrderEndpoints>().ImplementedBy<OrderEndpoints>().LifestyleTransient()
                    .DependsOn(Dependency.OnValue("key", "0393f0fde4d0d4b20c09447c75c653e2-c89a9d13f747598753765dd346f2ffbb"),
                               Dependency.OnValue("accountType", AccountType.practice),
                               Dependency.OnValue("accountId", 7181960))
                )
                .Register(Component.For<IHaveOrderEndpoint>().ImplementedBy<OandaOrderEndpoint>().LifestyleTransient())
                .Register(Component.For<ILogDataToDb<Deal>>().ImplementedBy<DealsDbLogger>().LifestyleTransient())
                .Register(Component.For<IOrderService>().ImplementedBy<OrderService>().LifestyleTransient());
        }

    }
}