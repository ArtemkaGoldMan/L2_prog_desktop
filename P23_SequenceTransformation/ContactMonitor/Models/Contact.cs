namespace ContactMonitor.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{Id};{FirstName};{LastName};{PhoneNumber};{Email}";
        }
    }
}
