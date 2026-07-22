using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSystem.Models;
using BankingSystem.Repository;

namespace BankingSystem.Services
{
    public class BankingService
    {
        private BankRepository _bankRepo = new BankRepository();
        public void CreateBankAccount(string accountNumber, string name, decimal balance, string accountType)
        {
            if(accountType.Equals("Saving"))
            {
                SavingsAccount savingAccount = new SavingsAccount(accountNumber, name, balance);
                _bankRepo.AddAccountInRepo(savingAccount);
            }
            else
            {
                CheckingAccount checkingAccount = new CheckingAccount(accountNumber, name, balance);
                _bankRepo.AddAccountInRepo(checkingAccount);
            }
        }

        public decimal WithdrawService(string accountNumber, decimal amount)
        {
            IBankAccount bankAccount = _bankRepo.GetAccountByNumber(accountNumber);
            if (bankAccount == null)
            {
                return -2.0m;
            }
            decimal result = bankAccount.Withdraw(amount);
            if (result != -1.0m)
            {
                _bankRepo.UpdateAccountInRepo(bankAccount);
            }
            return result;
        }

        public decimal DepositService(string accountNumber, decimal amount)
        {
            IBankAccount bankAccount = _bankRepo.GetAccountByNumber(accountNumber);
            if (bankAccount == null)
            {
                return -2.0m;
            }
            decimal result = bankAccount.Deposit(amount);
            if (result != -1.0m)
            {
                _bankRepo.UpdateAccountInRepo(bankAccount);
            }
            return result;
        }
    }
}
