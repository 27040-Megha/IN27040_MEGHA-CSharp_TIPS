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
            Console.WriteLine(BankingMessages.AppTitle);
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
                        Console.WriteLine(BankingMessages.InvalidMenuChoice);
                        break;
                }
            } 
            while (choice != 4);
        }

        private void DisplayMenu()
        {
            Console.WriteLine(BankingMessages.MenuOptions);
        }

        private void AddBankAccount()
        {
            var details = GetAccountDetailsInput();
            if (details.Equals(null))
            {
                return;
            }
            var (accountNumber, name, balance, accountType) = details.Value;
            bool isCreated = _bankingService.CreateBankAccount(accountNumber, name, balance, accountType);
            if (!isCreated)
            {
                Console.WriteLine(BankingMessages.AccountAlreadyExistsError);
            }
            else
            {
                Console.WriteLine(BankingMessages.AccountCreationSuccessful);
            }
        }

        private (string accountNumber, string name, decimal balance, string accountType)? GetAccountDetailsInput()
        {
            string accountNumber = GetAccountNumber();
            if (accountNumber == null)
            {
                return null;
            }
            Console.WriteLine(BankingMessages.NamePrompt);
            string name = Console.ReadLine();
            if (!FieldValidation.IsValidName(name))
            {
                Console.WriteLine(BankingMessages.InvalidNameError);
                return null;
            }
            Console.WriteLine(BankingMessages.InitialDepositPrompt);
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || !FieldValidation.IsValidAmount(amount) || !ValidateInitialAmount(amount))
            {
                return null;
            }
            Console.WriteLine(BankingMessages.AccountTypePrompt);
            string accountTypeInput = Console.ReadLine();
            string accountType = ValidateAndGetAccountType(accountTypeInput);
            if (accountType == null)
            {
                Console.WriteLine(BankingMessages.InvalidAccountType);
                return null;
            }
            return (accountNumber, name, amount, accountType);
        }

        private string ValidateAndGetAccountType(string input)
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
            Console.WriteLine(BankingMessages.AccountNumberPrompt);
            string accountNumber = Console.ReadLine();
            if (!FieldValidation.IsValidAccountNumber(accountNumber))
            {
                Console.WriteLine(BankingMessages.InvalidAccountNumber);
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
            Console.WriteLine(BankingMessages.InvalidInitialDeposit);
            return false;
        }

        private void WithdrawFromAccount()
        {
            string accountNumber = GetAccountNumber();
            if (accountNumber == null)
            {
                return;
            }
            Console.WriteLine(BankingMessages.WithdrawPrompt);
            decimal.TryParse(Console.ReadLine(), out decimal amount);
            if(!ValidateAmount(amount))
            {
                return;
            }
            decimal result = _bankingService.WithdrawService(accountNumber, amount);
            if (result == -2.0m)
            {
                Console.WriteLine(BankingMessages.AccountNotFoundError);
            }
            else if (result == -1.0m)
            {
                Console.WriteLine(BankingMessages.InsufficientBalanceError);
            }
            else
            {
                Console.WriteLine(string.Format(BankingMessages.WithdrawSuccess, result));
            }
        }

        private bool ValidateAmount(decimal amount)
        {
            if (!FieldValidation.IsValidAmount(amount))
            {
                Console.WriteLine(BankingMessages.InvalidAmountError);
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
            Console.WriteLine(BankingMessages.DepositPrompt);
            decimal.TryParse(Console.ReadLine(), out decimal amount);
            if (!ValidateAmount(amount))
            {
                return;
            }
            decimal result = _bankingService.DepositService(accountNumber, amount);
            if (result == -2.0m)
            {
                Console.WriteLine(BankingMessages.AccountNotFoundError);
            }
            else
            {
                Console.WriteLine(string.Format(BankingMessages.DepositSuccess, result));
            }
        }
    }
}
  