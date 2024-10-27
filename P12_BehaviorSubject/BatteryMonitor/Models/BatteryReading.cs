using System;

namespace BatteryMonitoringApp.Models
{
    public class BatteryReading
    {
        public DateTime Timestamp { get; set; }
        public int Level { get; set; }

        public BatteryReading(DateTime timestamp, int level)
        {
            Timestamp = timestamp;
            Level = level;
        }

        public override string ToString()
        {
            return $"{Timestamp:HH:mm:ss} - Poziom baterii: {Level}%";
        }
    }
}
