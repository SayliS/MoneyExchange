using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using MoneyExchangeWS.Dtos;

namespace MoneyExchangeWS.Data
{
    public class DealsReadRepository : DataWorker, IReadOnlyRepository<Deal>
    {
        readonly static string _mainDealsView = "DealsForOandaView";

        public IEnumerable<Deal> GetAll
        {
            get
            {
                using (IDbConnection connection = database.CreateOpenConnection())
                {
                    var deals = connection.Query<Deal>(string.Format("select * from {0}", _mainDealsView));
                    return deals;
                }
            }
        }

        public Deal GetById(int kasaDealId)
        {
            return GetById(kasaDealId, 1);
        }

        public Deal GetById(int kasaDealId, int rowNumber)
        {
            return GetById(string.Format("{0}@{1}", kasaDealId, rowNumber));
        }

        public Deal GetById(string id)
        {
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                var deal = connection.Query<Deal>(string.Format("select * from {0} where Id = @Id", _mainDealsView),
                    new { mainDealsView = _mainDealsView, Id = id }).Single();
                return deal;
            }
        }

    }
}
