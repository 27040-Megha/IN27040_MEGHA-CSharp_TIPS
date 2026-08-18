using System;
using ErrorHandlingTasks.Domain;

namespace ErrorHandlingTasks.PresentationLayer.Helper
{
    /// <summary>
    /// Helper class that validates user input format
    /// </summary>
    public static class InputValidator
    {
        /// <summary>
        /// Validates whether the user input is a proper integer, if not throws a FormatException
        /// </summary>
        /// <param name="number">User Input string</param>
        /// <returns>Parsed Integer</returns>
        /// <exception cref="InvalidUserInputException">Custom Exception InvalidUserInputException will be thrown</exception>
        public static int ValidateNumber(string number)
        {
            try
            {
                return int.Parse(number);
            }
            catch (FormatException ex)
            {
                throw new InvalidUserInputException($"Input should be a valid Integer", ex);
            }
        }
    }
}
