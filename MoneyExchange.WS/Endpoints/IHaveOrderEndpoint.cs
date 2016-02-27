using MoneyExchangeWS.Loggers;
using MoneyExchangeWS.Orders;

namespace MoneyExchangeWS.Endpoints
{
    public interface IHaveOrderEndpoint
    {
        void CreateMarketOrder(IOrder order, ICanLogToDataBase<IOrder> orderLogger);
    }
}