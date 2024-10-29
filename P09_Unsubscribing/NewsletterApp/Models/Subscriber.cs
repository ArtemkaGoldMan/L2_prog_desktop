namespace NewsletterApp.Models
{
    public class Subscriber
    {
        public string Email { get; private set; }

        public Subscriber(string email)
        {
            Email = email;
        }
    }
}
