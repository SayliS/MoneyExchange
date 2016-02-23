using System;
using System.Collections.Generic;
using MoneyExchangeWS.Dtos;
using MoneyExchangeWS.Orders;

namespace MoneyExchangeWS.Data
{
    public class MockedReadRepository : IReadOnlyRepository<Deal>
    {
        public IEnumerable<Deal> GetAll
        {
            get
            {
                return new List<Deal> {
                      new Deal(1, 1, OrderOperation.Buy, "GBP", 100),
                      new Deal(1, 1, OrderOperation.Sell, "GBP", 500),
                };
            }
        }

        public Deal GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}