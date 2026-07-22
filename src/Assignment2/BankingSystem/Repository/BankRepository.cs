using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSystem.Models;

namespace BankingSystem.Repository
{
    public class BankRepository
    {
        private List<IBankAccount> _bankAccountList = new List<IBankAccount>();

        public void AddAccountInRepo(IBankAccount bankObject)
        {
            _bankAccountList.Add(bankObject);
        }

        public List<IBankAccount> GetBankAccounts()
        {
            return _bankAccountList;
        }

        public IBankAccount GetAccountByNumber(string accountNumber)
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

        public void UpdateAccountInRepo(IBankAccount updatedAccount)
        {
            for (int i = 0; i < _bankAccountList.Count; i++)
            {
                if (_bankAccountList[i].AccountNumber == updatedAccount.AccountNumber)
                {
                    _bankAccountList[i] = updatedAccount;
                    break;
                }
            }
        }
    }
}
