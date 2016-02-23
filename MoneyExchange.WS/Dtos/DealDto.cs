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

        int OperationId { get; set; }

        public string Currency { get; private set; }

        public int Units { get; private set; }

        public int KassaDealID { get { return int.Parse(Id.Split('@')[0]); } }

        public int RowNumber { get { return int.Parse(Id.Split('@')[1]); } }

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
        public string Instrument { get { return "EUR_USD"; } }
    }
}
