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
    internal class ContactManager
    {
        private Repo _contactRepo = new Repo();

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

        public List<ContactInfo> AllContacts()
        {
            List<ContactInfo> contactList = _contactRepo.ReturnContactList();
            return contactList;
        }

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