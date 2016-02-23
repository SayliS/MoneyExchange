namespace MoneyExchangeWS.Repositories.Logging
{
    public interface ILogToDbRepository<T>
    {
        void Info(T obj);
        void Error(T obj);
    }
}