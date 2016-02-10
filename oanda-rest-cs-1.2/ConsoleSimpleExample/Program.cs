using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rabun.Oanda.Rest.Base;
using Rabun.Oanda.Rest.Endpoints;
using Rabun.Oanda.Rest.Models;

namespace ConsoleSimpleExample
{
    class Program
    {
        static void Main(string[] args)
        {
            RateEndpoints rateEndpoints = new RateEndpoints("ec89b162d4a9922c8fa40769c2453d8b-cc1fb522857d46a08a90ef09730343a6", AccountType.practice, 4905675);
            List<InstrumentModel> result = rateEndpoints.GetInstruments().Result;
        }
    }
}
