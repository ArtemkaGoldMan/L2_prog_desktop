using LogisticsDeliveryMonitor;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
class Program
{
    static void Main(string[] args)
    {
    
        const int DelayThreshold = 3;


        var deliveryUpdates = new Subject<DeliveryUpdate>();


        deliveryUpdates
            .Where(update => update.Status == "delayed" || update.Status == "on-time")
            .GroupBy(update => update.RouteId) 
            .SelectMany(routeGroup =>
                routeGroup
                    .Where(update => update.Status == "delayed") 
                    .Buffer(TimeSpan.FromSeconds(10))
                    .Select(buffer => new { RouteId = routeGroup.Key, DelayCount = buffer.Count })
            )
            .Where(routeStatus => routeStatus.DelayCount >= DelayThreshold)
            .Subscribe(
                routeStatus => Console.WriteLine($"Alert: Route {routeStatus.RouteId} has {routeStatus.DelayCount} delays!"),
                ex => Console.WriteLine($"Error: {ex.Message}"),
                () => Console.WriteLine("Monitoring completed.")
            );

  
        SimulateDeliveryUpdates(deliveryUpdates);
    }

    private static void SimulateDeliveryUpdates(Subject<DeliveryUpdate> deliveryUpdates)
    {
        var random = new Random();
        string[] routeIds = { "RouteA", "RouteB", "RouteC" };
        string[] statuses = { "on-time", "delayed", "completed" };

        
        for (int i = 0; i < 20; i++)
        {
            var update = new DeliveryUpdate
            {
                RouteId = routeIds[random.Next(routeIds.Length)],
                Status = statuses[random.Next(statuses.Length)],
                Eta = DateTime.Now.AddMinutes(random.Next(1, 60)),
                Location = $"Location-{i}"
            };
            deliveryUpdates.OnNext(update);
            System.Threading.Thread.Sleep(500); 
        }

        deliveryUpdates.OnCompleted();
    }
}
