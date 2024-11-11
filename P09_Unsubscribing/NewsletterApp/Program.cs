using System;
using NewsletterApp.Models;
using NewsletterApp.Services;

namespace NewsletterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var publisher = new NewsPublisher();
            var subscriptionService = new SubscriptionService(publisher);

            while (true)
            {
                Console.WriteLine("\n1. Subscribe");
                Console.WriteLine("2. Unsubscribe");
                Console.WriteLine("3. Send Notification");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter your email: ");
                        var emailToSubscribe = Console.ReadLine();
                        subscriptionService.AddSubscriber(emailToSubscribe);
                        break;

                    case "2":
                        Console.Write("Enter your email to unsubscribe: ");
                        var emailToUnsubscribe = Console.ReadLine();
                        subscriptionService.RemoveSubscriber(emailToUnsubscribe);
                        break;

                    case "3":
                        Console.Write("Enter notification message: ");
                        var message = Console.ReadLine();
                        subscriptionService.Notify(message);
                        break;

                    case "4":
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
