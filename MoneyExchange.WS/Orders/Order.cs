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
                EuroCource = rateService.GetBuyPrice(deal.Instrument);
            else if (Operation == OrderOperation.Sell)
                EuroCource = rateService.GetSellPrice(deal.Instrument);
            else
                throw new NotSupportedException("Wrong OrderOperation");

            var euroSum = (int)Math.Round(deal.Units / EuroCource, 0);
            Units = euroSum;

        }

        public Deal Deal => deal;

        public string Instrument => deal.Instrument;

        public int Units { get; private set; }

        public float EuroCource { get; private set; }

        public long ExternalId { get; private set; }

        public OrderOperation Operation
        {
            get
            {
                if (deal.Operation == OrderOperation.Buy)
                    return OrderOperation.Sell;

                if (deal.Operation == OrderOperation.Sell)
                    return OrderOperation.Buy;

                throw new NotSupportedException("Wrong OrderOperation");
            }
        }

        public void SetExternalId(long externalId)
        {
            ExternalId = externalId;
        }
    }
}