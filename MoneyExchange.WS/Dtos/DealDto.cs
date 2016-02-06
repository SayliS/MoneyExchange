using System;

namespace MoneyExchangeWS.Dtos
{
    //public class Deal
    //{
    //    public int Id { get; private set; }

    //    public decimal Amount { get; set; }

    //    public decimal CurrencyRate { get; set; }

    //    public string CurrencyBuyType { get; set; }

    //    public string CurrencySellType { get; set; }

    //    public DateTime CreateDate { get; set; }

    //    public DateTime ImportDate { get; set; }

    //    public Deal(int id)
    //    {
    //        Id = id;
    //    }
    //}

    public class DealDto
    {
        public int KassaDealID { get; private set; }

        public DateTime KassaDealDate { get; set; }

        public DealDto(int kasaId)
        {
            KassaDealID = kasaId;
        }

        DealDto() { }
    }
}
