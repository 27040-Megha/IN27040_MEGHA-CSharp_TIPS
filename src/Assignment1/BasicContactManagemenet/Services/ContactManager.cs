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
    /// ContactManager Class
    /// </summary>
    internal class ContactManager
    {
        private Repo _contactRepo = new Repo();

        /// <summary>
        /// AddContact
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
                _contactRepo.StoreInContactList(contact);
                return true;
            }
            return false;
        }

        /// <summary>
        /// ViewAll Contacts
        /// </summary>
        /// <returns>list of contact objects</returns>
        internal List<ContactInfo> DisplayAllContacts()
        {
            return _contactRepo.ReturnContactList();
        }

        /// <summary>
        /// Display all sorted contacts
        /// </summary>
        /// <returns>List of contact names</returns>
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
        /// editContactDetails
        /// </summary>
        /// <param name="myGuid">myGuid id</param>
        /// <param name="contact">contactName</param>
        /// <returns>boolean value</returns>
        internal bool EditContactDetails(Guid myGuid, ContactInfo contact)
        {
            if (!EmailValidation.ValidateEmail(contact.Email) || !PhoneNumberValidation.ValidatePhnNumber(contact.PhnNumber) || !NameValidation.ValidateName(contact.Name))
            {
                return false;
            }
            List<ContactInfo> contactList = _contactRepo.ReturnContactList();
            for (int i = 0; i < contactList.Count; i++)
            {
                if (contactList[i].Id == myGuid)
                {
                    _contactRepo.UpdateContactList(i, contact);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// SearchContactDetails
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>contactInfo object</returns>
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
        /// <param name="myGuid">id of the contact</param>
        /// <returns>Boolean value</returns>
        internal bool DeleteContactDetails(Guid myGuid)
        {
            List<ContactInfo> contactList = _contactRepo.ReturnContactList();
            for (int i = 0; i < contactList.Count; i++)
            {
                if (contactList[i].Id == myGuid)
                {
                    _contactRepo.DeleteContactFromRepo(i);
                    return true;
                }
            }
            return false;
        }
    }
}