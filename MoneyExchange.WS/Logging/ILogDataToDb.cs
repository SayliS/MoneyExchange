namespace MoneyExchangeWS.Logging
{
    public interface ILogDataToDb<T>
    {
        void Info(T obj);
        void Error(T obj);
    }
}