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
        /// Gets or sets the global repository of saved contact records.
        /// </summary> 
        /// <value>A list containing all active ContactInfo instances in the application.</value> 
        public static List<ContactInfo> ContactList { get; set; } = new List<ContactInfo>();

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="contact">Adds to List</param>
        public void StoreInContactList(ContactInfo contact)
        {
            ContactList.Add(contact);
        }

        /// <summary>
        /// Read
        /// </summary>
        /// <returns>returns Contact List</returns>
        public List<ContactInfo> ReturnContactList()
        {
            return ContactList;
        }

        /// <summary>
        /// UpdateContact List
        /// </summary>
        /// <param name="index">index</param>
        /// <param name="newContact">contact Object</param>
        public void UpdateContactList(int index, ContactInfo newContact)
        {
            ContactInfo oldContact = ContactList[index];
            oldContact.Name = newContact.Name;
            oldContact.PhnNumber = newContact.PhnNumber;
            oldContact.Email = newContact.Email;
            oldContact.Note = newContact.Note;
        }

        /// <summary>
        /// Delete from in-memory
        /// </summary>
        /// <param name="index">index</param>
        public void DeleteContactFromRepo(int index)
        {
            ContactList.RemoveAt(index);
        }
    }
}