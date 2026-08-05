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

        public void AddIncome(decimal amount, DateTime date, string description, string source)
        {
            _repository.RecordHandler += BalanceTracker.HandleIncomeTransaction;
            _repository.AddIncome(new Income(amount, date, description, source));
            _repository.RecordHandler -= BalanceTracker.HandleIncomeTransaction;
        }

        public void AddExpense(decimal amount, DateTime date, string description, string category)
        {
            _repository.RecordHandler += BalanceTracker.HandleExpenseTransaction;
            _repository.AddExpense(new Expense(amount, date, description, category));
            _repository.RecordHandler -= BalanceTracker.HandleExpenseTransaction;
        }

        public bool UpdateIncome(Guid id, decimal amount, DateTime date, string description, string source)
        {
            var existing = _repository.GetById<Income>(id);
            if (existing is null)
            {
                return false;
            }

            var updatedIncome = new Income(amount, date, description, source);
            _repository.RecordHandler += BalanceTracker.HandleIncomeTransaction;
            _repository.UpdateIncomeInRepo(existing, updatedIncome);
            _repository.RecordHandler -= BalanceTracker.HandleIncomeTransaction;
            return true;
        }

        public bool UpdateExpense(Guid id, decimal amount, DateTime date, string description, string category)
        {
            var existing = _repository.GetById<Expense>(id);
            if (existing is null)
            {
                return false;
            }

            var updatedExpense = new Expense(amount, date, description, category);
            _repository.RecordHandler += BalanceTracker.HandleExpenseTransaction;
            _repository.UpdateExpenseInRepo(existing, updatedExpense);
            _repository.RecordHandler -= BalanceTracker.HandleExpenseTransaction;
            return true;
        }

        public void DeleteIncomeRecord(Guid id)
        {
            var record = _repository.GetById<Income>(id);
            _repository.RecordHandler += BalanceTracker.HandleIncomeTransaction;
            if (record != null)
            {
                _repository.DeleteIncomeInRepo(record);
            }
            _repository.RecordHandler -= BalanceTracker.HandleIncomeTransaction;
        }

        public void DeleteExpenseRecord(Guid id)
        {
            var record = _repository.GetById<Expense>(id);
            _repository.RecordHandler += BalanceTracker.HandleExpenseTransaction;
            if (record != null)
            {
                _repository.DeleteExpenseInRepo(record);
            }
            _repository.RecordHandler -= BalanceTracker.HandleExpenseTransaction;
        }

        public Income? GetIncomeById(Guid id) => _repository.GetById<Income>(id);

        public Expense? GetExpenseById(Guid id) => _repository.GetById<Expense>(id);

        public IEnumerable<Income> GetAllIncome() => _repository.GetAllIncome();

        public IEnumerable<Expense> GetAllExpense() => _repository.GetAllExpense();
    }
}
