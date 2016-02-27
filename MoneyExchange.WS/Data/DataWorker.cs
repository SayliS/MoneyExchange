using System;
using System.Configuration;
using MoneyExchangeWS.Data.MsSQL;

namespace MoneyExchangeWS.Data
{
    public class DataWorker
    {
        static IDataBase _readDataBase = null;
        static IDataBase _writeDataBase = null;
        static readonly string server = ConfigurationManager.AppSettings.Get("SqlServer");
        static readonly string readDbName = ConfigurationManager.AppSettings.Get("SqlReadDataBase");
        static readonly string writeDbName = ConfigurationManager.AppSettings.Get("SqlWriteDataBase");
        static readonly string userName = ConfigurationManager.AppSettings.Get("SqlUserName");
        static readonly string password = ConfigurationManager.AppSettings.Get("SqlPassword");

        static DataWorker()
        {
            try
            {
                _readDataBase = new SQLDataBaseProvider(server, readDbName, userName, password);
                _writeDataBase = new SQLDataBaseProvider(server, writeDbName, userName, password);
            }
            catch (Exception excep)
            {
                throw excep;
            }
        }

        public static IDataBase readDatabase
        {
            get { return _readDataBase; }
        }

        public static IDataBase writeDatabase
        {
            get { return _writeDataBase; }
        }
    }
}