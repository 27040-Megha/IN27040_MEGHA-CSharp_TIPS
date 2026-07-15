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
        public bool AddContact(ContactInfo contact)
        {
            bool isValidEmail = EmailValidation.ValidateEmail(contact.Email);
            bool isValidPhnNumber = PhoneNumberValidation.ValidatePhnNumber(contact.PhnNumber);
            if(isValidEmail==true && isValidPhnNumber==true)
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
        public List<ContactInfo> AllContacts()
        {
            List<ContactInfo> contactList = _contactRepo.ReturnContactList();
            return contactList;
        }

        /// <summary>
        /// Display all sorted contacts
        /// </summary>
        /// <returns>List of contact names</returns>
        public List<string> SortedContacts()
        {
            List<ContactInfo> contactList = _contactRepo.ReturnContactList();
            List<string> contactNames = new List<string>();
            for (int i = 0; i < contactList.Count; i++)
            {
                ContactInfo contact = contactList[i];
                contactNames.Add(contact.Name);
            }
            contactNames.Sort();
            return contactNames;
        }
        /// <summary>
        /// editContactDetails
        /// </summary>
        /// <param name="id">contact id</param>
        /// <param name="contact">contactName</param>
        /// <returns>boolean value</returns>
        public bool EditContactDetails(string id, ContactInfo contact)
        {
            if(!((EmailValidation.ValidateEmail(contact.Email))||(PhoneNumberValidation.ValidatePhnNumber(contact.PhnNumber))))
            {
                return false;
            }
            List<ContactInfo> contactList = _contactRepo.ReturnContactList();
            for (int i = 0; i < contactList.Count; i++)
            {
                ContactInfo currentContact = contactList[i];
                string guidContact = currentContact.Id.ToString();
                if (guidContact == id)
                {
                    Repo contactrepo = new Repo();
                    contactrepo.UpdateContactList(i, contact);
                }
            }
            return true;
        }

        /// <summary>
        /// SearchContactDetails
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>contactInfo object</returns>
        public ContactInfo SearchContactDetails(string name)
        {
            List<ContactInfo> contactList = _contactRepo.ReturnContactList();
            for (int i = 0; i < contactList.Count; i++)
            {
                ContactInfo contact = contactList[i];
                string  currentContactName= contact.Name;
                if (name == currentContactName)
                {
                    return contact;
                }
            }
            return null;
        }
        
        /// <summary>
        /// Delete contact from list
        /// </summary>
        /// <param name="id">id of the contact</param>
        public void DeleteContactDetails(string id)
        {
            List<ContactInfo> contactList = _contactRepo.ReturnContactList();
            for (int i = 0; i < contactList.Count; i++)
            {
                ContactInfo contact = contactList[i];
                string sid = contact.Id.ToString();
                if (sid == id)
                {
                    Repo contactRepo = new Repo();
                    contactRepo.DeleteContactFromRepo(i);
                }
            }
        }
    }
}