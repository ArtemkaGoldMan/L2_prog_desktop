using System;
using ContactMonitor.Services;

namespace ContactMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            var contactManager = new ContactManager();

            while (true)
            {
                Console.WriteLine("Wybierz opcję:");
                Console.WriteLine("1. Dodaj kontakt");
                Console.WriteLine("2. Zaktualizuj kontakt");
                Console.WriteLine("3. Usuń kontakt");
                Console.WriteLine("4. Wyświetl kontakty");
                Console.WriteLine("5. Wyjdź");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Podaj imię:");
                        var firstName = Console.ReadLine();
                        Console.WriteLine("Podaj nazwisko:");
                        var lastName = Console.ReadLine();
                        Console.WriteLine("Podaj numer telefonu:");
                        var phoneNumber = Console.ReadLine();
                        Console.WriteLine("Podaj e-mail:");
                        var email = Console.ReadLine();
                        contactManager.AddContact(firstName, lastName, phoneNumber, email);
                        break;

                    case "2":
                        Console.WriteLine("Podaj ID kontaktu do zaktualizowania:");
                        if (int.TryParse(Console.ReadLine(), out int idToUpdate))
                        {
                            Console.WriteLine("Podaj nowe imię:");
                            firstName = Console.ReadLine();
                            Console.WriteLine("Podaj nowe nazwisko:");
                            lastName = Console.ReadLine();
                            Console.WriteLine("Podaj nowy numer telefonu:");
                            phoneNumber = Console.ReadLine();
                            Console.WriteLine("Podaj nowy e-mail:");
                            email = Console.ReadLine();
                            contactManager.UpdateContact(idToUpdate, firstName, lastName, phoneNumber, email);
                        }
                        else
                        {
                            Console.WriteLine("Nieprawidłowe ID.");
                        }
                        break;

                    case "3":
                        Console.WriteLine("Podaj ID kontaktu do usunięcia:");
                        if (int.TryParse(Console.ReadLine(), out int idToDelete))
                        {
                            contactManager.DeleteContact(idToDelete);
                        }
                        else
                        {
                            Console.WriteLine("Nieprawidłowe ID.");
                        }
                        break;

                    case "4":
                        contactManager.ListContacts();
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                        break;
                }
            }
        }
    }
}
