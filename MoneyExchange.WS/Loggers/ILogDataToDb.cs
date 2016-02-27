namespace MoneyExchangeWS.Loggers
{
    public interface ICanLogToDataBase<T>
    {
        void Info(T obj);
        void Error(T obj, string message);
    }
}