using System.Data;

namespace MoneyExchangeWS.Data
{
    public interface IDataBase
    {
        IDbConnection CreateConnection();
        IDbCommand CreateCommand();
        IDbConnection CreateOpenConnection();
        IDbCommand CreateCommand(string commandText, IDbConnection connection);
        IDbCommand CreateStoredProcCommand(string procName, IDbConnection connection);
        IDataParameter CreateParameter(string parameterName, object parameterValue);
    }
}