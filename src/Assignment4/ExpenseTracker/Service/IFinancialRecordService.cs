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

        public Result UpdateIncome(int index, decimal amount, DateOnly date, string description, string source);

        public Result UpdateExpense(int index, decimal amount, DateOnly date, string description, string category);

        public Result DeleteIncomeRecord(int index);

        public Result DeleteExpenseRecord(int index);

        public int GetIncomeCount();

        public int GetExpenseCount();

        public IReadOnlyList<Income> GetAllIncome();

        public IReadOnlyList<Expense> GetAllExpense();
    }
}
