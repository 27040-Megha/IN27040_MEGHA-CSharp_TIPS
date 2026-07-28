using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSystem.Models;
using BankingSystem.Repository;

namespace BankingSystem.Services
{
    /// <summary>
    /// Contains the business logic of the Banking System
    /// </summary>
    public class BankingService
    {
        private BankRepository _bankRepo = new BankRepository();

        /// <summary>
        /// Create Bank Account Object and Add in repo
        /// </summary>
        /// <param name="accountNumber">Account Number of the user</param>
        /// <param name="name">Name of the user</param>
        /// <param name="balance">Balane </param>
        /// <param name="accountType">Account Type</param>
        /// <returns>true upon successfull account creation otherwise false</returns>
        public bool CreateBankAccount(string accountNumber, string name, decimal balance, string accountType)
        {
            var existingAccount = _bankRepo.GetAccountByNumber(accountNumber);
            if (existingAccount != null)
            {
                return false; 
            }

            if (accountType.Equals("Savings"))
            {
                var savingAccount = new SavingsAccount(accountNumber, name, balance);
                _bankRepo.AddAccountInRepo(savingAccount);
            }
            else
            {
                var checkingAccount = new CheckingAccount(accountNumber, name, balance);
                _bankRepo.AddAccountInRepo(checkingAccount);
            }

            return true; 
        }

        /// <summary>
        /// Gets the Bank Account object from Repo by Account Number and performs withdraw logic
        /// </summary>
        /// <param name="accountNumber">Account Number of the user</param>
        /// <param name="amount">Amount to withdraw</param>
        /// <returns>Balance upon successful withdrawl, -2.0 if account not found</returns>
        public decimal WithdrawAmount(string accountNumber, decimal amount)
        {
            var bankAccount = _bankRepo.GetAccountByNumber(accountNumber);
            if (bankAccount == null)
            {
                return -2.0m;
            }
            decimal updatedBalance = bankAccount.Withdraw(amount);
            return updatedBalance;
        }

        /// <summary>
        /// Gets the Bank Account object from Repo by Account Number and performs deposit logic
        /// </summary>
        /// <param name="accountNumber">Account Number of the user</param>
        /// <param name="amount">Amount to deposit</param>
        /// <returns>Balance upon successful deposit, -2.0 if account not found</returns>
        public decimal DepositAmount(string accountNumber, decimal amount)
        {
            var bankAccount = _bankRepo.GetAccountByNumber(accountNumber);
            if (bankAccount == null)
            {
                return -2.0m;
            }
            decimal updatedBalance = bankAccount.Deposit(amount);
            return updatedBalance;
        }
    }
}
