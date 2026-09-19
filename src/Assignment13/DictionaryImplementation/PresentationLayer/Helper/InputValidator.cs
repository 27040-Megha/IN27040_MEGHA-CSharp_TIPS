using System.Linq;

namespace Helper
{
    /// <summary>
    /// Class contains methods to validate input given by user
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
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            return input.All(ch => char.IsLetter(ch) || char.IsWhiteSpace(ch));
        }

        /// <summary>
        /// Checks whether a given string input can be safely parsed to an integer, and assigns the parsed value to number, which will be returned to user using Out keyword
        /// </summary>
        /// <param name="input">Input string to be parsed</param>
        /// <param name="number">number will be assigned to the parse value on successful parsing; otherwise will be assigned -1</param>
        /// <returns>true if given string can be parsed to valid integer; otherwise false</returns>
        public static bool ValidateInteger(string input, out int number)
        {
            return int.TryParse(input, out number);
        }
    }
}
