using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Stock
{
    public class StockDto
    {
        public string Symbol { get; internal set; }
        public string CompanyName { get; internal set; }
        public decimal Purchase { get; internal set; }
        public decimal LastDiv { get; internal set; }
        public long MarketCup { get; internal set; }
        public int Id { get; internal set; }
        public string Industry { get; internal set; }
    }
}