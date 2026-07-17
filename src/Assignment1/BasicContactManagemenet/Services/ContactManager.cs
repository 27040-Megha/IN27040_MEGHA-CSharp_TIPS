using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicContactManagemenet.Helper;
using BasicContactManagement.Models;
using BasicContactManagement.Repository;
using BasicContactManagement.View;

namespace BasicContactManagement.Services
{
    /// <summary>
    /// Provides all functionality to do Business Logic Operation
    /// </summary>
    internal class ContactManager
    {
        private Repo _contactRepo = new Repo();

        /// <summary>
        /// Adds Contact Details
        /// </summary>
        /// <param name="contact">contact object</param>
        /// <returns>Boolean value</returns>
        internal bool AddContact(ContactInfo contact)
        {
            bool isValidEmail = EmailValidation.ValidateEmail(contact.Email);
            bool isValidPhnNumber = PhoneNumberValidation.ValidatePhnNumber(contact.PhnNumber);
            bool isValidName = NameValidation.ValidateName(contact.Name);
            if(isValidEmail && isValidPhnNumber && isValidName)
            {
                _contactRepo.AddToContactList(contact);
                return true;
            }
            return false;
        }

        /// <summary>
        /// View All Contacts
        /// </summary>
        /// <returns>list of contact objects</returns>
        internal List<ContactInfo> DisplayAllContacts()
        {
            return _contactRepo.ReturnContactList();
        }

        /// <summary>
        /// Display all sorted contacts
        /// </summary>
        /// <returns>List of sorted contact names</returns>
        internal List<string> SortContacts()
        {
            List<ContactInfo> contactList = _contactRepo.ReturnContactList();
            List<string> contactNames = new List<string>();
            for (int i = 0; i < contactList.Count; i++)
            {
                contactNames.Add(contactList[i].Name);
            }
            contactNames.Sort();
            return contactNames;
        }

        /// <summary>
        /// Edit Contact Details
        /// </summary>
        /// <param name="userId">Guid of user</param>
        /// <param name="contact">Contact Object</param>
        /// <returns>boolean value</returns>
        internal bool EditContactDetails(Guid userId, ContactInfo contact)
        {
            if (!EmailValidation.ValidateEmail(contact.Email) || !PhoneNumberValidation.ValidatePhnNumber(contact.PhnNumber) || !NameValidation.ValidateName(contact.Name))
            {
                return false;
            }
            List<ContactInfo> contactList = _contactRepo.ReturnContactList();
            for (int i = 0; i < contactList.Count; i++)
            {
                if (contactList[i].Id == userId)
                {
                    _contactRepo.UpdateContactList(i, contact);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Search Contact Details
        /// </summary>
        /// <param name="name">Contact name to be searched</param>
        /// <returns>List of contactInfo object that matches the name</returns>
        internal List<ContactInfo> SearchContactDetails(string name)
        {
            List<ContactInfo> contactList = _contactRepo.ReturnContactList();
            List<ContactInfo> matchedContacts = new List<ContactInfo>();

            for (int i = 0; i < contactList.Count; i++)
            {
                ContactInfo contact = contactList[i];
                if (string.Equals(contact.Name, name))
                {
                    matchedContacts.Add(contact); 
                }
            }
            return matchedContacts; 
        }

        /// <summary>
        /// Delete contact from list
        /// </summary>
        /// <param name="userId">Guid of the contact</param>
        /// <returns>true if contact is sucessfully deleted, otherwise false</returns>
        internal bool DeleteContactDetails(Guid userId)
        {
            List<ContactInfo> contactList = _contactRepo.ReturnContactList();
            for (int i = 0; i < contactList.Count; i++)
            {
                if (contactList[i].Id == userId)
                {
                    _contactRepo.DeleteContactFromRepo(i);
                    return true;
                }
            }
            return false;
        }
    }
}