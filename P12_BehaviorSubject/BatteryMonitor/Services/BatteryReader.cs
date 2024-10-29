using System;
using System.IO;
using System.Linq;
using System.Threading;
using BatteryMonitoringApp.Models; 

namespace BatteryMonitoringApp.Services
{
    public class BatteryReader
    {
        private static readonly string _folderPath = "BatteryData";
        private BatteryReading _lastBatteryReading;

        private FileSystemWatcher _watcher;

        public BatteryReader()
        {
            _lastBatteryReading = null;
            StartWatching();
        }

        private void StartWatching()
        {
            _watcher = new FileSystemWatcher(_folderPath)
            {
                NotifyFilter = NotifyFilters.LastWrite,
                Filter = "*.txt",
                EnableRaisingEvents = true
            };

            _watcher.Changed += OnChanged;
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            Thread.Sleep(100); // krótka pauza, aby upewnić się, że plik jest w pełni zapisany
            ReadLastBatteryLevel(e.FullPath);
        }

        private void ReadLastBatteryLevel(string path)
        {
            var lines = File.ReadAllLines(path);
            if (lines.Length > 0)
            {
                var lastLine = lines.Last();
                var parts = lastLine.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length >= 2)
                {
                    var timestamp = DateTime.Parse(parts[0].Trim());
                    
                    var levelPart = parts[1].Trim();
                   
                    int batteryLevel;

                   
                    if (levelPart.StartsWith("Poziom baterii: "))
                    {
                        levelPart = levelPart.Replace("Poziom baterii: ", "").Replace("%", "").Trim();
                    }

                    if (int.TryParse(levelPart, out batteryLevel))
                    {
                        _lastBatteryReading = new BatteryReading(timestamp, batteryLevel);
                        Console.WriteLine($"Nowy poziom baterii: {_lastBatteryReading.Level}%");
                    }
                    else
                    {
                        Console.WriteLine("Błąd: Nie udało się odczytać poziomu baterii.");
                    }
                }
            }
        }

        public BatteryReading GetLastBatteryReading()
        {
            return _lastBatteryReading;
        }
    }
}
