using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicContactManagemenet.Helper
{
    internal class EmailValidation
    {
        public static bool ValidateEmail(string email)
        {
            if(email.Contains("@") && email.Contains("."))
            {
                return true;
            }
            return false;
        }
    }
}
