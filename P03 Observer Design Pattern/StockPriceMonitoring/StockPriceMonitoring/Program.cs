using StockPriceMonitoring;
using System;
using System.Timers;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Stock Price Monitoring System");

        Stock apple = new Stock("AAPL", 150.00m);
        Stock microsoft = new Stock("MSFT", 250.00m);
        Observer consoleObserver = new Observer();


        apple.AddObserver(consoleObserver);
        microsoft.AddObserver(consoleObserver);


        System.Timers.Timer timer = new System.Timers.Timer(2000);
        timer.Elapsed += (sender, e) =>
        {
            apple.SimulatePriceChange();
            microsoft.SimulatePriceChange();
        };
        timer.Start();

        Console.WriteLine("Press any key to stop...");
        Console.ReadKey();
        timer.Stop();
    }
}