using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using MoneyExchangeWS.Dtos;

namespace MoneyExchangeWS.Data
{
    public class MockedReadRepository : IReadOnlyRepository<Deal>
    {
        public IEnumerable<Deal> GetAll
        {
            get
            {
                return new List<Deal> {
                      new Deal(1, 1) { Currency = "GBP", OperationId = 1, Units = 100 },
                      new Deal(2, 2) { Currency = "GBP", OperationId = 2, Units = 500 }
                };
            }
        }

        public Deal GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}