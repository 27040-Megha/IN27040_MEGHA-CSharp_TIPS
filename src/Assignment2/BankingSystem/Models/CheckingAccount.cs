using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Models
{
    /// <summary>
    /// Implements a checking account with normal deposit and withdrawal operations.
    /// </summary>
    public class CheckingAccount : BankAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckingAccount"/> class.
        /// Constructor that assigns the given parameters
        /// </summary>
        /// <param name="accountNumber">Account Number of the User</param>
        /// <param name="name">User Name</param>
        /// <param name="balance">Account Balance given by user when creating Object</param>
        public CheckingAccount(string accountNumber, string name, decimal balance)
        {
            AccountNumber = accountNumber;
            Name = name;
            Balance = balance;
        }

        /// <summary>
        /// Sets Account Type to Checking Account
        /// </summary>
        /// <value>
        /// Account Type 
        /// </value>
        public string AccountType => "Checking Account";

        /// <summary>
        /// Updates and returns the balance amount after Subtracting the deposit amount with balance
        /// </summary>
        /// <param name="withdrawAmount">Amount to withdraw</param>
        /// <returns>-1.0 if insufficient balance, Balance amount after withdrawl</returns>
        public override decimal Withdraw(decimal withdrawAmount)
        {
            if (Balance >= withdrawAmount)
            {
                Balance-=withdrawAmount;
                return Balance;
            }
            return -1.0m;
        }
    }
}
