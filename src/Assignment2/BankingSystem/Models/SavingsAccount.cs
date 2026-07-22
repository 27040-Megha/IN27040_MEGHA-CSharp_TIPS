using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Models
{
    public class SavingsAccount : IBankAccount
    {
        private decimal _minimumBalance = 1000;

        public SavingsAccount(string accountNumber, string name, decimal balance)
        {
            AccountNumber = accountNumber;
            Name = name;
            Balance = balance;
        }

        public string AccountNumber { get; set; }

        public string Name { get; set; }

        public decimal Balance { get; set; }

        public string AccountType => "Savings Account";

        public decimal Deposit(decimal depositAmount)
        {
            Balance+=depositAmount;
            return Balance;
        }

        public decimal Withdraw(decimal withdrawAmount)
        {
            if ((Balance >= withdrawAmount) && ((Balance - withdrawAmount) >= _minimumBalance))
            {
                Balance-=withdrawAmount;
                return Balance;
            }
            else
            {
                return -1.0m;
            }
        }
    }
}
