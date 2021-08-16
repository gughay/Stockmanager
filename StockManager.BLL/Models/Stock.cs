using System;
using System.Collections.Generic;
using System.Text;

namespace StockManager.BLL.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string Ticker { get; set; }
        public string Date { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public decimal AdjustedClose { get; set; }
        public decimal Volume { get; set; }
        public string  PerformanceData { get; set; }
    }
}
