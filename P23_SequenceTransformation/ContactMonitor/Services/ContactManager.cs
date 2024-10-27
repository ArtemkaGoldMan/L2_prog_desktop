using System;
using System.Collections.Generic;
using System.IO;
using ContactMonitor.Models;

namespace ContactMonitor.Services
{
    public class ContactManager
    {
        private List<Contact> contacts;
        private string filePath = "contacts.txt";

        public ContactManager()
        {
            contacts = new List<Contact>();
            LoadContacts();
        }

        public void LoadContacts()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    var lines = File.ReadAllLines(filePath);
                    foreach (var line in lines)
                    {
                        var parts = line.Split(';');
                        if (parts.Length == 5)
                        {
                            contacts.Add(new Contact
                            {
                                Id = int.Parse(parts[0]),
                                FirstName = parts[1],
                                LastName = parts[2],
                                PhoneNumber = parts[3],
                                Email = parts[4]
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas ładowania kontaktów: {ex.Message}");
            }
        }

        public void SaveContacts()
        {
            var lines = new List<string>();
            foreach (var contact in contacts)
            {
                lines.Add(contact.ToString());
            }
            File.WriteAllLines(filePath, lines);
        }

        public void AddContact(string firstName, string lastName, string phoneNumber, string email)
        {
            int newId = contacts.Count > 0 ? contacts[^1].Id + 1 : 1;
            var contact = new Contact
            {
                Id = newId,
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Email = email
            };
            contacts.Add(contact);
            SaveContacts();
        }

        public void UpdateContact(int id, string firstName, string lastName, string phoneNumber, string email)
        {
            var contact = contacts.Find(c => c.Id == id);
            if (contact != null)
            {
                contact.FirstName = firstName;
                contact.LastName = lastName;
                contact.PhoneNumber = phoneNumber;
                contact.Email = email;
                SaveContacts();
            }
            else
            {
                Console.WriteLine("Kontakt nie został znaleziony.");
            }
        }

        public void DeleteContact(int id)
        {
            var contact = contacts.Find(c => c.Id == id);
            if (contact != null)
            {
                contacts.Remove(contact);
                SaveContacts();
            }
            else
            {
                Console.WriteLine("Kontakt nie został znaleziony.");
            }
        }

        public void ListContacts()
        {
            foreach (var contact in contacts)
            {
                Console.WriteLine($"{contact.Id}: {contact.FirstName} {contact.LastName}, {contact.PhoneNumber}, {contact.Email}");
            }
        }
    }
}
