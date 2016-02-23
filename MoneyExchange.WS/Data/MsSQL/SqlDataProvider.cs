using System;
using System.Data;
using System.Data.SqlClient;

namespace MoneyExchangeWS.Data.MsSQL
{
    public sealed class SQLDataBaseProvider : IDataBase
    {
        static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(SQLDataBaseProvider));
        string _connectionString;

        public SQLDataBaseProvider(string server, string dataBase, string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(server) == true)
                throw new ArgumentNullException(nameof(server));

            if (string.IsNullOrWhiteSpace(dataBase) == true)
                throw new ArgumentNullException(nameof(dataBase));

            if (string.IsNullOrWhiteSpace(userName) == true)
                throw new ArgumentNullException(nameof(userName));

            if (string.IsNullOrWhiteSpace(password) == true)
                throw new ArgumentNullException(nameof(password));

            _connectionString = string.Format("Server={0};Database={1};User Id={2};Password={3};",
            server, dataBase, userName, password);
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public IDbCommand CreateCommand()
        {
            return new SqlCommand();
        }

        public IDbConnection CreateOpenConnection()
        {
            SqlConnection connection = (SqlConnection)CreateConnection();
            connection.Open();

            return connection;
        }

        public IDbCommand CreateCommand(string commandText, IDbConnection connection)
        {
            SqlCommand command = (SqlCommand)CreateCommand();

            command.CommandText = commandText;
            command.Connection = (SqlConnection)connection;
            command.CommandType = CommandType.Text;

            return command;
        }

        public IDbCommand CreateStoredProcCommand(string procName, IDbConnection connection)
        {
            SqlCommand command = (SqlCommand)CreateCommand();

            command.CommandText = procName;
            command.Connection = (SqlConnection)connection;
            command.CommandType = CommandType.StoredProcedure;

            return command;
        }

        public IDataParameter CreateParameter(string parameterName, object parameterValue)
        {
            return new SqlParameter(parameterName, parameterValue);
        }
    }
}
