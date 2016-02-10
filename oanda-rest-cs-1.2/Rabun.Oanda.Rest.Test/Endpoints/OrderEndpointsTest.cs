using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rabun.Oanda.Rest.Endpoints;
using Rabun.Oanda.Rest.Base;
using Rabun.Oanda.Rest.Models;

namespace Rabun.Oanda.Rest.Test.Endpoints
{
    [TestClass]
    public class OrderEndpointsTest
    {
        private readonly OrderEndpoints _orderEndpoints;
        public OrderEndpointsTest()
        {
            _orderEndpoints = new OrderEndpoints("906f5516de0f0c6b81ead9313907b083-c86648426a63ee68feade8531c5468e0", AccountType.practice, 4905675);
        }

        #region GetOrdersTest

        [TestMethod]
        public async Task GetOrdersTest()
        {
            List<Order> orders = await _orderEndpoints.GetOrders();
            Assert.IsNotNull(orders);
            Assert.IsTrue(orders.Count > 0);
        }

        [TestMethod]
        public async Task GetOrdersByInstrumentTest()
        {
            List<Order> orders = await _orderEndpoints.GetOrders("EUR_USD");
            Assert.IsNotNull(orders);
            Assert.IsTrue(orders.Count > 0);
        }

        [TestMethod]
        public async Task GetOrdersByInstrumentAndCountTest()
        {
            List<Order> orders = await _orderEndpoints.GetOrders("EUR_USD", 5);
            Assert.IsNotNull(orders);
            Assert.IsTrue(orders.Count == 3);
        }

        [TestMethod]
        public async Task GetOrdersByAllTest()
        {
            List<Order> orders = await _orderEndpoints.GetOrders("EUR_USD", 5, null, null);
            Assert.IsNotNull(orders);
            Assert.IsTrue(orders.Count == 3);
        }

        #endregion

        #region GetOrderTest

        [TestMethod]
        public async Task GetOrderTest()
        {
            Order order = await _orderEndpoints.GetOrder(965436841);
            Assert.IsNotNull(order);
        }

        #endregion

        #region CreateOrderTest

        [TestMethod]
        public async Task CreateOrderTest()
        {
            OrderOpen order = await _orderEndpoints.CreateOrder("EUR_USD", 777, OandaTypes.Side.buy, OandaTypes.OrderType.marketIfTouched, DateTime.Now.AddDays(1), 1.1630f,null, null, null, null, null);
            Assert.IsNotNull(order);
        }

        [TestMethod]
        public async Task CreateMarketOrderTest()
        {
            OrderOpen order = await _orderEndpoints.CreateMarketOrder("EUR_USD", 999, OandaTypes.Side.buy);
            Assert.IsNotNull(order);
        }

        [TestMethod]
        public async Task CreateMarketOrderTest01()
        {
            OrderOpen order = await _orderEndpoints.CreateMarketOrder("EUR_USD", 1000, OandaTypes.Side.buy,1.13343f,1.13998f);
            Assert.IsNotNull(order);
        }

        [TestMethod]
        public async Task CreateMarketIfTouchedOrderTest()
        {
            OrderOpen order = await _orderEndpoints.CreateMarketIfTouchedOrder("EUR_USD", 999, OandaTypes.Side.buy, DateTime.Now.AddDays(1), 1.4f);
            Assert.IsNotNull(order);
        }

        #endregion

        #region UpdateOrderTest

        [TestMethod]
        public async Task UpdateOrderTest()
        {
            OrderMarketIfTouched order = await _orderEndpoints.UpdateOrder(965436841, 333, 1.1f, null, null, null, null, null, null);
            Assert.IsNotNull(order);
        }

        #endregion

        #region CloseOrderTest

        [TestMethod]
        public async Task CloseOrder()
        {
            OrderClosed order = await _orderEndpoints.CloseOrder(965875303);
            Assert.IsNotNull(order);
        }

        #endregion
    }
}
