using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ExpenseTracker.Models;
using ExpenseTracker.Models.Enums;
using ExpenseTracker.Repository;

namespace ExpenseTracker.Service
{
    /// <summary>
    /// Implements financial operations by interacting with the repositories.
    /// </summary>
    public class FinancialRecordService : IFinancialRecordService
    {
        private readonly ITransactionRepository _repository;

        private readonly BalanceTracker _balanceTracker;

        /// <summary>
        /// Initializes a new instance of the <see cref="FinancialRecordService"/> class.
        /// </summary>
        /// <param name="repository">Initializes Repo Object</param>
        public FinancialRecordService(ITransactionRepository repository)
        {
            this._repository = repository;
            this._balanceTracker = this._repository.GetSummaryDetails();
        }

        /// <summary>
        /// Business Logic to Save Income to Repo
        /// </summary>
        /// <param name="incomeRecord">Income Record to be added to repo</param>
        public void SaveIncome(Income incomeRecord)
        {
            this._repository.AddIncome(incomeRecord);
            this.NotifyAdd(incomeRecord);
        }

        /// <summary>
        /// Business Logic to Save Expense to Repo
        /// </summary>
        /// <param name="expenseRecord">Expense Record to be added to repo</param>
        public void SaveExpense(Expense expenseRecord)
        {
            this._repository.AddExpense(expenseRecord);
            this.NotifyAdd(expenseRecord);
        }

        /// <summary>
        /// Business Logic to Modify Income in Repo
        /// </summary>
        /// <param name="index">Index of record to be updated</param>
        /// <param name="updatedIncome">New income record that has the updated details</param>
        /// <returns>Result Object that has Success/Failure Message</returns>
        public Result ModifyIncome(int index, Income updatedIncome)
        {
            var indexResult = this.CheckValidIndexForIncome(index);
            if (!indexResult.IsSuccess)
            {
                return indexResult;
            }

            var incomeRepo = this.GetAllIncome();
            var existingRecord = incomeRepo[index];
            decimal existingAmount = existingRecord.Amount;
            this._repository.UpdateIncome(existingRecord.TransactionID, updatedIncome);
            this.NotifyUpdate(updatedIncome, existingAmount);
            return new Result(true, "Successfully Updated the Income Record");
        }

        /// <summary>
        /// Business Logic to Modify Expense in Repo
        /// </summary>
        /// <param name="index">Index of record to be updated</param>
        /// <param name="updatedExpense">New income record that has the updated details</param>
        /// <returns>Result Object that has Success/Failure Message</returns>
        public Result ModifyExpense(int index, Expense updatedExpense)
        {
            var indexResult = this.CheckValidIndexForExpense(index);
            if (!indexResult.IsSuccess)
            {
                return indexResult;
            }

            var expenseRepo = this.GetAllExpense();
            var existingRecord = expenseRepo[index];
            decimal existingAmount = existingRecord.Amount;
            this._repository.UpdateExpense(existingRecord.TransactionID, updatedExpense);
            this.NotifyUpdate(updatedExpense, existingAmount);
            return new Result(true, "Successfully Updated the Expense Record");
        }

        /// <summary>
        /// Delete Income Record from repo
        /// </summary>
        /// <param name="index">Index of record to be deleted</param>
        /// <returns>Result Object that has Success/Failure Message</returns>
        public Result RemoveIncome(int index)
        {
            var indexResult = this.CheckValidIndexForIncome(index);
            if (!indexResult.IsSuccess)
            {
                return indexResult;
            }

            var incomeRepo = this.GetAllIncome();
            var record = incomeRepo[index];
            this._repository.DeleteIncome(record.TransactionID);
            this.NotifyDelete(record);
            return new Result(true, "Successfully Deleted the Income Record");
        }

        /// <summary>
        /// Delete Expense Record from repo
        /// </summary>
        /// <param name="index">Index of record to be deleted</param>
        /// <returns>Result Object that has Success/Failure Message</returns>
        public Result RemoveExpense(int index)
        {
            var indexResult = this.CheckValidIndexForExpense(index);
            if (!indexResult.IsSuccess)
            {
                return indexResult;
            }

            var expenseRepo = this.GetAllExpense();
            var record = expenseRepo[index];
            this._repository.DeleteExpense(record.TransactionID);
            this.NotifyDelete(record);
            return new Result(true, "Successfully Deleted the Expense Record");
        }

        /// <summary>
        /// Returns all income records from repo
        /// </summary>
        /// <returns>List of Income records</returns>
        public IReadOnlyList<Income> GetAllIncome() => this._repository.ReturnAllIncome();

        /// <summary>
        /// Returns all expense records from repo
        /// </summary>
        /// <returns>List of expense records</returns>
        public IReadOnlyList<Expense> GetAllExpense() => this._repository.ReturnAllExpense();

        /// <summary>
        /// Checks if incomeRepo has any active income records
        /// </summary>
        /// <returns>true if incomeRepo has income records, otherwise false</returns>
        public bool HasActiveIncome() => this._repository.ReturnAllIncome().Any();

        /// <summary>
        /// Checks if expenseRepo has any active expense records
        /// </summary>
        /// <returns>true if expenseRepo has expense records, otherwise false</returns>
        public bool HasActiveExpense() => this._repository.ReturnAllExpense().Any();

