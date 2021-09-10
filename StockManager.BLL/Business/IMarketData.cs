using StockManager.BLL.Enums;
using StockManager.BLL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YahooFinanceApi;

namespace StockManager.BLL.Business
{
    public interface IMarketData
    {
        Task<List<Stock>> GetMarketdata(MarketType marketType, string ticker, DateTime start, DateTime end, Period period);
    }
}
