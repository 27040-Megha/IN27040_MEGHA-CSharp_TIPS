using System;

namespace DisplayApp
{
    /// <summary>
    /// Contains methods that validates user input
    /// </summary>
    public class InputValidator
    {
        /// <summary>
        /// Checks whether an input can be parsed to an integer
        /// </summary>
        /// <param name="input">Input string to be parsed as integer</param>
        /// <param name="number">Parsed integer</param>
        /// <returns>true if parsed successfully, otherwise false</returns>
        public static bool ValidateIntger(string input, out int number)
        {
            return int.TryParse(input, out number);
        }
    }
}