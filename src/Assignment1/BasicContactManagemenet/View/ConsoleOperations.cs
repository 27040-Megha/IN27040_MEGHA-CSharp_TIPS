using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicContactManagement.Models;
using BasicContactManagement.Services;

namespace BasicContactManagement.View
{
    internal class ConsoleOperations
    {
        ContactManager manageContact = new ContactManager();

        public void DisplayAndHandlesMenu()
        {
            Console.WriteLine("Basic Contact Manager Application");
            char ch;
            do
            {
                Console.WriteLine("Enter ShortCut (Eg. A/a to Add contact):");
                Console.WriteLine("[A]dd Contact");
                Console.WriteLine("[V]iew ContactList");
                Console.WriteLine("[L]ist Sorted Contact Names");
                Console.WriteLine("[E]dit Contact");
                Console.WriteLine("[S]earch Contact Details");
                Console.WriteLine("[D]elete Contact");
                Console.WriteLine("[C]lose Application");
                ch = char.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 'A':
                    case 'a':
                        GetAddContactDetails();
                        break;
                    case 'V':
                    case 'v':
                        ViewAllContacts();
                        break;
                    case 'L':
                    case 'l':
                        ViewSortedContactList();
                        break;
                    case 'E':
                    case 'e':
                        EditContact();
                        break;
                    case 'S':
                    case 's':
                        SearchContact();
                        break;
                    case 'D':
                    case 'd':
                        DeleteContact();
                        break;
                    default:
                        break;
                }
            }
            while (!(ch == 'c' || ch == 'C'));
        }
        public void GetAddContactDetails()
        {
            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Phone Number: ");
            string phnNumber = Console.ReadLine();
            Console.WriteLine("Enter Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Note: ");
            string description = Console.ReadLine();
            ContactInfo contact = new ContactInfo(name, phnNumber, email, description);
            bool isContactAdded = manageContact.AddContact(contact);
            if (isContactAdded == true)
            {
                Console.WriteLine("Contact Added Successfully");
            }
            else
            {
                Console.WriteLine("Can't Create Contact. Check your Email and Phone number");
            }
        }

        public void ViewAllContacts()
        {
            List<ContactInfo> contactList = manageContact.AllContacts();
            for (int i = 0; i < contactList.Count; i++)
            {
                ContactInfo contact = contactList[i];
                Display(contact);
            }
        }

        public void ViewSortedContactList()
        {
            List<string> contactNamesSorted = manageContact.SortedContacts();
            for (int i = 0; i < contactNamesSorted.Count; i++)
            {
                Console.WriteLine(contactNamesSorted[i]);
            }
            Console.WriteLine("---------------------------------------------");
        }

        public string GetID()
        {
            Console.WriteLine("Enter ID:");
            string id = Console.ReadLine();
            return id;
        }

        public void EditContact()
        {
            string id = GetID();
            Console.WriteLine("Enter new Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter new PhnNumber:");
            string phnNumber = Console.ReadLine();
            Console.WriteLine("Enter new Email:");
            string email = Console.ReadLine();
            Console.WriteLine("Enter new Note:");
            string note = Console.ReadLine();
            ContactInfo contact = new ContactInfo(name, phnNumber, email, note);
            bool isEditted = manageContact.EditContactDetails(id, contact);
            if (isEditted == true)
            {
                Console.WriteLine("Contact Editted Successfully");
            }
            else
            {
                Console.WriteLine("Not editted");
            }
        }

        public void SearchContact()
        {
            Console.WriteLine("Enter name to be searched:");
            string name = Console.ReadLine();
            ContactInfo contact = manageContact.SearchContactDetails(name);
            if (contact != null)
            {
                Display(contact);
            }
            else
            {
                Console.WriteLine("No contact with the name found");
            }
        }
        public static void Display(ContactInfo contact)
        {
            Console.WriteLine("ID: " + contact.Id);
            Console.WriteLine("Name: " + contact.Name);
            Console.WriteLine("Phone Number: " + contact.PhnNumber);
            Console.WriteLine("Email: " + contact.Email);
            Console.WriteLine("Note: " + contact.Note);
            Console.WriteLine("---------------------------------------------");
        }

        public void DeleteContact()
        {
            string id = GetID();
            manageContact.DeleteContactDetails(id);
            Console.WriteLine("Contact Deleted Successfully");
        }
    }
}