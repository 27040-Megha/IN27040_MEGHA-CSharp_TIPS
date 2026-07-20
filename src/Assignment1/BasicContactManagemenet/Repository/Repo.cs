using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicContactManagement.Models;

namespace BasicContactManagement.Repository
{
    /// <summary>
    /// Repo class - storage
    /// </summary>
    internal class Repo
    {
        /// <summary> 
        /// Global repository of saved contact records.
        /// </summary> 
        /// <value>A list containing all active ContactInfo instances</value> 
        private static List<ContactInfo> _contactList = new List<ContactInfo>();

        /// <summary>
        /// Adds contact object in global repository list
        /// </summary>
        /// <param name="contact">Contact Object to be added in list</param>
        internal void AddToContactList(ContactInfo contact)
        {
            _contactList.Add(contact);
        }

        /// <summary>
        /// Returns List of Contact Details
        /// </summary>
        /// <returns>List of ContactInfo objects</returns>
        internal List<ContactInfo> ReturnContactList()
        {
            return _contactList;
        }

        /// <summary>
        /// UpdateContact List
        /// </summary>
        /// <param name="index">index of contact object to be updated</param>
        /// <param name="newContact">contact Object</param>
        internal void UpdateContactList(int index, ContactInfo newContact)
        {
            ContactInfo oldContact = _contactList[index];
            oldContact.Name = newContact.Name;
            oldContact.PhnNumber = newContact.PhnNumber;
            oldContact.Email = newContact.Email;
            oldContact.Note = newContact.Note;
        }

        /// <summary>
        /// Delete from in-memory
        /// </summary>
        /// <param name="index">index of contact object to be deleted</param>
        internal void DeleteContactFromRepo(int index)
        {
            _contactList.RemoveAt(index);
        }
    }
}