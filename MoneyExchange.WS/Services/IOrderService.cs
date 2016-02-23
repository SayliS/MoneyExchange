using MoneyExchangeWS.Dtos;
using MoneyExchangeWS.Orders;

namespace MoneyExchangeWS.Services
{
    public interface IOrderService
    {
        void OpenOrder(IOrder order);
        IOrder ConverFromDeal(Deal deal);
    }
}