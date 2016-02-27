using System.Data;
using Dapper;
using MoneyExchangeWS.Data;
using MoneyExchangeWS.Dtos;

namespace MoneyExchangeWS.Loggers
{
    public class DealLogger : DataWorker, ICanLogToDataBase<Deal>
    {
        public void Error(Deal deal)
        {
            string statement = "INSERT INTO ERRORS VALUES (@KassaDealID, @RowNumber)";
            using (IDbConnection connection = writeDatabase.CreateOpenConnection())
            {
                connection.Execute(statement, new { deal.KassaDealID, deal.RowNumber });
            }
        }

        public void Info(Deal deal)
        {
            string statement = "INSERT INTO INFO VALUES (@KassaDealID, @RowNumber)";
            using (IDbConnection connection = writeDatabase.CreateOpenConnection())
            {
                connection.Execute(statement, new { deal.KassaDealID, deal.RowNumber });
            }
        }
    }
}