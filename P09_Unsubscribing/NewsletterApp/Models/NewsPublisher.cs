using System;
using System.Collections.Generic;

namespace NewsletterApp.Models
{
    public class NewsPublisher
    {
        private readonly List<Subscriber> _subscribers = new List<Subscriber>();

        public void Subscribe(Subscriber subscriber)
        {
            if (!_subscribers.Contains(subscriber))
            {
                _subscribers.Add(subscriber);
                Console.WriteLine($"{subscriber.Email} subscribed successfully.");
            }
            else
            {
                Console.WriteLine($"{subscriber.Email} is already subscribed.");
            }
        }

        public void Unsubscribe(Subscriber subscriber)
        {
            if (_subscribers.Remove(subscriber))
            {
                Console.WriteLine($"{subscriber.Email} unsubscribed successfully.");
            }
            else
            {
                Console.WriteLine($"{subscriber.Email} is not in the subscriber list.");
            }
        }

        public void NotifySubscribers(string message)
        {
            foreach (var subscriber in _subscribers)
            {
                Console.WriteLine($"Sending notification to {subscriber.Email}: {message}");
                // Tu można dodać logikę zapisywania powiadomień do pliku
            }
        }
    }
}
