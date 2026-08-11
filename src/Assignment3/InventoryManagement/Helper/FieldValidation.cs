using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace InventoryManagement.Helper
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
            if (string.IsNullOrEmpty(productID) || productID.Length != 8)
            {
                return false;
            }

            if (!productID.StartsWith("PROD", StringComparison.Ordinal))
            {
                return false;
            }

            return Regex.IsMatch(productID.Substring(4), @"^\d{4}$");
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
                return false;
            }

            return true;
        }
    }
}
