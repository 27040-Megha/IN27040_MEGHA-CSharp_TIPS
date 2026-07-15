using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicContactManagement.Models;

namespace BasicContactManagement.Repository
{
    internal class Repo
    {
        public static List<ContactInfo> ContactList { get; set; } = new List<ContactInfo>();

        public void StoreInContactList(ContactInfo contact)
        {
            ContactList.Add(contact);
        }

        public List<ContactInfo> ReturnContactList()
        {
            return ContactList;
        }

        public void UpdateContactList(int index, ContactInfo newContact)
        {
            ContactInfo oldContact = ContactList[index];
            oldContact.Name = newContact.Name;
            oldContact.PhnNumber = newContact.PhnNumber;
            oldContact.Email = newContact.Email;
            oldContact.Note = newContact.Note;
        }

        public void DeleteContactFromRepo(int index)
        {
            ContactList.RemoveAt(index);
        }
    }
}