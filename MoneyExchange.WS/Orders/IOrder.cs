using MoneyExchangeWS.Dtos;

namespace MoneyExchangeWS.Orders
{
    public interface IOrder
    {
        string Instrument { get; }
        int Units { get; }
        OrderOperation Operation { get; }
        Deal Deal { get; }
    }
}
