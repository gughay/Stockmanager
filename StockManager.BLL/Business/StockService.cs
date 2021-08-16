using StockManager.BLL.Enums;
using StockManager.BLL.Models;
using StockManager.Client.Data;
using System;
using System.Collections.Generic;
using YahooFinanceApi;
using System.Linq;
using DAL = StcokManager.DAL.Entities;

namespace StockManager.BLL.Business
{
    public class StockService : IStockService
    {

        private readonly IMarketData _marketData;
        private readonly StockManagerClientContext _context;
        public StockService(IMarketData marketData, StockManagerClientContext context)
        {
            _marketData = marketData;
            _context = context;
        }
        public List<Stock> GetHistoricalData(MarketType marketType,string ticker, DateTime start, DateTime end, Period period) 
        {
            List<Stock> result = null;
            //Firstly get data from DB if exist
            try
            {
                _context.Stock.Where(d => d.Date >= start && d.Date <= end && d.Ticker == ticker).ToList();
            }
            catch (Exception)
            {

            }
            //GET DATA from public api
            if (result==null)
            {
                result = _marketData.GetMarketdata(marketType, ticker, start, end, period);
                try
                {
                    //SaveData(marketData);
                }
                catch (Exception){}   
            }
            return result;
        }
        public void SaveData(List<Stock> stocks)
        {
            DAL.Stock dbData = null;
            foreach (var item in stocks)
            {
                dbData = new DAL.Stock
                {
                    AdjustedClose = item.AdjustedClose,
                    Close =item.Close,
                    Date = Convert.ToDateTime(item.Date),
                    High = item.High,
                    Low =item.Low,
                    Open = item.Open,
                    PerformanceData =item.PerformanceData,
                    Ticker =item.Ticker,
                    Volume =item.Volume
                };
                _context.Add(dbData);
            }
            _context.SaveChanges();
        }
    }
}
