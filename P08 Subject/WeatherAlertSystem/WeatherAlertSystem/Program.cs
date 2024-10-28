using System;
using WeatherAlertSystem;

class Program
{
    static void Main(string[] args)
    {
        var weatherMonitor = new WeatherMonitor();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("1. Add City to Monitor\n2. View Monitored Cities\n3. Remove City from Monitoring\n4. Exit");
            Console.Write("\nSelect an option: ");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("\nEnter city name: ");
                    weatherMonitor.AddCity(Console.ReadLine()!);
                    break;
                case "2":
                    weatherMonitor.ShowMonitoredCities();
                    break;
                case "3":
                    Console.Write("\nEnter city name to remove: ");
                    weatherMonitor.RemoveCity(Console.ReadLine()!);
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("\nInvalid option, try again.");
                    break;
            }
        }
    }
}
