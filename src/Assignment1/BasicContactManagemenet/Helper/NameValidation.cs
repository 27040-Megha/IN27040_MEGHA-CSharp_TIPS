using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicContactManagemenet.Helper
{
    /// <summary>
    /// Provides validation function for contact names.
    /// </summary>
    internal class NameValidation
    {
        /// <summary>
        /// Validates whether the specified name contains only alphanumeric characters and is not empty.
        /// </summary>
        /// <param name="name">The contact name string to validate.</param>
        /// <returns>Returns true if the name is valid otherwise false</returns>
        internal static bool ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            for (int i = 0; i < name.Length; i++)
            {
                char c = name[i];

                if (!char.IsLetterOrDigit(c))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
