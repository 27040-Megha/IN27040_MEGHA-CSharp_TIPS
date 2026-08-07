using System;
using System.Collections.Generic;
using System.Reflection;
using ExpenseTracker.Models;
using ExpenseTracker.Repository;

namespace ExpenseTracker.Service
{
    public class FinancialRecordService : IFinancialRecordService
    {
        private readonly IFinancialRepository _repository;

        public FinancialRecordService(IFinancialRepository repository)
        {
            this._repository = repository;
        }

        public void AddIncome(decimal amount, DateOnly date, string description, string source)
        {
            var income = new Income(amount, date, description, source);
            this._repository.AddIncome(income);
            this.NotifyAdd(income);
        }

        public void AddExpense(decimal amount, DateOnly date, string description, string category)
        {
            var expense = new Expense(amount, date, description, category);
            this._repository.AddExpense(expense);
            this.NotifyAdd(expense);
        }

        public Result UpdateIncome(int index, decimal amount, DateOnly date, string description, string source)
        {
            var indexResult = this.CheckValidIndexForIncome(index);
            if (!indexResult.IsSuccess)
            {
                return indexResult;
            }

            var incomeRepo = this.GetAllIncome();
            var existingRecord = this.GetIncomeById(incomeRepo[index].TransactionID);
            decimal existingAmount = existingRecord.Amount;
            var updatedIncome = new Income(amount, date, description, source);
            this._repository.UpdateIncomeInRepo(existingRecord, updatedIncome);
            this.NotifyUpdate(existingRecord, existingAmount);
            return new Result(true, "Successfully Updated the Income Record");
        }

        public Result UpdateExpense(int index, decimal amount, DateOnly date, string description, string category)
        {
            var indexResult = this.CheckValidIndexForExpense(index);
            if (!indexResult.IsSuccess)
            {
                return indexResult;
            }

            var expenseRepo = this.GetAllExpense();
            var existingRecord = this.GetExpenseById(expenseRepo[index].TransactionID);
            decimal existingAmount = existingRecord.Amount;
            var updatedExpense = new Expense(amount, date, description, category);
            this._repository.UpdateExpenseInRepo(existingRecord, updatedExpense);
            this.NotifyUpdate(existingRecord, existingAmount);
            return new Result(true, "Successfully Updated the Expense Record");
        }

        public Result DeleteIncomeRecord(int index)
        {
            var indexResult = this.CheckValidIndexForIncome(index);
            if (!indexResult.IsSuccess)
            {
                return indexResult;
            }

            var incomeRepo = this.GetAllIncome();
            var record = this._repository.GetIncomeById(incomeRepo[index].TransactionID);
            this._repository.DeleteIncomeInRepo(record);
            this.NotifyDelete(record);
            return new Result(true, "Successfully Deleted the Income Record");
        }

        public Result DeleteExpenseRecord(int index)
        {
            var indexResult = this.CheckValidIndexForExpense(index);
            if (!indexResult.IsSuccess)
            {
                return indexResult;
            }

            var expenseRepo = this.GetAllExpense();
            var record = this._repository.GetExpenseById(expenseRepo[index].TransactionID);
            this._repository.DeleteExpenseInRepo(record);
            this.NotifyDelete(record);
            return new Result(true, "Successfully Deleted the Expense Record");
        }

        public Income GetIncomeById(Guid id) => _repository.GetIncomeById(id);

        public Expense GetExpenseById(Guid id) => _repository.GetExpenseById(id);

        public IReadOnlyList<Income> GetAllIncome() => _repository.GetAllIncome();

        public IReadOnlyList<Expense> GetAllExpense() => _repository.GetAllExpense();

        public int GetIncomeCount() => this._repository.GetAllIncome().Count;

        public int GetExpenseCount() => this._repository.GetAllExpense().Count;

        private Result CheckValidIndexForExpense(int index)
        {
            if (index >= this._repository.GetAllExpense().Count)
            {
                return new Result(false, "Index Out Of Range");
            }

            return new Result(true, "Valid Index");
        }

        private Result CheckValidIndexForIncome(int index)
        {
            if (index >= this._repository.GetAllIncome().Count)
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
