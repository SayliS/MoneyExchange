using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rabun.Oanda.Rest.Base;
using Rabun.Oanda.Rest.Endpoints;
using Rabun.Oanda.Rest.Models;

namespace Rabun.Oanda.Rest.Test.Endpoints
{
    [TestClass]
    public class PositionEndpointsTest
    {
        private readonly PositionEndpoints _positionEndpoints;
        public PositionEndpointsTest()
        {
            _positionEndpoints = new PositionEndpoints("ec89b162d4a9922c8fa40769c2453d8b-cc1fb522857d46a08a90ef09730343a6", AccountType.practice, 4905675);
        }

        #region GetPositionsTest

        [TestMethod]
        public async Task GetPositionsTest()
        {
            List<Position> positions = await _positionEndpoints.GetPositions();
            Assert.IsNotNull(positions);
            Assert.IsTrue(positions.Count > 0);
        }

        #endregion

        #region GetPositionTest

        [TestMethod]
        public async Task GetPositionTest()
        {
            Position position = await _positionEndpoints.GetPosition("EUR_USD");
            Assert.IsNotNull(position);
        }

        #endregion

        #region ClosePositionTest

        [TestMethod]
        public async Task ClosePositionTest()
        {
            PositionClosed position = await _positionEndpoints.ClosePosition("EUR_USD");
            Assert.IsNotNull(position);
        }

        #endregion
    }
}
