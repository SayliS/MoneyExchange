using System.Data;
using System.Data.SqlClient;

namespace MoneyExchangeWS.Data.MsSQL
{
    public sealed class SQLDataBaseProvider : IDataBase
    {
        static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(SQLDataBaseProvider));

        static readonly string _server = @"DESKTOP-BRDGFPA";
        static readonly string _dataBase = "Eurosys";
        static readonly string _userName = "moneyexchange";
        static readonly string _password = "123qwe";
        static readonly string _connectionString = string.Format("Server={0};Database={1};User Id={2};Password={3};",
            _server, _dataBase, _userName, _password);

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
