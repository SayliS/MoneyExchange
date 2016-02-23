namespace MoneyExchangeWS.Services
{
    public interface IRateService
    {
        float GetSellPrice(string term);
        float GetBuyPrice(string term);
    }
}