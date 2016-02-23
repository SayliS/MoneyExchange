namespace MoneyExchangeWS.Endpoints
{
    public interface IHaveRateEndpoint
    {
        float GetSellPrice(string term);

        float GetBuyPrice(string term);
    }
}