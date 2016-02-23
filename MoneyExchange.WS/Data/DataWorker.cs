using System;
using MoneyExchangeWS.Data.MsSQL;

namespace MoneyExchangeWS.Data
{
    public class DataWorker
    {
        // TODO: APP SETTINGS
        static IDataBase _readDataBase = null;
        static IDataBase _writeDataBase = null;
        static readonly string _server = @"DESKTOP-BRDGFPA";
        static readonly string _readDbName = "Eurosys";
        static readonly string _writeDbName = "MoneyExchange";
        static readonly string _userName = "moneyexchange";
        static readonly string _password = "123qwe";

        static DataWorker()
        {
            try
            {
                _readDataBase = new SQLDataBaseProvider(_server, _readDbName, _userName, _password);
                _writeDataBase = new SQLDataBaseProvider(_server, _writeDbName, _userName, _password);
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