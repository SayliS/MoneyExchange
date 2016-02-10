namespace MoneyExchangeWS.Endpoints
{
    public interface IHaveRateEndpoint
    {
        float GetAskPrice(string term);
    }
}