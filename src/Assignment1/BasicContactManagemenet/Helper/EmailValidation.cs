using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicContactManagemenet.Helper
{
    /// <summary>
    /// Class for Validating Email
    /// </summary>
    internal class EmailValidation
    {
        /// <summary>
        /// Function for validating email
        /// </summary>
        /// <param name="email">email input</param>
        /// <returns>boolean value</returns>
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
