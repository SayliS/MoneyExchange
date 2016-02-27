using System;
using System.Data;
using Dapper;
using MoneyExchangeWS.Data;
using MoneyExchangeWS.Orders;

namespace MoneyExchangeWS.Loggers
{
    public class OrderLogger : DataWorker, ICanLogToDataBase<IOrder>
    {

        public void Error(IOrder order, string message)
        {
            if (ReferenceEquals(order, null) == true)
                throw new ArgumentNullException(nameof(order));

            string statement = @"INSERT INTO OandaErrors(DealComplexId, OandaTradeId, OandaInstrument, 
                                                                   OandaOperation, OandaEuroCource, OandaUnits,
                                                                   DealCurrency, DealOperation, DealUnits, ErrorMessage)
                                        VALUES (@DealComplexId, @OandaTradeId, @OandaInstrument,
                                                @OandaOperation, @OandaEuroCource, @OandaUnits,
                                                @DealCurrency, @DealOperation, @DealUnits, @ErrorMessage);";
            using (IDbConnection connection = writeDatabase.CreateOpenConnection())
            {
                connection.Execute(statement,
                    new
                    {
                        DealComplexId = order.Deal.Id,
                        OandaTradeId = order.ExternalId,
                        OandaInstrument = order.Instrument,
                        OandaOperation = order.Operation,
                        OandaEuroCource = order.EuroCource,
                        OandaUnits = order.Units,
                        DealCurrency = order.Deal.Currency,
                        DealOperation = order.Deal.Operation,
                        DealUnits = order.Deal.Units,
                        ErrorMessage = message
                    });
            }
        }

        public void Info(IOrder order)
        {
            if (ReferenceEquals(order, null) == true)
                throw new ArgumentNullException(nameof(order));

            string statement = @"INSERT INTO OandaSuccessfulTrades(DealComplexId, OandaTradeId, OandaInstrument, 
                                                                   OandaOperation, OandaEuroCource, OandaUnits,
                                                                   DealCurrency, DealOperation, DealUnits)
                                        VALUES (@DealComplexId, @OandaTradeId, @OandaInstrument,
                                                @OandaOperation, @OandaEuroCource, @OandaUnits,
                                                @DealCurrency, @DealOperation, @DealUnits);";
            using (IDbConnection connection = writeDatabase.CreateOpenConnection())
            {
                connection.Execute(statement,
                    new
                    {
                        DealComplexId = order.Deal.Id,
                        OandaTradeId = order.ExternalId,
                        OandaInstrument = order.Instrument,
                        OandaOperation = order.Operation,
                        OandaEuroCource = order.EuroCource,
                        OandaUnits = order.Units,
                        DealCurrency = order.Deal.Currency,
                        DealOperation = order.Deal.Operation,
                        DealUnits = order.Deal.Units

                    });
            }
        }
    }
}
