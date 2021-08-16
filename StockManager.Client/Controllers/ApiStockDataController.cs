using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StockManager.BLL.Business;
using StockManager.BLL.Enums;
using YahooFinanceApi;
using StockManager.BLL.Models;

namespace StockManager.Client.Controllers
{
    [Produces("application/json")]
    public class ApiStockDataController : Controller
    {
        private readonly IStockService _stockService;
        public ApiStockDataController(IStockService stockServic)
        {
            _stockService = stockServic;
        }
        [Route("~/api/ApiStockData/{ticker}/{start}/{end}/{period}")]
        [HttpGet]
        public List<Stock> GetStockData(string ticker, string start, string end, string period)
        {
            var p = Period.Daily;
            if (period.ToLower() == "weekly") p = Period.Weekly;
            else if (period.ToLower() == "monthly") p = Period.Monthly;
            var startDate = DateTime.Parse(start);
            var endDate = DateTime.Parse(end);
            var stockdata = _stockService.GetHistoricalData(MarketType.YahooFInance, ticker, startDate, endDate, p);
            return stockdata;
        }
    }
}
