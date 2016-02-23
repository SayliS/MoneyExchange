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

            Calculate();
        }

        void Calculate()
        {
            if (Operation == OrderOperation.Buy)
            {
                var euroCource = rateService.GetBuyPrice(deal.Instrument);
                var euroSum = (int)Math.Round(deal.Units / euroCource, 0);

                Units = euroSum;
            }

            if (Operation == OrderOperation.Sell)
            {
                var euroCource = rateService.GetSellPrice(deal.Instrument);
                var euroSum = (int)Math.Round(deal.Units / euroCource, 0);

                Units = euroSum;
            }

        }


        public Deal Deal => deal;

        public string Instrument => deal.Instrument;

        public OrderOperation Operation
        {
            get
            {
                if (deal.Operation == OrderOperation.Buy)
                    return OrderOperation.Sell;
                else
                    return OrderOperation.Buy;
            }
        }

        public int Units { get; private set; }
    }
}