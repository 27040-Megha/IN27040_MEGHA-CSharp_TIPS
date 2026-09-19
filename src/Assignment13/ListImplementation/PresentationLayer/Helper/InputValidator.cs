using System;
using System.Linq;

namespace Helper
{
    /// <summary>
    /// Class contains methods to validate strings
    /// </summary>
    public static class InputValidator
    {
        /// <summary>
        /// Checks whether a string is valid - Should not be null or empty, Should not have any special characters or numbers, Can contain only letters
        /// </summary>
        /// <param name="input">Input String to be validated</param>
        /// <returns>True if input is a valid string; false otherwise</returns>
        public static bool ValidateString(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return false;
            }

            return input.All(ch => char.IsLetter(ch) || char.IsWhiteSpace(ch));
        }
    }
}
