using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicContactManagement.Models;
using BasicContactManagement.Services;
using Microsoft.VisualBasic;

namespace BasicContactManagement.View
{
    /// <summary>
    /// Provides functionality for all Console Operations
    /// </summary>
    internal class ConsoleOperations
    {
        private ContactManager _manageContact = new ContactManager();

        /// <summary>
        /// Displays And handles menu function
        /// </summary>
        internal void DisplayAndHandlesMenu()
        {
            Console.WriteLine("Basic Contact Manager Application");
            string ch;
            do
            {
                DisplayMenuOptions();
                ch = Console.ReadLine();
                switch (ch)
                {
                    case "A":
                        AddContactDetails();
                        break;
                    case "V":
                        ViewAllContacts();
                        break;
                    case "L":
                        ViewSortedContactList();
                        break;
                    case "E":
                        EditContact();
                        break;
                    case "S":
                        SearchContact();
                        break;
                    case "D":
                        DeleteContact();
                        break;
                    default:
                        Console.WriteLine("Invalid Menu Option");
                        break;
                }
            }
            while (!(ch == "C"));
        }

        /// <summary>
        /// Displays menu option
        /// </summary>
        private void DisplayMenuOptions()
        {
            Console.WriteLine("Enter ShortCut (Eg. A/a to Add contact):");
            Console.WriteLine("[A]dd Contact");
            Console.WriteLine("[V]iew ContactList");
            Console.WriteLine("[L]ist Sorted Contact Names");
            Console.WriteLine("[E]dit Contact");
            Console.WriteLine("[S]earch Contact Details");
            Console.WriteLine("[D]elete Contact");
            Console.WriteLine("[C]lose Application");
        }

        /// <summary>
        /// Gets user Contact details, creates object and returns
        /// </summary>
        /// <returns>ContactInfo object</returns>
        private ContactInfo GetUserInput()
        {
            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("How many Phone numbers do you want to store for this contact?");
            int n = int.Parse(Console.ReadLine());
            List<string> phnNumber = new List<string>();
            for(int i=0;i<n;i++)
            {
                Console.WriteLine("Enter Phone Number " + (i+1));
                phnNumber.Add(Console.ReadLine());
            }
            Console.WriteLine("Enter Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Note: ");
            string description = Console.ReadLine();
            ContactInfo contact = new ContactInfo(name, phnNumber, email, description);
            return contact;
        }

        /// <summary>
        /// Gets input required for adding contact details
        /// </summary>
        private void AddContactDetails()
        {
            ContactInfo contact = GetUserInput();
            bool isContactAdded = _manageContact.AddContact(contact);
            if (isContactAdded)
            {
                Console.WriteLine("Contact Added Successfully");
            }
            else
            {
                Console.WriteLine("Can't Create Contact. Check the details you entered");
            }
        }

        /// <summary>
        /// Displays all contact details
        /// </summary>
        private void ViewAllContacts()
        {
            List<ContactInfo> contactList = _manageContact.DisplayAllContacts();
            if(contactList.Count==0)
            {
                Console.WriteLine("No contacts saved in ContactList");
            }
            foreach (var contact in contactList)
            {
                DisplayContact(contact);
            }
        }

        /// <summary>
        /// Displays Sorted Contact List
        /// </summary>
        private void ViewSortedContactList()
        {
            List<string> contactNamesSorted = _manageContact.SortContacts();
            foreach (var contactNames in contactNamesSorted)
            {
                Console.WriteLine(contactNames);
            }
            PrintDivider();
        }

        /// <summary>
        /// Edit contact
        /// </summary>
        private void EditContact()
        {
            Guid userId = GetUserID();
            ContactInfo contact = GetUserInput();
            bool isEdited = _manageContact.EditContactDetails(userId, contact);
            if (isEdited)
            {
                Console.WriteLine("Contact Edited Successfully");
            }
            else
            {
                Console.WriteLine("Not edited (Invalid Email, Name or PhnNumber format or GUID entered)");
            }
        }

        /// <summary>
        /// Finds Contact
        /// </summary>
        private void SearchContact()
        {
            Console.WriteLine("Enter name to be searched:");
            string name = Console.ReadLine();
            List<ContactInfo> matchedContacts = _manageContact.SearchContactDetails(name);
            if(matchedContacts.Count==0)
            {
                Console.WriteLine("No contacts found");
            }
            else
            {
                foreach(ContactInfo contacts in matchedContacts)
                {
                    DisplayContact(contacts);
                }
            }
        }

        /// <summary>
        /// Displays Contact details
        /// </summary>
        /// <param name="contact">contactInfo object</param>
        private void DisplayContact(ContactInfo contact)
        {
            Console.WriteLine("ID: " + contact.Id);
            Console.WriteLine("Name: " + contact.Name);
            for (int i = 0; i < contact.PhnNumber.Count; i++)
            {
                Console.WriteLine("Phone Number "+(i+1)+": "+ contact.PhnNumber[i]);
            }
            Console.WriteLine("Email: " + contact.Email);
            Console.WriteLine("Note: " + contact.Note);
            PrintDivider();
        }

        /// <summary>
        /// Delete Contact function
        /// </summary>
        private void DeleteContact()
        {
            Guid userId = GetUserID();
            if (_manageContact.DeleteContactDetails(userId))
            {
                Console.WriteLine("Contact Deleted Successfully");
            }
            else
            {
                Console.WriteLine("Contact not found");
            }
        }

        /// <summary>
        /// Gets UserId (Guid) from user
        /// </summary>
        /// <returns>return Guid entered by user</returns>
        private Guid GetUserID()
        {
            Console.WriteLine("Enter ID:");
            Guid userId = Guid.Parse(Console.ReadLine());
            return userId;
        }

        /// <summary>
        /// Prints Divider Line
        /// </summary>
        private void PrintDivider()
        {
            Console.WriteLine("---------------------------------------------");
        }
    }
}