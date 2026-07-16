using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicContactManagemenet.Helper
{
    /// <summary>
    /// Class for PhoneNumber Validation
    /// </summary>
    internal class PhoneNumberValidation
    {
        /// <summary>
        /// Function for PhoneNumber Validation
        /// </summary>
        /// <param name="phnNumber">Phone Number</param>
        /// <returns>Boolean Value</returns>
        internal static bool ValidatePhnNumber(string phnNumber)
        {
            bool isParsingSuccessful = long.TryParse(phnNumber, out long result);
            if (isParsingSuccessful && phnNumber.Length==10)
            {
                return true;
            }
            return false;
        }
    }
}
