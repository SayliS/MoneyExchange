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

        public string Id { get; private set; }

        public DateTime CreateDate { get; private set; }

        public int OperationId { get; set; }

        public int KassaDealID { get { return int.Parse(Id.Split('@')[0]); } }

        public int RowNumber { get { return int.Parse(Id.Split('@')[1]); } }

        public string Currency { get; set; }

        public float Units { get; set; }

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
                        throw new NotSupportedException(string.Format("Operation {0} is not supported", OperationId));
                }
            }
        }
        public string Instrument { get { return $"EUR_{Currency}"; } }
    }
}
