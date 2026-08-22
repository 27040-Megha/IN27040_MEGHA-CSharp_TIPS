using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Helper
{
    /// <summary>
    /// Provides static methods for validating banking system input fields such as names, account numbers, and monetary amounts.
    /// </summary>
    public static class FieldValidation
    {
        /// <summary>
        /// Validates whether the provided name string is not empty and contains only alphabetical characters.
        /// </summary>
        /// <param name="name">The name string to validate.</param>
        /// <returns><see langword="true"/> if the name is valid; otherwise, <see langword="false"/>.</returns>
        public static bool IsValidName(string name)
        {
            return !string.IsNullOrEmpty(name) && name.All(char.IsLetter);
        }

        /// <summary>
        /// Validates whether the provided account number is not empty, is exactly 12 characters long, and contains only numeric digits.
        /// </summary>
        /// <param name="accountNumber">The account number string to validate.</param>
        /// <returns><see langword="true"/> if the account number is valid; otherwise, <see langword="false"/>.</returns>
        public static bool IsValidAccountNumber(string accountNumber)
        {
            return !string.IsNullOrEmpty(accountNumber) && accountNumber.Length == 12 && accountNumber.All(char.IsDigit);
        }

        /// <summary>
        /// Validates whether the specified monetary amount is greater than zero.
        /// </summary>
        /// <param name="amount">The decimal amount to validate.</param>
        /// <returns><see langword="true"/> if the amount is greater than zero; otherwise, <see langword="false"/>.</returns>
        public static bool IsValidAmount(decimal amount)
        {
            return amount > 0;
        }
    }
}
