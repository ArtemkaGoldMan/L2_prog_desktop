using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPriceMonitoring
{
    public interface IStockObserver
    {
        void Update(Stock stock, decimal oldPrice, decimal newPrice);
    }
}
