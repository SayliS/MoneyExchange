using MoneyExchangeWS.Dtos;

namespace MoneyExchangeWS.Orders
{
    public interface IOrder
    {
        string Instrument { get; }
        OrderOperation Operation { get; }
        Deal Deal { get; }
        int Units { get; }
        float EuroCource { get; }
        long ExternalId { get; }

        void AddExternalId(long externalId);
    }
}
