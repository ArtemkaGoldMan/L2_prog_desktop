using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using System.Timers;
namespace WeatherAlertSystem
{
    public class WeatherMonitor
    {
        private readonly List<Weather> monitoredCities = new List<Weather>();
        private readonly Subject<Weather> weatherNotifier = new Subject<Weather>();
        private readonly Random random = new Random();
        private readonly System.Timers.Timer weatherUpdateTimer = new System.Timers.Timer(3000);

        public WeatherMonitor()
        {
            weatherUpdateTimer.Elapsed += (sender, e) => UpdateWeatherConditions();
            weatherUpdateTimer.Start();

            weatherNotifier.Subscribe(weather =>
            {
                if (weather.Temperature > 35)
                    Console.WriteLine($"\n!!!Alert: High temperature in {weather.City}: {weather.Temperature}°C!");
                if (weather.Precipitation > 80)
                    Console.WriteLine($"\n!!!Alert: Heavy rain in {weather.City} with {weather.Precipitation}% precipitation!");
            });
        }

        public void AddCity(string city)
        {
            var weather = new Weather { City = city, Temperature = GetRandomTemperature(), Precipitation = GetRandomPrecipitation() };
            monitoredCities.Add(weather);
            Console.WriteLine($"\n{city} added to monitoring list.");
            weatherNotifier.OnNext(weather); 
        }

        public void RemoveCity(string city)
        {
            var weather = monitoredCities.Find(w => w.City!.Equals(city, StringComparison.OrdinalIgnoreCase));
            if (weather != null)
            {
                monitoredCities.Remove(weather);
                Console.WriteLine($"\n{city} removed from monitoring list.");
            }
            else
            {
                Console.WriteLine($"\nCity {city} not found in monitoring list.");
            }
        }

        public void ShowMonitoredCities()
        {
            Console.WriteLine("");
            Console.WriteLine("Monitored Cities:");
            foreach (var weather in monitoredCities)
            {
                Console.WriteLine($"{weather.City}: {weather.Temperature}°C, {weather.Precipitation}% precipitation");
            }
            Console.WriteLine("------------------");
        }

        private void UpdateWeatherConditions()
        {
            foreach (var weather in monitoredCities)
            {
                weather.Temperature = GetRandomTemperature();
                weather.Precipitation = GetRandomPrecipitation();
                weatherNotifier.OnNext(weather);
            }
        }

        private float GetRandomTemperature() => (float)(random.Next(15, 45) + random.NextDouble()); 
        private int GetRandomPrecipitation() => random.Next(0, 100); 
    }

}

