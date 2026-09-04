namespace CalculatorApp.PresentationLayer.Helper
{
    /// <summary>
    /// Input Validator class
    /// </summary>
    public static class InputValidation
    {
        /// <summary>
        /// Checks if only user enters numbers and operators +,-,/,*
        /// </summary>
        /// <param name="input">Input Character user enters</param>
        /// <returns>true if valid input, otherwise false</returns>
        public static bool IsValidInput(char input)
        {
            return (input >= '0' && input <= '9') || input == '+' || input == '-' || input == '/' || input == '*';
        }
    }
}
