namespace Task3.PresentationLayer.Helper
{
    /// <summary>
    /// Class to validate inputs
    /// </summary>
    public static class InputValidation
    {
        /// <summary>
        /// Validates integer
        /// </summary>
        /// <param name="input">Integer</param>
        /// <returns>Result object</returns>
        public static Result ValidateInteger(string input)
        {
            int number;
            if (!int.TryParse(input, out number))
            {
                return new Result(false, -1);
            }

            return new Result(true, number);
        }
    }
}
