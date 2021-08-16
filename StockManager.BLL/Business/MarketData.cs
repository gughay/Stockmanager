using StockManager.BLL.Enums;
using StockManager.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using YahooFinanceApi;

namespace StockManager.BLL.Business
{
    public  class MarketData : IMarketData
    {
        public List<Stock> GetMarketdata(MarketType marketType, string ticker, DateTime start, DateTime end, Period period) 
        {
            List<Stock> result = null;
            switch (marketType)
            {
                case MarketType.YahooFInance:
                    result = GetYahooMarketData(ticker,  start,  end,  period);
                    break;
                case MarketType.AlpacaMarkets:
                    break;
                case MarketType.AlphaVantage:
                    break;
                case MarketType.IESCloud:
                    break;
                case MarketType.Polygon:
                    break;
                default:
                    break;
            }
            return result;
        }

        #region Markets

        private List<Stock> GetYahooMarketData(string ticker, DateTime start, DateTime end, Period period)
        {
            var result = new List<Stock>();
            var yahooData =Yahoo.GetHistoricalAsync(ticker, start, end, period).Result;
            var performanceData = string.Empty;
            var firstDayPrice = yahooData[0].Close;
            foreach (var r in yahooData)
            {
                //TO DO Performance data
                performanceData = SetPerformanceData(firstDayPrice, r.Close);
                result.Add(new Stock
                {
                    Ticker = ticker,
                    Date = r.DateTime.ToString("yyyy-MM-dd"),
                    Open = r.Open,
                    High = r.High,
                    Low = r.Low,
                    Close = r.Close,
                    AdjustedClose = r.AdjustedClose,
                    Volume = r.Volume,
                    PerformanceData = performanceData
                });

            }
            return result;
        }

        private string SetPerformanceData(decimal firstDayPrice, decimal current)
        {
            return $"{current - firstDayPrice}%";
        }

        #endregion
    }
}
