using MoneyExchangeWS.Dtos;
using MoneyExchangeWS.Orders;
using MoneyExchangeWS.Repositories.Logging;

namespace MoneyExchangeWS.Endpoints
{
    public interface IHaveOrderEndpoint
    {
        void CreateMarketOrder(IOrder order, ILogToDbRepository<IOrder> orderLogger, ILogToDbRepository<Deal> dealLogger);
    }
}