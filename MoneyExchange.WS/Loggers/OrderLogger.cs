using System.Data;
using Dapper;
using MoneyExchangeWS.Data;
using MoneyExchangeWS.Orders;

namespace MoneyExchangeWS.Loggers
{
    public class OrderLogger : DataWorker, ICanLogToDataBase<IOrder>
    {
        public void Error(IOrder order)
        {
            string statement = "INSERT INTO ERRORS VALUES (@KassaDealID, @RowNumber)";
            using (IDbConnection connection = writeDatabase.CreateOpenConnection())
            {
                //connection.Execute(statement, new { order.KassaDealID, order.RowNumber });
            }
        }

        public void Info(IOrder order)
        {
            string statement = "INSERT INTO INFO VALUES (@KassaDealID, @RowNumber)";
            using (IDbConnection connection = writeDatabase.CreateOpenConnection())
            {
                //connection.Execute(statement, new { order.KassaDealID, order.RowNumber });
            }
        }
    }
}
