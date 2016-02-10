using MoneyExchangeWS.Dtos;
using MoneyExchangeWS.Logging;

namespace MoneyExchangeWS.Endpoints
{
    public interface IHaveOrderEndpoint
    {
        void CreateMarketOrder(Deal deal, ILogDataToDb<Deal> dealLogger);
    }
}