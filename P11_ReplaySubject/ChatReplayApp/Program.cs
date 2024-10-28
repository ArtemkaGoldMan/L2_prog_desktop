using ChatReplayApp.Models;
using ChatReplayApp.Services;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var chatRoom = new ChatRoom();
        var userSubscriptions = new Dictionary<string, IDisposable>();

        while (true)
        {
            Console.WriteLine("\n--- Menu ---");
            Console.WriteLine("1 - Dołącz do czatu");
            Console.WriteLine("2 - Wyślij wiadomość");
            Console.WriteLine("3 - Opuść czat");
            Console.WriteLine("4 - Zakończ aplikację");
            Console.Write("Wybierz opcję: ");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Podaj swoją nazwę użytkownika: ");
                    var userName = Console.ReadLine();

                    if (!userSubscriptions.ContainsKey(userName))
                    {
                        var subscription = chatRoom.JoinChat(userName);
                        userSubscriptions[userName] = subscription;
                    }
                    else
                    {
                        Console.WriteLine("Nazwa użytkownika już zajęta. Wybierz inną.");
                    }
                    break;

                case "2":
                    Console.Write("Podaj swoją nazwę użytkownika: ");
                    userName = Console.ReadLine();

                    if (userSubscriptions.ContainsKey(userName))
                    {
                        Console.Write("Wpisz wiadomość: ");
                        var message = Console.ReadLine();
                        chatRoom.SendMessage(userName, message);
                    }
                    else
                    {
                        Console.WriteLine("Musisz dołączyć do czatu przed wysłaniem wiadomości.");
                    }
                    break;

                case "3":
                    Console.Write("Podaj swoją nazwę użytkownika: ");
                    userName = Console.ReadLine();

                    if (userSubscriptions.TryGetValue(userName, out var userSubscription))
                    {
                        Console.WriteLine($"{userName} opuścił czat.");
                        userSubscription.Dispose();
                        userSubscriptions.Remove(userName);
                    }
                    else
                    {
                        Console.WriteLine("Nie jesteś na czacie.");
                    }
                    break;

                case "4":
                    Console.WriteLine("Zamykanie aplikacji...");
                    foreach (var subscription in userSubscriptions.Values)
                    {
                        subscription.Dispose();
                    }
                    return;

                default:
                    Console.WriteLine("Nieprawidłowa opcja. Spróbuj ponownie.");
                    break;
            }
        }
    }
}
