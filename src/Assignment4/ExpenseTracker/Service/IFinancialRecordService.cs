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
        public void AddIncome(decimal amount, DateOnly date, string description, string source);

        public void AddExpense(decimal amount, DateOnly date, string description, string category);

        public bool UpdateIncome(Guid id, decimal amount, DateOnly date, string description, string source);

        public bool UpdateExpense(Guid id, decimal amount, DateOnly date, string description, string category);

        public bool DeleteIncomeRecord(Guid id);

        public bool DeleteExpenseRecord(Guid id);

        public Income? GetIncomeById(Guid id);

        public Expense? GetExpenseById(Guid id);

        public IReadOnlyList<Income> GetAllIncome();

        public IReadOnlyList<Expense> GetAllExpense();
    }
}
