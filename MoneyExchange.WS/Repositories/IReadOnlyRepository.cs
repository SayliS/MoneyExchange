using System.Collections.Generic;

namespace MoneyExchangeWS.Data
{
    public interface IReadOnlyRepository<T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll { get; }
    }
}
