using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Helper
{
    public static class FieldValidation
    {
        public static bool IsValidName(string name)
        {
            return !string.IsNullOrEmpty(name) && name.All(char.IsLetter);
        }

        public static bool IsValidAccountNumber(string accountNumber)
        {
            return !string.IsNullOrEmpty(accountNumber) && accountNumber.Length == 12 && accountNumber.All(char.IsDigit);
        }

        public static bool IsValidAmount(decimal amount)
        {
            return amount > 0;
        }
    }
}
