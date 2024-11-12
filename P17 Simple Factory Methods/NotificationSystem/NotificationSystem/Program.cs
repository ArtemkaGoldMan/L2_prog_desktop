using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using NotificationSystem.Notification;
namespace NotificationSystem
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to the Reactive Notification System!");

            while (true)
            {
                Console.WriteLine("\nChoose notification type (email, sms, push) or type 'exit' to quit:");
                string type = Console.ReadLine()!;

                if (type.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Exiting the Notification System...");
                    break;
                }

                Console.WriteLine("Enter the message to send:");
                string message = Console.ReadLine()!;

                try
                {
                    var notification = NotificationFactory.CreateNotification(type);
                    var observableNotification = Observable.Return(notification);

                    // Subskrybowanie do obserwowalnego powiadomienia
                    observableNotification.Subscribe(
                        async n => await n.SendAsync(message),
                        ex => Console.WriteLine($"Error: {ex.Message}"),
                        () => Console.WriteLine("Notification process completed.")
                    );
                }
                catch (NotSupportedException ex)
                {
                    // Obsługa nieobsługiwanego typu powiadomienia jako obserwowalny błąd
                    Observable.Throw<INotification>(ex).Subscribe(
                        _ => { }, // pusta operacja, ponieważ to przypadek błędu
                        err => Console.WriteLine($"Error: {err.Message}")
                    );
                }
            }

            Console.WriteLine("Goodbye!");
        }
    }
}

