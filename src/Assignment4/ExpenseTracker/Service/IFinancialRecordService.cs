using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Models;

namespace ExpenseTracker.Service
{
    /// <summary>
    /// Defines business operations for income and expense management.
    /// </summary>
    public interface IFinancialRecordService
    {
        /// <summary>
        /// Business Logic to Save Income to Repo
        /// </summary>
        /// <param name="amount">Income Amount</param>
        /// <param name="date">Date of transaction</param>
        /// <param name="description">Description of transaction</param>
        /// <param name="source">Source of Income</param>
        public void SaveIncome(decimal amount, DateTime date, string description, string source);

        /// <summary>
        /// Business Logic to Save Expense to Repo
        /// </summary>
        /// <param name="amount">Expense Amount</param>
        /// <param name="date">Date of transaction</param>
        /// <param name="description">Description of transaction</param>
        /// <param name="category">Category of Expense</param>
        public void SaveExpense(decimal amount, DateTime date, string description, string category);

        /// <summary>
        /// Business Logic to Modify Income in Repo
        /// </summary>
        /// <param name="index">Index of record to be updated</param>
        /// <param name="amount">Income Amount</param>
        /// <param name="date">Date of transaction</param>
        /// <param name="description">Description of transaction</param>
        /// <param name="source">Source of Income</param>
        /// <returns>Result Object that has Success/Failure Message</returns>
        public Result ModifyIncome(int index, decimal amount, DateTime date, string description, string source);

        /// <summary>
        /// Business Logic to Modify Expense in Repo
        /// </summary>
        /// <param name="index">Index of record to be updated</param>
        /// <param name="amount">Expense Amount</param>
        /// <param name="date">Date of transaction</param>
        /// <param name="description">Description of transaction</param>
        /// <param name="category">Category of Expense</param>
        /// <returns>Result Object that has Success/Failure Message</returns>
        public Result ModifyExpense(int index, decimal amount, DateTime date, string description, string category);

        /// <summary>
        /// Delete Income Record from repo
        /// </summary>
        /// <param name="index">Index of record to be deleted</param>
        /// <returns>Result Object that has Success/Failure Message</returns>
        public Result RemoveIncome(int index);

        /// <summary>
        /// Delete Expense Record from repo
        /// </summary>
        /// <param name="index">Index of record to be deleted</param>
        /// <returns>Result Object that has Success/Failure Message</returns>
        public Result RemoveExpense(int index);

        /// <summary>
        /// Return Count of records in incomeRepo
        /// </summary>
        /// <returns>Count of records in incomeRepo</returns>
        public int GetIncomeCount();

        /// <summary>
        /// Return Count of records in expenseRepo
        /// </summary>
        /// <returns>Count of records in expenseRepo</returns>
        public int GetExpenseCount();

        /// <summary>
        /// Returns all income records from repo
        /// </summary>
        /// <returns>List of Income records</returns>
        public IReadOnlyList<Income> GetAllIncome();

        /// <summary>
        /// Returns all expense records from repo
        /// </summary>
        /// <returns>List of expense records</returns>
        public IReadOnlyList<Expense> GetAllExpense();
    }
}
