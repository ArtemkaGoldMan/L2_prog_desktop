using System;
using BatteryMonitoringApp.Services; // Dodaj ten import

class Program
{
    static void Main(string[] args)
    {
        BatterySimulator simulator = new BatterySimulator();
        BatteryReader reader = new BatteryReader();

        while (true)
        {
            Console.WriteLine("Naciśnij 's' aby uzyskać ostatni poziom baterii, lub 'q' aby zakończyć:");
            var input = Console.ReadKey(true).Key;

            if (input == ConsoleKey.S)
            {
                var lastReading = reader.GetLastBatteryReading();
                if (lastReading != null)
                {
                    Console.WriteLine($"Ostatni znany poziom baterii: {lastReading.Level}%");
                }
                else
                {
                    Console.WriteLine("Brak dostępnych odczytów.");
                }
            }
            else if (input == ConsoleKey.Q)
            {
                break;
            }
        }
    }
}
