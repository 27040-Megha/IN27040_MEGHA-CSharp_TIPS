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
        internal static bool ValidatePhnNumber(List<string> phnNumber)
        {
            for (int i = 0; i < phnNumber.Count; i++)
            {
                bool isParsingSuccessful = long.TryParse(phnNumber[i], out long result);
                if (!isParsingSuccessful || !(phnNumber[i].Length == 10))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
