namespace MoneyExchangeWS.Endpoints
{
    public interface IHaveRateEndpoint
    {
        float GetSellPrice(string instrument);

        float GetBuyPrice(string instrument);
    }
}