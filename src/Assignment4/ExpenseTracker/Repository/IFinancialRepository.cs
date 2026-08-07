using System;
using System.Collections.Generic;
using ExpenseTracker.Models;

namespace ExpenseTracker.Repository
{
    public interface IFinancialRepository
    {
        public void AddIncome(Income record);

        public void AddExpense(Expense record);

        public void UpdateIncome(Income oldRecord, Income newRecord);

        public void UpdateExpense(Expense oldRecord, Expense newRecord);

        public void DeleteIncome(Income record);

        public void DeleteExpense(Expense record);

        public Income? FindIncome(Guid id);

        public Expense? FindExpense(Guid id);

        public IReadOnlyList<Expense> ReturnAllExpense();

        public IReadOnlyList<Income> ReturnAllIncome();
    }
}
