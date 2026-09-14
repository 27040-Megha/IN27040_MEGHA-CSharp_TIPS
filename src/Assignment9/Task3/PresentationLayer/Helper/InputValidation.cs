using Task3.Domain;

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
            return int.TryParse(input, out int number)
                ? new Result(true, number)
                : new Result(false, -1);
        }
    }
}
