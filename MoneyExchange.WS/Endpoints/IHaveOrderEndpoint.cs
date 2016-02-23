using MoneyExchangeWS.Dtos;
using MoneyExchangeWS.Repositories.Logging;
using MoneyExchangeWS.Services;

namespace MoneyExchangeWS.Endpoints
{
    public interface IHaveOrderEndpoint
    {
        void CreateMarketOrder(Deal deal, ILogToDbRepository<Deal> dealLogger, IRateService rateService);
    }
}