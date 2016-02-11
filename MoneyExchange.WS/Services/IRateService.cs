namespace MoneyExchangeWS.Services
{
    public interface IRateService
    {
        float GetAskPrice(string term);
    }
}