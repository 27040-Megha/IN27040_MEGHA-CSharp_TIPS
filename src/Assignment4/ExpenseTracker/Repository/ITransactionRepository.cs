using System;
using System.Collections.Generic;
using ExpenseTracker.Models;

namespace ExpenseTracker.Repository
{
    /// <summary>
    /// Interface defining CRUD operations for financial records
    /// </summary>
    public interface ITransactionRepository
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
        /// <param name="indexToUpdate">Index of the object to be modified</param>
        /// <param name="newRecord">New record</param>
        public void UpdateIncome(int indexToUpdate, Income newRecord);

        /// <summary>
        /// Updates the existing expense record in repo
        /// </summary>
        /// <param name="indexToUpdate">Index of the object to be modified</param>
        /// <param name="newRecord">New record</param>
        public void UpdateExpense(int indexToUpdate, Expense newRecord);

        /// <summary>
        /// Deletes Income record from income repo
        /// </summary>
        /// <param name="transactionID">Transaction ID of income record to be deleted</param>
        public void DeleteIncome(Guid transactionID);

        /// <summary>
        /// Deletes Expense record from income repo
        /// </summary>
        /// <param name="transactionID">Transaction ID of expense record to be deleted</param>
        public void DeleteExpense(Guid transactionID);

        /// <summary>
        /// Finds and returns an income record
        /// </summary>
        /// <param name="transactionID">Unique id of record to be found</param>
        /// <returns>Income record found</returns>
        public Income FindIncome(Guid transactionID);

        /// <summary>
        /// Finds and returns an expense record
        /// </summary>
        /// <param name="transactionID">Unique id of record to be found</param>
        /// <returns>Expense record found</returns>
        public Expense FindExpense(Guid transactionID);

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

        /// <summary>
        /// return summary details from the summary file
        /// </summary>
        /// <returns>BalanceTracker object</returns>
        public BalanceTracker GetSummaryDetails();

        /// <summary>
        /// Updates the BalanceTracker summary details
        /// </summary>
        /// <param name="balanceTracker">BalanceTracker object</param>
        public void UpdateSummary(BalanceTracker balanceTracker);

        /// <summary>
        /// Write the in-memory list back to file before closing the application
        /// </summary>
        /// <param name="balanceTracker">BalanceTracker object</param>
        public void SaveInMemory(BalanceTracker balanceTracker);
    }
}
