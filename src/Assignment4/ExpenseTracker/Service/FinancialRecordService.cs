using System;
using System.Collections.Generic;
using ExpenseTracker.Models;
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
        /// <param name="amount">Income Amount</param>
        /// <param name="date">Date of transaction</param>
        /// <param name="description">Description of transaction</param>
        /// <param name="source">Source of Income</param>
        public void SaveIncome(decimal amount, DateTime date, string description, string source)
        {
            var income = new Income(Guid.NewGuid(), amount, date, description, source);
            this._repository.AddIncome(income);
            this.NotifyAdd(income);
        }

        /// <summary>
        /// Business Logic to Save Expense to Repo
        /// </summary>
        /// <param name="amount">Expense Amount</param>
        /// <param name="date">Date of transaction</param>
        /// <param name="description">Description of transaction</param>
        /// <param name="category">Category of Expense</param>
        public void SaveExpense(decimal amount, DateTime date, string description, string category)
        {
            var expense = new Expense(Guid.NewGuid(), amount, date, description, category);
            this._repository.AddExpense(expense);
            this.NotifyAdd(expense);
        }

        /// <summary>
        /// Business Logic to Modify Income in Repo
        /// </summary>
        /// <param name="index">Index of record to be updated</param>
        /// <param name="amount">Income Amount</param>
        /// <param name="date">Date of transaction</param>
        /// <param name="description">Description of transaction</param>
        /// <param name="source">Source of Income</param>
        /// <returns>Result Object that has Success/Failure Message</returns>
        public Result ModifyIncome(int index, decimal amount, DateTime date, string description, string source)
        {
            var indexResult = this.CheckValidIndexForIncome(index);
            if (!indexResult.IsSuccess)
            {
                return indexResult;
            }

            var incomeRepo = this.GetAllIncome();
            var existingRecord = this.GetIncomeById(incomeRepo[index].TransactionID);
            decimal existingAmount = existingRecord.Amount;
            var updatedIncome = new Income(existingRecord.TransactionID, amount, date, description, source);
            this._repository.UpdateIncome(existingRecord.TransactionID, updatedIncome);
            this.NotifyUpdate(updatedIncome, existingAmount);
            return new Result(true, "Successfully Updated the Income Record");
        }

        /// <summary>
        /// Business Logic to Modify Expense in Repo
        /// </summary>
        /// <param name="index">Index of record to be updated</param>
        /// <param name="amount">Expense Amount</param>
        /// <param name="date">Date of transaction</param>
        /// <param name="description">Description of transaction</param>
        /// <param name="category">Category of Expense</param>
        /// <returns>Result Object that has Success/Failure Message</returns>
        public Result ModifyExpense(int index, decimal amount, DateTime date, string description, string category)
        {
            var indexResult = this.CheckValidIndexForExpense(index);
            if (!indexResult.IsSuccess)
            {
                return indexResult;
            }

            var expenseRepo = this.GetAllExpense();
            var existingRecord = this.GetExpenseById(expenseRepo[index].TransactionID);
            decimal existingAmount = existingRecord.Amount;
            var updatedExpense = new Expense(existingRecord.TransactionID, amount, date, description, category);
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
            var record = this._repository.FindIncome(incomeRepo[index].TransactionID);
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
            var record = this._repository.FindExpense(expenseRepo[index].TransactionID);
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
        /// Return Count of records in incomeRepo
        /// </summary>
        /// <returns>Count of records in incomeRepo</returns>
        public int GetIncomeCount() => this._repository.ReturnAllIncome().Count;

        /// <summary>
        /// Return Count of records in expenseRepo
        /// </summary>
        /// <returns>Count of records in expenseRepo</returns>
        public int GetExpenseCount() => this._repository.ReturnAllExpense().Count;

        private Income GetIncomeById(Guid id) => this._repository.FindIncome(id);

        private Expense GetExpenseById(Guid id) => this._repository.FindExpense(id);

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

        private void NotifyAdd(IFinancialRecord record)
        {
            FinancialEventPublisher.Notify(this, new FinancialEventArgs(TransactionAction.Added, record));
        }

        private void NotifyUpdate(IFinancialRecord existingRecord, decimal existingAmount)
        {
            FinancialEventPublisher.Notify(this, new FinancialEventArgs(TransactionAction.Updated, existingRecord, existingAmount));
        }

        private void NotifyDelete(IFinancialRecord record)
        {
            FinancialEventPublisher.Notify(this, new FinancialEventArgs(TransactionAction.Deleted, record));
        }
    }
}
