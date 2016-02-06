using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using MoneyExchangeWS.Dtos;

namespace MoneyExchangeWS.Data
{
    public class DealsReadRepository : DataWorker, IReadOnlyRepository<DealDto>
    {

        public IEnumerable<DealDto> GetAll
        {
            get
            {
                using (IDbConnection connection = database.CreateOpenConnection())
                {
                    var deals = connection.Query<DealDto>("select KassaDealID, KassaDealDate from KassaDeals");
                    return deals;
                }
            }
        }

        public DealDto GetById(int id)
        {
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                var deal = connection.Query<DealDto>("select KassaDealID, KassaDealDate from KassaDeals where KassaDealID = @KassaDealID",
                    new { KassaDealID = id }).Single();
                return deal;
            }
        }
    }
}
