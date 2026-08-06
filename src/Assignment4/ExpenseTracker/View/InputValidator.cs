using System;
using ExpenseTracker.Common;

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

            if (amount < 0)
            {
                return new Result(false, "Financial amounts cannot be negative values.");
            }

            return new Result(true, "Amount validated successfully.", amount);
        }

        public static Result ValidateDate(string input)
        {
            if (!DateOnly.TryParse(input, out DateOnly date))
            {
                return new Result(false, "Date format invalid. Use YYYY/MM/DD/.");
            }
            return new Result(true, "Date validated successfully.", date);
        }

        public static Result ValidateString(string input, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return new Result(false, $"{fieldName} cannot be empty or whitespace.");
            }
            return new Result(true, $"{fieldName} validated successfully.", input);
        }

        public static Result ValidateGuid(string input)
        {
            if (!Guid.TryParse(input, out Guid id))
            {
                return new Result(false, "ID entry is not a valid 32-digit GUID.");
            }
            return new Result(true, "GUID validated successfully.", id);
        }
    }
}
