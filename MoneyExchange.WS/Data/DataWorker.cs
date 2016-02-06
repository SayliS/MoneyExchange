using System;
using MoneyExchangeWS.Data.MsSQL;

namespace MoneyExchangeWS.Data
{
    public class DataWorker
    {
        static IDataBase _database = null;

        static DataWorker()
        {
            try
            {
                _database = new SQLDataBaseSingleton();
            }
            catch (Exception excep)
            {
                throw excep;
            }
        }

        public static IDataBase database
        {
            get { return _database; }
        }
    }
}