using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            _incomeRepo.Add(record);
        }

        public void AddExpense(Expense record)
        {
            _expenseRepo.Add(record);
        }

        public void UpdateIncomeInRepo(Income oldRecord, Income newRecord)
        {
            oldRecord.Amount = newRecord.Amount;
            oldRecord.Date = newRecord.Date;
            oldRecord.Description = newRecord.Description;
            oldRecord.Source = newRecord.Source;
        }

        public void UpdateExpenseInRepo(Expense oldRecord, Expense newRecord)
        {
            oldRecord.Amount = newRecord.Amount;
            oldRecord.Date = newRecord.Date;
            oldRecord.Description = newRecord.Description;
            oldRecord.Category = newRecord.Category;
        }

        public void DeleteIncomeInRepo(Income record)
        {
            _incomeRepo.Remove(record);
        }

        public void DeleteExpenseInRepo(Expense record)
        {
            _expenseRepo.Remove(record);
        }

        public Income? GetIncomeById(Guid id)
        {
            return this._incomeRepo.FirstOrDefault(x => x.TransactionID == id);
        }

        public Expense? GetExpenseById(Guid id)
        {
            return this._expenseRepo.FirstOrDefault(x => x.TransactionID == id);
        }

        public IReadOnlyList<Expense> GetAllExpense() => this._expenseRepo;

        public IReadOnlyList<Income> GetAllIncome() => this._incomeRepo;
    }
}
