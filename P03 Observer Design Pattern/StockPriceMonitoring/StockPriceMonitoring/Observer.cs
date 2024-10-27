using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPriceMonitoring
{
    public class Observer : IStockObserver
    {
        public void Update(Stock stock, decimal oldPrice, decimal newPrice)
        {
            decimal change = newPrice - oldPrice;
            decimal percentageChange = Math.Round((change / oldPrice) * 100, 2);
            Console.WriteLine($"Stock: {stock.Symbol}, Old Price: {oldPrice:C}, New Price: {newPrice:C}, Change: {(percentageChange > 0 ? "+" : "")}{percentageChange}%");
        }
    }
}
