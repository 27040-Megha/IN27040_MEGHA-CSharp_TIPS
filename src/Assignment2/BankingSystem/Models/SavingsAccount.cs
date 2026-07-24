using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Models
{
    /// <summary>
    /// Implements a Saving account with normal deposit and withdrawal operations that checks Minimum balance.
    /// </summary>
    public class SavingsAccount : BankAccount
    {
        private decimal _minimumBalance = 1000;

        /// <summary>
        /// Initializes a new instance of the <see cref="SavingsAccount"/> class.
        /// Constructor that assigns the given parameters
        /// </summary>
        /// <param name="accountNumber">Account Number of the User</param>
        /// <param name="name">User Name</param>
        /// <param name="balance">Account Balance given by user when creating Object</param>
        public SavingsAccount(string accountNumber, string name, decimal balance)
        {
            AccountNumber = accountNumber;
            Name = name;
            Balance = balance;
        }

        /// <summary>
        /// Sets Account Type to Savings Account
        /// </summary>
        /// <value>
        /// Account Type 
        /// </value>
        public string AccountType => "Savings Account";

        /// <summary>
        /// Checks minimum balance, Updates and returns the balance amount after Subtracting the deposit amount with balance
        /// </summary>
        /// <param name="withdrawAmount">Amount to withdraw</param>
        /// <returns>-1.0 if insufficient balance, Balance amount after withdrawal</returns>
        public override decimal Withdraw(decimal withdrawAmount)
        {
            if ((Balance - withdrawAmount) >= _minimumBalance)
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
