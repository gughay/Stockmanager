using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StockManager.BLL.Business;

namespace StockManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IStockService _stockService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IStockService stockService)
        {
            _logger = logger;
            _stockService = stockService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var web = new System.Net.WebClient();
            var ttt=web.DownloadString("https://finance.yahoo.com/d/quotes.csv?s=amz");
        

            _stockService.f();
            return null;
        }
    }
}
