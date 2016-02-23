using System;
using MoneyExchangeWS.Dtos;
using MoneyExchangeWS.Services;

namespace MoneyExchangeWS.Orders
{
    public class Order : IOrder
    {
        readonly IRateService rateService;
        readonly Deal deal;
        public Order(Deal deal, IRateService rateService)
        {

            if (ReferenceEquals(deal, null) == true)
                throw new ArgumentNullException(nameof(deal));

            if (ReferenceEquals(rateService, null) == true)
                throw new ArgumentNullException(nameof(rateService));

            this.deal = deal;
            this.rateService = rateService;
        }

        public Deal Deal
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Instrument
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public OrderOperation Operation
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Units
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}