using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicContactManagemenet.Helper
{
    internal class PhoneNumberValidation
    {
        public static bool ValidatePhnNumber(string phnNumber)
        {
            bool isParsingSuccessful = long.TryParse(phnNumber, out long result);
            if (isParsingSuccessful==true && phnNumber.Length==10)
            {
                return true;
            }
            return false;
        }
    }
}
