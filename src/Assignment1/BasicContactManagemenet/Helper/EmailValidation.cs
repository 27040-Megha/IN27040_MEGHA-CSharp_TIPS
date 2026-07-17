using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicContactManagemenet.Helper
{
    /// <summary>
    /// Provides validation function for contact Email.
    /// </summary>
    internal class EmailValidation
    {
        /// <summary>
        /// Validates whether the specified email contains "@" and "."
        /// </summary>
        /// <param name="email">email to be validate</param>
        /// <returns>Returns true if the email is valid otherwise false</returns>
        internal static bool ValidateEmail(string email)
        {
            return email.Contains("@") && email.Contains(".");
        }
    }
}
