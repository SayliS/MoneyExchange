namespace MoneyExchangeWS.Services
{
    public interface IRateService
    {
        float GetSellPrice(string instrument);
        float GetBuyPrice(string instrument);
    }
}