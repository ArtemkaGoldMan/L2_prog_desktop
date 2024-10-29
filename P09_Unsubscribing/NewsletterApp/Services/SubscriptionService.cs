using NewsletterApp.Models;

namespace NewsletterApp.Services
{
    public class SubscriptionService
    {
        private readonly NewsPublisher _publisher;

        public SubscriptionService(NewsPublisher publisher)
        {
            _publisher = publisher;
        }

        public void AddSubscriber(string email)
        {
            var subscriber = new Subscriber(email);
            _publisher.Subscribe(subscriber);
        }

        public void RemoveSubscriber(string email)
        {
            var subscriber = new Subscriber(email);
            _publisher.Unsubscribe(subscriber);
        }

        public void Notify(string message)
        {
            _publisher.NotifySubscribers(message);
        }
    }
}
