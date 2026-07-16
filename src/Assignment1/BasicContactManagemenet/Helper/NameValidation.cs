using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicContactManagemenet.Helper
{
    /// <summary>
    /// Class for Name Validation
    /// </summary>
    internal class NameValidation
    {
        /// <summary>
        /// Function for Name Validation
        /// </summary>
        /// <param name="name">Contact Name</param>
        /// <returns>Boolean Value</returns>
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
