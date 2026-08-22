using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Models
{
    /// <summary>
    /// Abstract class BankAccount defines structure of Bank Account
    /// </summary>
    public abstract class BankAccount
    {
        /// <summary>
        /// Gets or sets account number of the user
        /// </summary>
        /// <value>
        /// Account number of the user
        /// </value>     
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets Name of the account user
        /// </summary>
        /// <value>
        /// Name of the account user
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Balance of the account
        /// </summary>
        /// <value>
        /// Account Balance
        /// </value>
        public decimal Balance { get; set; }

        /// <summary>
        /// Sets Account Type to Checking Account
        /// </summary>
        /// <value>
        /// Account Type 
        /// </value>
        public string AccountType { get; }

        /// <summary>
        /// Concrete method that handles Deposit of Amount for all derived bank accounts
        /// </summary>
        /// <param name="depositAmount">Amount to be deposited</param>
        /// <returns>Balance amount after deposit</returns>
        public decimal Deposit(decimal depositAmount)
        {
            Balance += depositAmount;
            return Balance;
        }

        /// <summary>
        /// Abstract method that subclass overrides for Withdraw of Amount
        /// </summary>
        /// <param name="withDrawAmount">Amount to withdraw</param>
        /// <returns>Balance amount after withdrawal</returns>
        public abstract decimal Withdraw(decimal withDrawAmount);
    }
}
