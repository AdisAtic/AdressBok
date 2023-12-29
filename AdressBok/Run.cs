using cSharp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace cSharp
{
    public class Run
    {
        /// <summary>
        /// Entry point for project minimal use of main method
        /// </summary>
        public void run()
        {
            List<Contact> contactList = LoadContacts();

            while (true)
            {
                DisplayMenu();
                Console.Write("Enter your choice (0 to exit): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("You selected Option 1.");
                        CreateNewContact(contactList);
                        break;

                    case "2":
                        Console.WriteLine("You selected Option 2.");
                        Console.WriteLine("What index do you wish to delete?");

                        string deleteEmail = Console.ReadLine();
                        DeleteContactAtIndex(contactList, deleteEmail);
                        break;

                    case "3":
                        Console.WriteLine("You selected to edit a user.");
                        Console.WriteLine("What index do you wish to edit?");

                        string editEmail = Console.ReadLine();
                        EditContactAtIndex(contactList, editEmail);

                        break;

                    case "4":
                        Console.WriteLine("You selected Option 4.");
                        ViewAllContacts(contactList);
                        break;

                    case "5":
                        Console.WriteLine("You selected Option 5");
                        ViewContactInfomation(contactList);
                        break;

                    case "0":
                        SaveContacts(contactList);
                        Console.WriteLine("Exiting the program. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }
        /// <summary>
        /// Load json file from directory
        /// </summary>
        /// <returns></returns>
        private List<Contact> LoadContacts()
        {
            if (File.Exists("contacts.json"))
            {
                string json = File.ReadAllText("contacts.json");
                return JsonConvert.DeserializeObject<List<Contact>>(json);
            }
            else
            {
                return Seed();
            }
        }
        /// <summary>
        /// Saves contacts to json file in directory
        /// </summary>
        /// <param name="contactList"></param>
        private void SaveContacts(List<Contact> contactList)
        {
            string json = JsonConvert.SerializeObject(contactList, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("contacts.json", json);
        }
        /// <summary>
        /// Display detailed view for contacts in list
        /// </summary>
        /// <param name="contactList"></param>
        private void ViewAllContacts(List<Contact> contactList)
        {
            Console.WriteLine();

            foreach (var contact in contactList)
            {
                Console.WriteLine($"Contact index : {contactList.IndexOf(contact) + 1}");

                Console.WriteLine($"Name: {contact.FirstName}");
                Console.WriteLine($"Last name: {contact.LastName}");
                Console.WriteLine($"Phone number: {contact.PhoneNumber}");
                Console.WriteLine($"Email: {contact.Email}");

                Console.WriteLine("---------------------");
                Console.WriteLine("Address information");
                Console.WriteLine("---------------------");

                Console.WriteLine($"StreetName: {contact.Address.StreetName}");
                Console.WriteLine($"Phone number: {contact.Address.City}");
                Console.WriteLine($"zip code: {contact.Address.ZipCode}");

                Console.WriteLine("------------------");
                Console.WriteLine("------------------");
            }
        }
        /// <summary>
        /// Dispaly minimalistic view for contacts
        /// </summary>
        /// <param name="contactList"></param>
        private void ViewContactInfomation(List<Contact> contactList)
        {
            Console.WriteLine();

            foreach (var contact in contactList)
            {
                Console.WriteLine($"Contact index : {contactList.IndexOf(contact) + 1}");

                Console.WriteLine($"Name: {contact.FirstName}");
                Console.WriteLine($"Last name: {contact.LastName}");
                Console.WriteLine($"Phone number: {contact.PhoneNumber}");
                Console.WriteLine($"Email: {contact.Email}");
                Console.WriteLine();

            }
        }
        /// <summary>
        /// Edit contact by entering email for chosen contact
        /// </summary>
        /// <param name="contactList"></param>
        /// <param name="email"></param>
        private void EditContactAtIndex(List<Contact> contactList, string email)
        {
            bool selectedFlag = false;

            foreach (var contact in contactList)
            {
                if(contact.Email == email)
                {
                    selectedFlag = true;

                    Console.WriteLine($"Editing contact at index {email}:");

                    Contact contactToEdit = contact;

                    Console.Write("Enter new first name: ");
                    contactToEdit.FirstName = Console.ReadLine();

                    Console.Write("Enter new last name: ");
                    contactToEdit.LastName = Console.ReadLine();

                    Console.Write("Enter new phone number: ");
                    contactToEdit.PhoneNumber = Console.ReadLine();

                    Console.Write("Enter email: ");
                    contactToEdit.Email = Console.ReadLine();

                    Console.Write("Enter new street name: ");
                    contactToEdit.Address.StreetName = Console.ReadLine();

                    Console.Write("Enter new city: ");
                    contactToEdit.Address.City = Console.ReadLine();

                    Console.Write("Enter new zip code: ");
                    contactToEdit.Address.ZipCode = Console.ReadLine();

                    Console.WriteLine("Contact updated successfully.");

                    break;
                }
            }
            
            if(selectedFlag != true)
            {
                Console.WriteLine($"Invalid index: {email}");
            }
        }
        /// <summary>
        /// Delete contact by entering email for chosen contact
        /// </summary>
        /// <param name="contactList"></param>
        /// <param name="email"></param>
        private void DeleteContactAtIndex(List<Contact> contactList, string email)
        {
            bool selectedFlag = false;

            foreach (var contact in contactList)
            {
                if (contact.Email == email)
                {
                    selectedFlag = true;

                    Console.WriteLine($"Deleting contact at index {contact.Email}:");
                    contactList.Remove(contact);
                    Console.WriteLine("Contact deleted successfully.");

                    break;
                }
            }

            if (selectedFlag != true)
            {
                Console.WriteLine($"Invalid index: {email}");
            }
        }
        /// <summary>
        /// Options let's you create and add a new contact to the list
        /// </summary>
        /// <param name="contactList"></param>
        private void CreateNewContact(List<Contact> contactList)
        {
            Console.WriteLine("Creating a new contact:");

            Contact newContact = new Contact();

            Console.Write("Enter first name: ");
            newContact.FirstName = Console.ReadLine();

            Console.Write("Enter last name: ");
            newContact.LastName = Console.ReadLine();

            Console.Write("Enter phone number: ");
            newContact.PhoneNumber = Console.ReadLine();

            Console.Write("Enter email: ");
            newContact.Email = Console.ReadLine();

            Console.Write("Enter street name: ");
            newContact.Address.StreetName = Console.ReadLine();

            Console.Write("Enter city name: ");
            newContact.Address.City = Console.ReadLine();

            Console.Write("Enter zip code: ");
            newContact.Address.ZipCode = Console.ReadLine();

            contactList.Add(newContact);

            Console.WriteLine("Contact created successfully.");
        }
        /// <summary>
        /// Displays main menu
        /// </summary>
        private void DisplayMenu()
        {
            Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||||||");
            Console.WriteLine("||||      1. Add Contact                  ||||");
            Console.WriteLine("||||      2. Delete Contact               ||||");
            Console.WriteLine("||||      3. Edit a user                  ||||");
            Console.WriteLine("||||      4. Detailed view for contacts   ||||");
            Console.WriteLine("||||      5. View all contacts            ||||");
            Console.WriteLine("||||      0. Exit                         ||||");
            Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||||||");
        }
        /// <summary>
        /// Seed list on initial start
        /// </summary>
        /// <returns></returns>
        private List<Contact> Seed()
        {
            List<Contact> list = new List<Contact>();
            Contact contact1 = new Contact
            {
                FirstName = "Adis",
                LastName = "Atic",
                PhoneNumber = "1234567890",
                Email = "adisatic@gmail.com",
                Address = new AddressInformation
                {
                    StreetName = "Enedalsgatan 4",
                    City = "Boras",
                    ZipCode = "504 52",

                },

            };
            Contact contact2 = new Contact
            {
                FirstName = "Adde",
                LastName = "Atiasdfasdc",
                PhoneNumber = "12adsfasd34567890",
                Email = "adisatadsfaic@gmail.com",
                Address = new AddressInformation
                {
                    StreetName = "Enedalsgatan 4",
                    City = "Boras",
                    ZipCode = "504 52",

                },

            };
            Contact contact3 = new Contact
            {
                FirstName = "Adddfdfdfis",
                LastName = "Afffc",
                PhoneNumber = "1234090967890",
                Email = "adisatidfsfac@gmail.com",
                Address = new AddressInformation
                {
                    StreetName = "Enedalsgatan 4",
                    City = "Boras",
                    ZipCode = "504 52",

                },

            };
            list.Add(contact1);
            list.Add(contact2);
            list.Add(contact3);
            return list;
        }
    }
}
