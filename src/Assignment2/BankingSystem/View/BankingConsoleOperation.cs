using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSystem.Helper;
using BankingSystem.Services;

namespace BankingSystem.View
{
    /// <summary>
    /// Handles user interaction through the console.
    /// </summary>
    public class BankingConsoleOperation
    {
        private BankingService _bankingService = new BankingService();
        
        /// <summary>
        /// Handles menu
        /// </summary>
        public void HandleMenu()
        {
            Console.WriteLine("Banking System");
            int choice;
            do
            {
                DisplayMenu();
                string inputChoice = Console.ReadLine();
                bool isValidChoice = int.TryParse(inputChoice, out choice);
                if(!isValidChoice)
                {
                    choice = 0;
                }
                switch (choice)
                {
                    case 1:
                        AddBankAccount();
                        break;
                    case 2:
                        WithdrawFromAccount();
                        break;
                    case 3:
                        DepositAmount();
                        break;
                    default:
                        Console.WriteLine("Enter choice (1/2/3): ");
                        break;
                }
            } 
            while (choice != 4);
        }

        private void DisplayMenu()
        {
            Console.WriteLine("\nMENU\n" +
                "1. Add Account\n" +
                "2. Withdraw\n" +
                "3. Deposit\n" +
                "4. Exit\n" +
                "Enter Your choice (1/2/3/4):");
        }

        private void AddBankAccount()
        {
            var details = GetAccountDetailsInput();
            if (details == null)
            {
                return;
            }
            var (accountNumber, name, balance, accountType) = details.Value;
            _bankingService.CreateBankAccount(accountNumber, name, balance, accountType);
        }

        private (string accountNumber, string name, decimal balance, string accountType)? GetAccountDetailsInput()
        {
            string accountNumber = GetAccountNumber();
            if (accountNumber == null)
            {
                return null;
            }
            Console.WriteLine("Enter Account Holder Name: ");
            string name = Console.ReadLine();
            if (!FieldValidation.IsValidName(name))
            {
                Console.WriteLine("Validation Error: Name must contain alphabets only. Returning to menu.");
                return null;
            }
            Console.WriteLine("Enter Initial amount deposit: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || !FieldValidation.IsValidAmount(amount) || !ValidateInitialAmount(amount))
            {
                Console.WriteLine("Invalid initial deposit amount");
                return null;
            }
            Console.WriteLine("Enter Account Type (1-Savings, 2-Checking): ");
            string accountTypeInput = Console.ReadLine();
            string accountType = ValidateAndGetAccountType(accountTypeInput);
            if (accountType == null)
            {
                Console.WriteLine("Invalid Account Type. Must be 1 or 2.");
                return null;
            }
            return (accountNumber, name, amount, accountType);
        }

        private string? ValidateAndGetAccountType(string input)
        {
            if (input == "1")
            {
                return "Savings";
            }
            else if (input == "2")
            {
                return "Checking";
            }
            else
            {
                return null;
            }
        }

        private string GetAccountNumber()
        {
            Console.WriteLine("Enter Account Number (Exactly 12 digits): ");
            string accountNumber = Console.ReadLine();
            if (!FieldValidation.IsValidAccountNumber(accountNumber))
            {
                Console.WriteLine("Account Number must be exactly 12 numeric digits.");
                return null;
            }
            return accountNumber;
        }

        private bool ValidateInitialAmount(decimal amount)
        {
            decimal initialDepositAmount = 1000;
            if (amount >= initialDepositAmount)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Minimum initial deposit should be Rs.1000.");
                return false;
            }
        }

        private void WithdrawFromAccount()
        {
            string accountNumber = GetAccountNumber();
            if (accountNumber == null)
            {
                return;
            }
            Console.WriteLine("Enter Amount to Withdraw: ");
            decimal.TryParse(Console.ReadLine(), out decimal amount);
            if(!ValidateAmount(amount))
            {
                return;
            }
            decimal result = _bankingService.WithdrawService(accountNumber, amount);
            if (result == -2.0m)
            {
                Console.WriteLine("Account not found.");
            }
            else if (result == -1.0m)
            {
                Console.WriteLine("Transaction Failed. Insufficient balance in Account.");
            }
            else
            {
                Console.WriteLine($"Withdrawal successful! New balance: Rs.{result}");
            }
        }

        private bool ValidateAmount(decimal amount)
        {
            if (!FieldValidation.IsValidAmount(amount))
            {
                Console.WriteLine("Please enter a valid amount greater than 0.");
                return false;
            }
            return true;
        }

        private void DepositAmount()
        {
            string accountNumber = GetAccountNumber();
            if (accountNumber == null)
            {
                return;
            }
            Console.WriteLine("Enter Amount to Deposit: ");
            decimal.TryParse(Console.ReadLine(), out decimal amount);
            if (!ValidateAmount(amount))
            {
                return;
            }
            decimal result = _bankingService.DepositService(accountNumber, amount);
            if (result == -2.0m)
            {
                Console.WriteLine("Account not found.");
            }
            else
            {
                Console.WriteLine($"Deposit successful! New balance: Rs.{result}");
            }
        }
    }
}
  