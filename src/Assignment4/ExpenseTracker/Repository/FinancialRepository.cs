using System;
using System.Collections.Generic;
using System.Linq;
using ExpenseTracker.Models;

namespace ExpenseTracker.Repository
{
    public class FinancialRepository : IFinancialRepository
    {
        private readonly List<Income> _incomeRepo;
        private readonly List<Expense> _expenseRepo;

        public FinancialRepository()
        {
            this._expenseRepo = new List<Expense>();
            this._incomeRepo = new List<Income>();
        }

        public void AddIncome(Income record)
        {
            this._incomeRepo.Add(record);
        }

        public void AddExpense(Expense record)
        {
            this._expenseRepo.Add(record);
        }

        public void UpdateIncome(Income oldRecord, Income newRecord)
        {
            oldRecord.Amount = newRecord.Amount;
            oldRecord.Date = newRecord.Date;
            oldRecord.Description = newRecord.Description;
            oldRecord.Source = newRecord.Source;
        }

        public void UpdateExpense(Expense oldRecord, Expense newRecord)
        {
            oldRecord.Amount = newRecord.Amount;
            oldRecord.Date = newRecord.Date;
            oldRecord.Description = newRecord.Description;
            oldRecord.Category = newRecord.Category;
        }

        public void DeleteIncome(Income record)
        {
            this._incomeRepo.Remove(record);
        }

        public void DeleteExpense(Expense record)
        {
            this._expenseRepo.Remove(record);
        }

        public Income? FindIncome(Guid id)
        {
            return this._incomeRepo.FirstOrDefault(x => x.TransactionID == id);
        }

        public Expense? FindExpense(Guid id)
        {
            return this._expenseRepo.FirstOrDefault(x => x.TransactionID == id);
        }

        public IReadOnlyList<Expense> ReturnAllExpense() => this._expenseRepo;

        public IReadOnlyList<Income> ReturnAllIncome() => this._incomeRepo;
    }
}
