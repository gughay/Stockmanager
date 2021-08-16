using StockManager.BLL.Enums;
using StockManager.BLL.Models;
using System;
using System.Collections.Generic;
using YahooFinanceApi;
using DAL = StcokManager.DAL.Entities;

namespace StockManager.BLL.Business
{
    public interface IStockService
    {
        List<Stock> GetHistoricalData(MarketType marketType, string ticker, DateTime start, DateTime end, Period period);
        void SaveData(List<Stock> stocks);
    }
}
