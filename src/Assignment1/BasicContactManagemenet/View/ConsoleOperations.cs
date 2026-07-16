using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicContactManagement.Models;
using BasicContactManagement.Services;

namespace BasicContactManagement.View
{
    /// <summary>
    /// ConsoleOperations
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
                        GetAddContactDetails();
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
        /// The method displays menu option
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
            Console.WriteLine("Enter Phone Number: ");
            string phnNumber = Console.ReadLine();
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
        private void GetAddContactDetails()
        {
            ContactInfo contact = GetUserInput();
            bool isContactAdded = _manageContact.AddContact(contact);
            if (isContactAdded == true)
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
            for (int i = 0; i < contactList.Count; i++)
            {
                ContactInfo contact = contactList[i];
                Display(contact);
            }
        }

        /// <summary>
        /// Displays Sorted Contact List
        /// </summary>
        private void ViewSortedContactList()
        {
            List<string> contactNamesSorted = _manageContact.SortContacts();
            for (int i = 0; i < contactNamesSorted.Count; i++)
            {
                Console.WriteLine(contactNamesSorted[i]);
            }
            PrintDivider();
        }

        /// <summary>
        /// Edit contact
        /// </summary>
        private void EditContact()
        {
            Guid id = GetID();
            ContactInfo contact = GetUserInput();
            bool isEdited = _manageContact.EditContactDetails(id, contact);
            if (isEdited == true)
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
                for(int i=0;i<matchedContacts.Count;i++)
                {
                    Display(matchedContacts[i]);
                }
            }
        }

        /// <summary>
        /// Displays Contact details
        /// </summary>
        /// <param name="contact">contact info</param>
        private void Display(ContactInfo contact)
        {
            Console.WriteLine("ID: " + contact.Id);
            Console.WriteLine("Name: " + contact.Name);
            Console.WriteLine("Phone Number: " + contact.PhnNumber);
            Console.WriteLine("Email: " + contact.Email);
            Console.WriteLine("Note: " + contact.Note);
            PrintDivider();
        }

        /// <summary>
        /// Delete Contact function
        /// </summary>
        private void DeleteContact()
        {
            Guid id = GetID();
            if (_manageContact.DeleteContactDetails(id))
            {
                Console.WriteLine("Contact Deleted Successfully");
            }
            else
            {
                Console.WriteLine("GUID not found");
            }
        }

        /// <summary>
        /// GetID
        /// </summary>
        /// <returns>return id entered by user</returns>
        private Guid GetID()
        {
            Console.WriteLine("Enter ID:");
            Guid myGuid = Guid.Parse(Console.ReadLine());
            return myGuid;
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