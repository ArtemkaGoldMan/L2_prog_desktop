using System;
using System.IO;
using System.Timers;
using BatteryMonitoringApp.Models; // Dodaj ten import

namespace BatteryMonitoringApp.Services
{
    public class BatterySimulator
    {
        private static readonly string _folderPath = "BatteryData";
        private static System.Timers.Timer _timer;
        private static int _samplesPerFile = 10; // liczba odczytów na plik
        private static int _currentSampleCount = 0;
        private static string _currentFilePath;

        public BatterySimulator()
        {
            Directory.CreateDirectory(_folderPath);
            StartSimulating();
        }

        private void StartSimulating()
        {
            _timer = new System.Timers.Timer(5000); // co 1 sekunda
            _timer.Elapsed += GenerateBatteryReading;
            _timer.Start();
        }

        private void GenerateBatteryReading(object sender, ElapsedEventArgs e)
        {
            if (_currentSampleCount == 0)
            {
                _currentFilePath = Path.Combine(_folderPath, $"BatteryData_{DateTime.Now:yyyy-MM-dd}.txt");
            }

            Random rand = new Random();
            int batteryLevel = rand.Next(0, 101); // poziom baterii od 0% do 100%
            var batteryReading = new BatteryReading(DateTime.Now, batteryLevel);

            using (StreamWriter writer = new StreamWriter(_currentFilePath, true))
            {
            writer.WriteLine(batteryReading.ToString());
            }

            Console.WriteLine($"Wygenerowano nowy odczyt: {batteryLevel}%");
            _currentSampleCount++;

            if (_currentSampleCount >= _samplesPerFile)
            {
                _currentSampleCount = 0;
            }
        }
    }
}
