using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicContactManagemenet.Helper
{
    /// <summary>
    /// Provides validation function for contact Phone Number.
    /// </summary>
    internal class PhoneNumberValidation
    {
        /// <summary>
        /// Validates whether the specified Phone Number contains only 10 digits
        /// </summary>
        /// <param name="phnNumbers">List of phone numbers to validate</param>
        /// <returns>true if all the phone numbers in list  is valid otherwise false</returns>
        internal static bool ValidatePhnNumber(List<string> phnNumbers)
        {
            foreach (var phnNumber in phnNumbers)
            {
                bool isParsingSuccessful = long.TryParse(phnNumber, out long result);
                if (!isParsingSuccessful || phnNumber.Length != 10 || result < 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
