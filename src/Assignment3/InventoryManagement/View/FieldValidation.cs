using System;
using System.Linq;

namespace InventoryManagement.View
{
    /// <summary>
    /// Class contains methods that validates fields
    /// </summary>
    public static class FieldValidation
    {
        /// <summary>
        /// Checks if Product is of the format PRODXXXX - Eg: PROD1234
        /// </summary>
        /// <param name="productID">ProductID of the product</param>
        /// <returns>true if given productID is valid, otherwise false</returns>
        public static bool ValidateProductID(string productID)
        {
            try
            {
                if (productID.Length != 8)
                {
                    return false;
                }

                if (!productID.Substring(0, 4).Equals("PROD"))
                {
                    return false;
                }

                string suffix = productID.Substring(4, 4);
                foreach (char ch in suffix)
                {
                    if (!char.IsDigit(ch))
                    {
                        return false;
                    }
                }

                return true;
            }
            catch (NullReferenceException ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Validates whether the input string contains only characters
        /// </summary>
        /// <param name="inputString">Name or Category of product</param>
        /// <returns>true if string is valid, otherwise false</returns>
        public static bool ValidateString(string inputString)
        {
            if (string.IsNullOrEmpty(inputString) || !inputString.All(char.IsLetter))
            {
                InventoryConsoleOperations.WriteRedLine(InventoryResource.InvalidStringFormat);
                return false;
            }

            return true;
        }
    }
}
