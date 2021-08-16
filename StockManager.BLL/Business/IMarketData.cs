using StockManager.BLL.Enums;
using StockManager.BLL.Models;
using System;
using System.Collections.Generic;
using YahooFinanceApi;

namespace StockManager.BLL.Business
{
    public interface IMarketData
    {
        List<Stock> GetMarketdata(MarketType marketType, string ticker, DateTime start, DateTime end, Period period);
    }
}
