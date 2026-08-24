using System;
using System.Linq;
using ExpenseTracker.Models;

namespace ExpenseTracker.Validation
{
    /// <summary>
    /// Input Validator class
    /// </summary>
    public static class InputValidator
    {
        /// <summary>
        /// Validates amount and returns as a result object
        /// </summary>
        /// <param name="input">User Input as string</param>
        /// <returns>Result Object - Success/Failure Message, Valid Amount</returns>
        public static Result ValidateAmount(string input)
        {
            if (!decimal.TryParse(input, out decimal amount))
            {
                return new Result(false, "Value must be a numeric decimal number.");
            }

            if (amount <= 0)
            {
                return new Result(false, "Financial amounts should be greater than 0.");
            }

            return new Result(true, "Amount validated successfully.", amount);
        }

        /// <summary>
        /// Validates Date and returns as a result object
        /// </summary>
        /// <param name="input">User Input as string</param>
        /// <returns>Result Object - Success/Failure Message, Valid Date</returns>
        public static Result ValidateDate(string input)
        {
            if (!DateTime.TryParse(input, out DateTime date))
            {
                return new Result(false, "Date format invalid. Eg. YYYY/MM/DD/.");
            }

            return new Result(true, "Date validated successfully.", date);
        }

        /// <summary>
        /// Validates amot and returns as a result object
        /// </summary>
        /// <param name="input">User Input as string</param>
        /// <param name="fieldName">Category of Expense/Source of Income/Description</param>
        /// <returns>Result Object - Success/Failure Message, Valid Amount</returns>
        public static Result ValidateString(string input, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(input) || !input.All(char.IsLetter))
            {
                return new Result(false, $"{fieldName} cannot be empty or whitespace and should have only letters.");
            }

            return new Result(true, $"{fieldName} validated successfully.", input);
        }
    }
}
