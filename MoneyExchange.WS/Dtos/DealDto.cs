using System;
using MoneyExchangeWS.Orders;

namespace MoneyExchangeWS.Dtos
{
    public class Deal
    {
        Deal() { }

        public Deal(int kassaDealId, int rowNumber)
        {
            Id = string.Format("{0}@{1}", kassaDealId, rowNumber);
        }

        public Deal(int kassaDealId, int rowNumber, OrderOperation operation, string currency, float units)
            : this(kassaDealId, rowNumber)
        {
            if (ReferenceEquals(operation, null) == true)
                throw new ArgumentNullException(nameof(operation));

            if (string.IsNullOrWhiteSpace(currency) == true)
                throw new ArgumentNullException(nameof(currency));

            OperationId = (int)operation;
            Currency = currency;
            Units = units;
        }

        public string Id { get; private set; }

        public int KassaDealID { get { return int.Parse(Id.Split('@')[0]); } }

        public int RowNumber { get { return int.Parse(Id.Split('@')[1]); } }

        public DateTime CreateDate { get; private set; }

        int OperationId { get; set; }

        public string Currency { get; private set; }

        public float Units { get; private set; }

        public OrderOperation Operation
        {
            get
            {
                switch (OperationId)
                {
                    case 1:
                        return OrderOperation.Buy;
                    case 2:
                        return OrderOperation.Sell;
                    default:
                        throw new NotSupportedException($"Operation {OperationId} is not supported");
                }
            }
        }
        public string Instrument { get { return $"EUR_{Currency}"; } }
    }
}
