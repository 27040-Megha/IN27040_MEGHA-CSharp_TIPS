using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicContactManagement.Models
{
    public class ContactInfo
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? PhnNumber { get; set; }
        public string? Email { get; set; }
        public string? Note { get; set; }

        public ContactInfo(string name, string phnNumber, string email, string note)
        {
            Id = Guid.NewGuid();
            Name = name;
            PhnNumber = phnNumber;
            Email = email;
            Note = note;
        }
    }
}