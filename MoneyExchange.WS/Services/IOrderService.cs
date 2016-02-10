using MoneyExchangeWS.Dtos;

namespace MoneyExchangeWS.Services
{
    public interface IOrderService
    {
        void OpenOrder(Deal deal);
    }
}