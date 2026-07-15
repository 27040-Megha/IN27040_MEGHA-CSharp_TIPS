using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicContactManagement.Models
{
    /// <summary>
    /// Structure of Contacts
    /// </summary>
    public class ContactInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactInfo"/> class.
        /// </summary>      
        /// <param name="name">name of contact</param>
        /// <param name="phnNumber">phnNumber of contact</param>
        /// <param name="email">email of contact</param>
        /// <param name="note">Description of contact</param>
        public ContactInfo(string name, string phnNumber, string email, string note)
        {
            Id = Guid.NewGuid();
            Name = name;
            PhnNumber = phnNumber;
            Email = email;
            Note = note;
        }

        /// <summary>
        /// Randomly Generated Unique ID
        /// </summary>
        /// <value>
        /// ID
        /// </value>
        public Guid Id { get; set; }
        /// <summary>
        /// Name of Contact
        /// </summary>
        /// <value>The name of the contact.</value>
        public string? Name { get; set; }
        /// <summary>
        /// Name of PhnNumber
        /// </summary>
        /// <value>The PhnNumber of the contact.</value>
        public string? PhnNumber { get; set; }
        /// <summary>
        /// Email of Contact
        /// </summary>
        /// <value>The Email of the contact.</value>
        public string? Email { get; set; }
        /// <summary>
        /// Note of Contact
        /// </summary>
        /// <value>The note of the contact.</value>
        public string? Note { get; set; }
    }
}