using System;
using System.Collections.Generic;
using ExpenseTracker.Models;

namespace ExpenseTracker.Repository
{
    /// <summary>
    /// Interface defining CRUD operations for financial records
    /// </summary>
    public interface IFinancialRepository
    {
        /// <summary>
        /// Adds Income record to income repo
        /// </summary>
        /// <param name="record">Income record</param>
        public void AddIncome(Income record);

        /// <summary>
        /// Adds Expense record to repo
        /// </summary>
        /// <param name="record">Expensee record</param>
        public void AddExpense(Expense record);

        /// <summary>
        /// Updates the existing income record in repo
        /// </summary>
        /// <param name="oldRecord">Old Record to be updated</param>
        /// <param name="newRecord">New record</param>
        public void UpdateIncome(Income oldRecord, Income newRecord);

        /// <summary>
        /// Updates the existing expense record in repo
        /// </summary>
        /// <param name="oldRecord">Old Record to be updated</param>
        /// <param name="newRecord">New record</param>
        public void UpdateExpense(Expense oldRecord, Expense newRecord);

        /// <summary>
        /// Deletes Income record from income repo
        /// </summary>
        /// <param name="record">Income record</param>
        public void DeleteIncome(Income record);

        /// <summary>
        /// Deletes Expense record from income repo
        /// </summary>
        /// <param name="record">Expense record</param>
        public void DeleteExpense(Expense record);

        /// <summary>
        /// Finds and returns an income record
        /// </summary>
        /// <param name="id">Unique id of record to be found</param>
        /// <returns>Income record found</returns>
        public Income FindIncome(Guid id);

        /// <summary>
        /// Finds and returns an expense record
        /// </summary>
        /// <param name="id">Unique id of record to be found</param>
        /// <returns>Expense record found</returns>
        public Expense FindExpense(Guid id);

        /// <summary>
        /// Returns Expense repo
        /// </summary>
        /// <returns>List of Expense repo</returns>
        public IReadOnlyList<Expense> ReturnAllExpense();

        /// <summary>
        /// Returns Income repo
        /// </summary>
        /// <returns>List of Income repo</returns>
        public IReadOnlyList<Income> ReturnAllIncome();
    }
}