        /// <summary>
        /// Writes the in-memory list to the file and closes the application
        /// </summary>
        public void CloseProgram()
        {
            this._repository.SaveInMemory(this._balanceTracker);
        }

        /// <summary>
        /// Returns Summary Detaisl (TotalIncome, TotalExpense, BalanceAmount)
        /// </summary>
        /// <returns>BalanceTracker Object</returns>
        public BalanceTracker ReturnSummaryDetails()
        {
            return this._repository.GetSummaryDetails();
        }

        /// <summary>
        /// Returns the income Financial Records Grouped by Year-wise and then Month-wise
        /// </summary>
        /// <returns>List of grouped income Financial Records</returns>
        public IEnumerable<MonthlyFinancialReport> ReturnMonthWiseIncomeReport()
        {
            var incomerecords = this.GetAllIncome();
            return incomerecords.GroupBy(date => new { date.Date.Year, date.Date.Month }).Select(groupedRes => new MonthlyFinancialReport
            {
                Year = groupedRes.Key.Year,
                Month = groupedRes.Key.Month,
                TotalAmount = groupedRes.Sum(records => records.Amount),
                MonthWiseIncomeReport = groupedRes.OrderBy(records => records.Date).ToList(),
            })
            .OrderByDescending(r => r.Year).ThenBy(r => r.Month);
        }

        /// <summary>
        /// Returns the expense Financial Records Grouped by Year-wise and then Month-wise
        /// </summary>
        /// <returns>List of grouped expense Financial Records</returns>
        public IEnumerable<MonthlyFinancialReport> ReturnMonthWiseExpenseReport()
        {
            var expenserecords = this.GetAllExpense();
            return expenserecords.GroupBy(date => new { date.Date.Year, date.Date.Month }).Select(groupedRes => new MonthlyFinancialReport
            {
                Year = groupedRes.Key.Year,
                Month = groupedRes.Key.Month,
                TotalAmount = groupedRes.Sum(records => records.Amount),
                MonthWiseExpenseReport = groupedRes.OrderBy(records => records.Date).ToList(),
            })
            .OrderByDescending(r => r.Year).ThenBy(r => r.Month);
        }

        /// <summary>
        /// EventHandler method matching EventArgs(Built-in Delegate) that handles which Transaction(Income/Expense) has to be executed based on the record
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">FinancialEventArgs object</param>
        public void HandleFinancialRecordChange(object sender, FinancialEventArgs e)
        {
            if (e.CurrentRecord is Income)
            {
                this.HandleIncomeTransaction(e.Action, e.CurrentRecord, e.OldAmount);
            }
            else if (e.CurrentRecord is Expense)
            {
                this.HandleExpenseTransaction(e.Action, e.CurrentRecord, e.OldAmount);
            }

            this._repository.UpdateSummary(this._balanceTracker);
        }

        /// <summary>
        /// Subscribed to AppDomain.CurrentDomain.ProcessExit - Runs when app is terminated without proper exit and closed using [X]
        /// </summary>
        /// <param name="sender">Sender Object - Source of event</param>
        /// <param name="e">EventArgs object</param>
        public void OnProcessExit(object sender, EventArgs e)
        {
            this.CloseProgram();
        }

        private void HandleIncomeTransaction(TransactionAction action, FinancialRecord currentRecord, decimal oldAmount)
        {
            switch (action)
            {
                case TransactionAction.Added:
                    this._balanceTracker.TotalIncome += currentRecord.Amount;
                    break;

                case TransactionAction.Updated:
                    this._balanceTracker.TotalIncome = this._balanceTracker.TotalIncome - oldAmount + currentRecord.Amount;
                    break;

                case TransactionAction.Deleted:
                    this._balanceTracker.TotalIncome -= currentRecord.Amount;
                    break;
            }
        }

        private void HandleExpenseTransaction(TransactionAction action, FinancialRecord currentRecord, decimal oldAmount)
        {
            switch (action)
            {
                case TransactionAction.Added:
                    this._balanceTracker.TotalExpense += currentRecord.Amount;
                    break;

                case TransactionAction.Updated:
                    this._balanceTracker.TotalExpense = this._balanceTracker.TotalExpense - oldAmount + currentRecord.Amount;
                    break;

                case TransactionAction.Deleted:
                    this._balanceTracker.TotalExpense -= currentRecord.Amount;
                    break;
            }
        }

        private Result CheckValidIndexForExpense(int index)
        {
            if (index >= this._repository.ReturnAllExpense().Count)
            {
                return new Result(false, "Index Out Of Range");
            }

            return new Result(true, "Valid Index");
        }

        private Result CheckValidIndexForIncome(int index)
        {
            if (index >= this._repository.ReturnAllIncome().Count)
            {
                return new Result(false, "Index Out Of Range");
            }

            return new Result(true, "Valid Index");
        }

        private void NotifyAdd(FinancialRecord record)
        {
            FinancialEventPublisher.Notify(this, new FinancialEventArgs(TransactionAction.Added, record));
        }

        private void NotifyUpdate(FinancialRecord existingRecord, decimal existingAmount)
        {
            FinancialEventPublisher.Notify(this, new FinancialEventArgs(TransactionAction.Updated, existingRecord, existingAmount));
        }

        private void NotifyDelete(FinancialRecord record)
        {
            FinancialEventPublisher.Notify(this, new FinancialEventArgs(TransactionAction.Deleted, record));
        }
    }
}
