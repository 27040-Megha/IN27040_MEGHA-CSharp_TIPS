using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Models
{
    public interface IBankAccount
    {
        public string AccountNumber { get; set; }

        public string Name { get; set; }

        public decimal Balance { get; set; }

        public string AccountType { get; }

        public abstract decimal Deposit(decimal depositAmount);

        public abstract decimal Withdraw(decimal withDrawAmount);
    }
}
