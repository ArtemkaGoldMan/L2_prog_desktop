using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPriceMonitoring
{
    public class Stock
    {
        private decimal _price;
        private readonly List<IStockObserver> _observers = new List<IStockObserver>();

        public string Symbol { get; }
        public decimal Price
        {
            get => _price;
            set
            {
                if (_price != value)
                {
                    decimal oldPrice = _price;
                    _price = value;
                    NotifyObservers(oldPrice, _price);
                }
            }
        }

        public Stock(string symbol, decimal price)
        {
            Symbol = symbol;
            _price = price;
        }

        public void AddObserver(IStockObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IStockObserver observer)
        {
            _observers.Remove(observer);
        }

        private void NotifyObservers(decimal oldPrice, decimal newPrice)
        {
            foreach (var observer in _observers)
            {
                observer.Update(this, oldPrice, newPrice);
            }
        }

        public void SimulatePriceChange()
        {
            Random random = new Random();
            decimal percentageChange = (decimal)(random.NextDouble() * 0.1 - 0.05); // -5% to +5%
            Price += Price * percentageChange;
        }
    }
}
