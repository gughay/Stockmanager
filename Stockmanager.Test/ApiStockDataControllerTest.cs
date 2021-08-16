using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StockManager.BLL.Business;
using StockManager.BLL.Enums;
using StockManager.BLL.Models;
using StockManager.Client.Controllers;
using System;
using System.Collections.Generic;
using YahooFinanceApi;

namespace Stockmanager.Test
{
    [TestClass]
    public class ApiStockDataControllerTest
    {
        private ApiStockDataController _controller { get; set; }
        private Mock<IStockService> _stockService { get; set; }


        [TestInitialize]
        public void BeforeEach()
        {
            _stockService = new Mock<IStockService>();
            _controller = new ApiStockDataController(_stockService.Object);
        }


        [TestMethod]
        public void TestMethod1()
        {
            _stockService.Setup(o => o.GetHistoricalData(It.IsAny<MarketType>(), It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<Period>())).Returns(new List<Stock> { });

            //action
            var result= _controller.GetStockData("AAPL", "2021-08-10", "2021-08-16", Period.Daily.ToString());


            //Asser
            Assert.IsNotNull(result);
        }
    }
}
