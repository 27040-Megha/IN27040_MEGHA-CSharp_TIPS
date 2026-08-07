using System;
using System.Collections.Generic;
using System.Linq;
using ExpenseTracker.Models;

namespace ExpenseTracker.Repository
{
    /// <summary>
    /// Repository implementation that stores records
    /// </summary>
    public class FinancialRepository : IFinancialRepository
    {
        private readonly List<Income> _incomeRepo;
        private readonly List<Expense> _expenseRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="FinancialRepository"/> class.
        /// </summary>
        public FinancialRepository()
        {
            this._expenseRepo = new List<Expense>();
            this._incomeRepo = new List<Income>();
        }

        /// <summary>
        /// Adds Income record to income repo
        /// </summary>
        /// <param name="record">Income record</param>
        public void AddIncome(Income record)
        {
            this._incomeRepo.Add(record);
        }

        /// <summary>
        /// Adds Expense record to repo
        /// </summary>
        /// <param name="record">Expensee record</param>
        public void AddExpense(Expense record)
        {
            this._expenseRepo.Add(record);
        }

        /// <summary>
        /// Updates the existing income record in repo
        /// </summary>
        /// <param name="oldRecord">Old Record to be updated</param>
        /// <param name="newRecord">New record</param>
        public void UpdateIncome(Income oldRecord, Income newRecord)
        {
            oldRecord.Amount = newRecord.Amount;
            oldRecord.Date = newRecord.Date;
            oldRecord.Description = newRecord.Description;
            oldRecord.Source = newRecord.Source;
        }

        /// <summary>
        /// Updates the existing expense record in repo
        /// </summary>
        /// <param name="oldRecord">Old Record to be updated</param>
        /// <param name="newRecord">New record</param>
        public void UpdateExpense(Expense oldRecord, Expense newRecord)
        {
            oldRecord.Amount = newRecord.Amount;
            oldRecord.Date = newRecord.Date;
            oldRecord.Description = newRecord.Description;
            oldRecord.Category = newRecord.Category;
        }

        /// <summary>
        /// Deletes Income record from income repo
        /// </summary>
        /// <param name="record">Income record</param>
        public void DeleteIncome(Income record)
        {
            this._incomeRepo.Remove(record);
        }

        /// <summary>
        /// Deletes Expense record from income repo
        /// </summary>
        /// <param name="record">Expense record</param>
        public void DeleteExpense(Expense record)
        {
            this._expenseRepo.Remove(record);
        }

        /// <summary>
        /// Finds and returns an income record
        /// </summary>
        /// <param name="id">Unique id of record to be found</param>
        /// <returns>Income record found</returns>
        public Income FindIncome(Guid id)
        {
            return this._incomeRepo.FirstOrDefault(x => x.TransactionID == id);
        }

        /// <summary>
        /// Finds and returns an expense record
        /// </summary>
        /// <param name="id">Unique id of record to be found</param>
        /// <returns>Expense record found</returns>
        public Expense FindExpense(Guid id)
        {
            return this._expenseRepo.FirstOrDefault(x => x.TransactionID == id);
        }

        /// <summary>
        /// Returns Expense repo
        /// </summary>
        /// <returns>List of Expense repo</returns>
        public IReadOnlyList<Expense> ReturnAllExpense() => this._expenseRepo;

        /// <summary>
        /// Returns Income repo
        /// </summary>
        /// <returns>List of Income repo</returns>
        public IReadOnlyList<Income> ReturnAllIncome() => this._incomeRepo;
    }
}
