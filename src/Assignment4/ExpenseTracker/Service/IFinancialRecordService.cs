using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Models;

namespace ExpenseTracker.Service
{
    public interface IFinancialRecordService
    {
        public void AddIncome(decimal amount, DateTime date, string description, string source);

        public void AddExpense(decimal amount, DateTime date, string description, string category);

        public bool UpdateIncome(Guid id, decimal amount, DateTime date, string description, string source);

        public bool UpdateExpense(Guid id, decimal amount, DateTime date, string description, string category);

        public void DeleteIncomeRecord(Guid id);

        public void DeleteExpenseRecord(Guid id);

        public Expense? GetExpenseById(Guid id);

        public Income? GetIncomeById(Guid id);

        public IEnumerable<Income> GetAllIncome();

        public IEnumerable<Expense> GetAllExpense();

        public decimal GetBalance();
    }
}
