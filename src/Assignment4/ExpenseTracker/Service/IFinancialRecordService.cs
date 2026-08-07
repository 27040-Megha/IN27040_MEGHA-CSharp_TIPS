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
        public void SaveIncome(decimal amount, DateOnly date, string description, string source);

        public void SaveExpense(decimal amount, DateOnly date, string description, string category);

        public Result ModifyIncome(int index, decimal amount, DateOnly date, string description, string source);

        public Result ModifyExpense(int index, decimal amount, DateOnly date, string description, string category);

        public Result RemoveIncome(int index);

        public Result RemoveExpense(int index);

        public int GetIncomeCount();

        public int GetExpenseCount();

        public IReadOnlyList<Income> GetAllIncome();

        public IReadOnlyList<Expense> GetAllExpense();
    }
}
