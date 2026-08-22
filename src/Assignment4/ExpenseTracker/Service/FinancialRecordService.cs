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
        private readonly IFinancialRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="FinancialRecordService"/> class.
        /// </summary>
        /// <param name="repository">Initializes Repo Object</param>
        public FinancialRecordService(IFinancialRepository repository)
        {
            this._repository = repository;
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
