using System;
using System.Collections.Generic;
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
        /// <param name="incomeRecord">Income Record to be added to repo</param>
        public void SaveIncome(Income incomeRecord);

        /// <summary>
        /// Business Logic to Save Expense to Repo
        /// </summary>
        /// <param name="expenseRecord">Expense Record to be added to repo</param>
        public void SaveExpense(Expense expenseRecord);

        /// <summary>
        /// Business Logic to Modify Income in Repo
        /// </summary>
        /// <param name="index">Index of record to be updated</param>
        /// <param name="updatedIncome">New income record that has the updated details</param>
        /// <returns>Result Object that has Success/Failure Message</returns>
        public Result ModifyIncome(int index, Income updatedIncome);

        /// <summary>
        /// Business Logic to Modify Expense in Repo
        /// </summary>
        /// <param name="index">Index of record to be updated</param>
        /// <param name="updatedExpense">New income record that has the updated details</param>
        /// <returns>Result Object that has Success/Failure Message</returns>
        public Result ModifyExpense(int index, Expense updatedExpense);

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
        /// Checks if incomeRepo has any active income records
        /// </summary>
        /// <returns>true if incomeRepo has income records, otherwise false</returns>
        public bool HasActiveIncome();

        /// <summary>
        /// Checks if expenseRepo has any active expense records
        /// </summary>
        /// <returns>true if expenseRepo has expense records, otherwise false</returns>
        public bool HasActiveExpense();

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

        /// <summary>
        /// Returns summary details
        /// </summary>
        /// <returns>BalanceTracker object</returns>
        public BalanceTracker ReturnSummaryDetails();

        /// <summary>
        /// Calls repo method to write to file before closing the Application
        /// </summary>
        public void CloseProgram();

        /// <summary>
        /// Returns the income Financial Records Grouped by Year-wise and then Month-wise
        /// </summary>
        /// <returns>List of grouped income Financial Records</returns>
        public IEnumerable<MonthlyFinancialReport> ReturnMonthWiseIncomeReport();

        /// <summary>
        /// Returns the expense Financial Records Grouped by Year-wise and then Month-wise
        /// </summary>
        /// <returns>List of grouped expense Financial Records</returns>
        public IEnumerable<MonthlyFinancialReport> ReturnMonthWiseExpenseReport();
    }
}
