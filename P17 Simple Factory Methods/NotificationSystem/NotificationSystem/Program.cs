using NotificationSystem.Notification;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Welcome to the Notification System!");

        while (true)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Choose notification type (email, sms, push) or type 'exit' to quit:");
            string type = Console.ReadLine()!;

            if (type.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Exiting the Notification System...");
                break;
            }

            try
            {
                INotification notification = NotificationFactory.CreateNotification(type);

                Console.WriteLine("Enter the message to send:");
                string message = Console.ReadLine()!;

                Console.WriteLine(" ");

                // Asynchronously send notification
                await notification.SendAsync(message);
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        Console.WriteLine("Goodbye!");
    }
}