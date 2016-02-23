using Dapper;
using MoneyExchangeWS.Data;
using MoneyExchangeWS.Dtos;
using System.Collections.Generic;
using System.Data;

namespace MoneyExchangeWS.Repositories.Logging
{
    public class DealsLogRepository : DataWorker, ILogToDbRepository<Deal>
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