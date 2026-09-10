namespace InputValidator
{
    /// <summary>
    /// Class contains methods to validate Integer
    /// </summary>
    public static class IntegerValidator
    {
        /// <summary>
        /// Checks whether a given string input can be safely parsed to an integer, and assigns the parsed value to number, which will be returned to user using Out keyword
        /// </summary>
        /// <param name="input">Input string to be parsed</param>
        /// <param name="number">number will be assigned to the parse value on successful parsing; otherwise will be assigned -1</param>
        /// <returns>true if given string can be parsed to valid integer; otherwise false</returns>
        public static bool ValidateInteger(string input, out int number)
        {
            number = -1;
            if (int.TryParse(input, out int value))
            {
                number = value;
                return true;
            }

            return false;
        }
    }
}
