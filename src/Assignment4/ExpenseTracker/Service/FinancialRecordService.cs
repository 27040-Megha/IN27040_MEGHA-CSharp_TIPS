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
            _repository = repository;
        }

        public void AddIncome(decimal amount, DateOnly date, string description, string source)
        {
            var income = new Income(amount, date, description, source);
            _repository.AddIncome(income);
            FinancialEventPublisher.Notify(this, new FinancialEventArgs(TransactionAction.Added, income));
        }

        public void AddExpense(decimal amount, DateOnly date, string description, string category)
        {
            var expense = new Expense(amount, date, description, category);
            _repository.AddExpense(expense);
            FinancialEventPublisher.Notify(this, new FinancialEventArgs(TransactionAction.Added, expense));
        }

        public bool UpdateIncome(Guid id, decimal amount, DateOnly date, string description, string source)
        {
            var existing = _repository.GetIncomeById(id);
            if (existing is null)
            {
                return false;
            }

            decimal existingAmount = existing.Amount;
            var updatedIncome = new Income(amount, date, description, source);
            _repository.UpdateIncomeInRepo(existing, updatedIncome);
            FinancialEventPublisher.Notify(this, new FinancialEventArgs(TransactionAction.Updated, existing, existingAmount));
            return true;
        }

        public bool UpdateExpense(Guid id, decimal amount, DateOnly date, string description, string category)
        {
            var existing = _repository.GetExpenseById(id);
            if (existing is null)
            {
                return false;
            }

            decimal existingAmount = existing.Amount;
            var updatedExpense = new Expense(amount, date, description, category);
            _repository.UpdateExpenseInRepo(existing, updatedExpense);
            FinancialEventPublisher.Notify(this, new FinancialEventArgs(TransactionAction.Updated, existing, existingAmount));
            return true;
        }

        public bool DeleteIncomeRecord(Guid id)
        {
            var record = _repository.GetIncomeById(id);
            if (record == null)
            {
                return false;
            }

            this._repository.DeleteIncomeInRepo(record);
            FinancialEventPublisher.Notify(this, new FinancialEventArgs(TransactionAction.Deleted, record));
            return true;
        }

        public bool DeleteExpenseRecord(Guid id)
        {
            var record = _repository.GetExpenseById(id);
            if (record == null)
            {
                return false;
            }

            this._repository.DeleteExpenseInRepo(record);
            FinancialEventPublisher.Notify(this, new FinancialEventArgs(TransactionAction.Deleted, record));
            return true;
        }

        public Income GetIncomeById(Guid id) => _repository.GetIncomeById(id);

        public Expense GetExpenseById(Guid id) => _repository.GetExpenseById(id);

        public IReadOnlyList<Income> GetAllIncome() => _repository.GetAllIncome();

        public IReadOnlyList<Expense> GetAllExpense() => _repository.GetAllExpense();
    }
}
