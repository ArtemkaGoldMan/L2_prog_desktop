using System;
using System.Reactive.Linq;

namespace FactoryEquipmentMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting factory equipment monitoring...");

            var temperatureThreshold = 100.0;
            var vibrationThreshold = 0.8;
            var powerThreshold = 500.0;
            var random = new Random();

            // Temperature sensor for Machine A
            var temperatureSensorA = Observable.Interval(TimeSpan.FromSeconds(5))
                .Select(_ => 90.0 + random.NextDouble() * 20 - 5)  
                .Do(temp => Console.WriteLine($"[Machine A - Temperature] {temp:F2} °C"))
                .Where(temp => temp >= temperatureThreshold) 
                .Do(temp => Console.WriteLine($"ALERT! Machine A temperature is too high: {temp:F2} °C")) 
                .Subscribe();

            // Vibration sensor for Machine B
            var vibrationSensorB = Observable.Interval(TimeSpan.FromSeconds(5))
                .Select(_ => 0.6 + random.NextDouble() * 0.5 - 0.20) 
                .Do(vib => Console.WriteLine($"[Machine B - Vibration] {vib:F2} g"))
                .Where(vib => vib >= vibrationThreshold) 
                .Do(vib => Console.WriteLine($"ALERT! Machine B vibration too high: {vib:F2} g")) 
                .Subscribe();

            // Power consumption sensor for Machine C
            var powerSensorC = Observable.Interval(TimeSpan.FromSeconds(5))
                .Select(_ => 450.0 + random.NextDouble() * 100 - 37) 
                .Do(power => Console.WriteLine($"[Machine C - Power] {power:F2} W"))
                .Where(power => power >= powerThreshold)
                .Do(power => Console.WriteLine($"ALERT! Machine C power consumption too high: {power:F2} W"))
                .Subscribe();

            // Keep the application running to simulate real-time data streaming
            Console.WriteLine("Press Enter to stop monitoring.");
            Console.ReadLine();
        }
    }
}
