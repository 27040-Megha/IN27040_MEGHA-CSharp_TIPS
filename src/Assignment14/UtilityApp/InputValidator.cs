namespace UtilityApp
{
    /// <summary>
    /// Input Validator class
    /// </summary>
    public static class InputValidator
    {
        /// <summary>
        /// Checks whether the input can be parsed to an integer
        /// </summary>
        /// <param name="input">Input string</param>
        /// <param name="number">Parsed Integer</param>
        /// <returns>true if valid integer, otherwise false</returns>
        public static bool ValidateIntger(string input, out int number)
        {
            return int.TryParse(input, out number);
        }
    }
}
