using System;
using System.Collections.Generic;
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

        public void SaveIncome(decimal amount, DateOnly date, string description, string source)
        {
            var income = new Income(amount, date, description, source);
            this._repository.AddIncome(income);
            this.NotifyAdd(income);
        }

        public void SaveExpense(decimal amount, DateOnly date, string description, string category)
        {
            var expense = new Expense(amount, date, description, category);
            this._repository.AddExpense(expense);
            this.NotifyAdd(expense);
        }

        public Result ModifyIncome(int index, decimal amount, DateOnly date, string description, string source)
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
            this._repository.UpdateIncome(existingRecord, updatedIncome);
            this.NotifyUpdate(updatedIncome, existingAmount);
            return new Result(true, "Successfully Updated the Income Record");
        }

        public Result ModifyExpense(int index, decimal amount, DateOnly date, string description, string category)
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
            this._repository.UpdateExpense(existingRecord, updatedExpense);
            this.NotifyUpdate(updatedExpense, existingAmount);
            return new Result(true, "Successfully Updated the Expense Record");
        }

        public Result RemoveIncome(int index)
        {
            var indexResult = this.CheckValidIndexForIncome(index);
            if (!indexResult.IsSuccess)
            {
                return indexResult;
            }

            var incomeRepo = this.GetAllIncome();
            var record = this._repository.FindIncome(incomeRepo[index].TransactionID);
            this._repository.DeleteIncome(record);
            this.NotifyDelete(record);
            return new Result(true, "Successfully Deleted the Income Record");
        }

        public Result RemoveExpense(int index)
        {
            var indexResult = this.CheckValidIndexForExpense(index);
            if (!indexResult.IsSuccess)
            {
                return indexResult;
            }

            var expenseRepo = this.GetAllExpense();
            var record = this._repository.FindExpense(expenseRepo[index].TransactionID);
            this._repository.DeleteExpense(record);
            this.NotifyDelete(record);
            return new Result(true, "Successfully Deleted the Expense Record");
        }

        public Income GetIncomeById(Guid id) => this._repository.FindIncome(id);

        public Expense GetExpenseById(Guid id) => this._repository.FindExpense(id);

        public IReadOnlyList<Income> GetAllIncome() => this._repository.ReturnAllIncome();

        public IReadOnlyList<Expense> GetAllExpense() => this._repository.ReturnAllExpense();

        public int GetIncomeCount() => this._repository.ReturnAllIncome().Count;

        public int GetExpenseCount() => this._repository.ReturnAllExpense().Count;

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
