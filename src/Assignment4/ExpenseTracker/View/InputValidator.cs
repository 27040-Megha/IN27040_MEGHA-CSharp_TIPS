using System;
using System.Linq;
using ExpenseTracker.Models;

namespace ExpenseTracker.Validation
{
    public static class InputValidator
    {
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

        public static Result ValidateDate(string input)
        {
            if (!DateOnly.TryParse(input, out DateOnly date))
            {
                return new Result(false, "Date format invalid. Eg. YYYY/MM/DD/.");
            }
            return new Result(true, "Date validated successfully.", date);
        }

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
