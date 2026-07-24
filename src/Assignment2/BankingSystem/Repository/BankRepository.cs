using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSystem.Models;

namespace BankingSystem.Repository
{
    /// <summary>
    /// Handles storage and retrieval of account data
    /// </summary>
    public class BankRepository
    {
        private List<BankAccount> _bankAccountList = new List<BankAccount>();

        /// <summary>
        /// Add Account to in-memory storage
        /// </summary>
        /// <param name="bankObject">Savings or Checking account object(Subclasses object) </param>
        public void AddAccountInRepo(BankAccount bankObject)
        {
            _bankAccountList.Add(bankObject);
        }

        /// <summary>
        /// Returns in-memory storage
        /// </summary>
        /// <returns>List of BankAccount object</returns>
        public List<BankAccount> GetBankAccounts()
        {
            return _bankAccountList;
        }

        /// <summary>
        /// Finds Account by Account Nymber
        /// </summary>
        /// <param name="accountNumber">Account Number needed to be searched</param>
        /// <returns>BankAccount Object</returns>
        public BankAccount GetAccountByNumber(string accountNumber)
        {
            for (int i = 0; i < _bankAccountList.Count; i++)
            {
                if (_bankAccountList[i].AccountNumber.Equals(accountNumber))
                {
                    return _bankAccountList[i];
                }
            }
            return null;
        }
    }
}
