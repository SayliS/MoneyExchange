using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rabun.Oanda.Rest.Test
{
    [TestClass]
    public class EndpointTest
    {
        [TestMethod]
        public void SetRouteParamsTest()
        {
            string endpoint = "/v1/accounts/:account_id/orders";
            Regex rx = new Regex("[:](\\S[^/]*)");
            MatchCollection matches = rx.Matches(endpoint);

            Dictionary<string, string> rps = new Dictionary<string, string>();
            rps.Add("account_id", "234234");

            Assert.IsTrue(matches.Count > 0);

            foreach (Match match in matches)
            {
                Assert.IsTrue(match.Groups.Count >= 2);
                foreach (KeyValuePair<string, string> routeParam in rps)
                {
                    if (match.Groups[1].Value == routeParam.Key)
                    {
                        endpoint = endpoint.Replace(match.Value, routeParam.Value);
                    }
                }
            }

            Assert.IsTrue(endpoint.Contains("234234"));
        }
    }
}
