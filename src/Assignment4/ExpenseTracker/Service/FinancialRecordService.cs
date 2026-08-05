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
            var income = new Income(amount, date, description, source);
            FinancialRepository.RecordHandler += BalanceTracker.HandleIncomeTransaction;
            _repository.AddIncome(income);
            FinancialRepository.RecordHandler -= BalanceTracker.HandleIncomeTransaction;
        }

        public void AddExpense(decimal amount, DateTime date, string description, string category)
        {
            var expense = new Expense(amount, date, description, category);
            FinancialRepository.RecordHandler += BalanceTracker.HandleExpenseTransaction;
            _repository.AddExpense(expense);
            FinancialRepository.RecordHandler -= BalanceTracker.HandleExpenseTransaction;
        }

        public bool UpdateIncome(Guid id, decimal amount, DateTime date, string description, string source)
        {
            Income? existingIncome = _repository.GetById<Income>(id);
            if (existingIncome is null)
            {
                return false;
            }
            Income updatedIncome = new Income(amount, date, description, source);
            return _repository.Update(existingIncome, updatedIncome);
        }

        public bool UpdateExpense(Guid id, decimal amount, DateTime date, string description, string category)
        {
            Expense? existingExpense = _repository.GetById<Expense>(id);
            if (existingExpense is null)
            {
                return false;
            }
            var updatedExpense = new Expense(amount, date, description, category);
            return _repository.Update(existingExpense, updatedExpense);
        }

        public decimal GetBalance()
        {
            return BalanceTracker.BalanceAmount;
        }

        public void DeleteIncomeRecord(Guid id)
        {
            var record = this.GetIncomeById(id);
            if (record != null)
            {
                FinancialRepository.RecordHandler += BalanceTracker.HandleIncomeTransaction;
                _repository.DeleteIncomeInRepo(record);
                FinancialRepository.RecordHandler -= BalanceTracker.HandleIncomeTransaction;
            }
        }

        public void DeleteExpenseRecord(Guid id)
        {
            var record = this.GetExpenseById(id);
            if (record != null)
            {
                FinancialRepository.RecordHandler += BalanceTracker.HandleExpenseTransaction;
                _repository.DeleteExpenseInRepo(record);
                FinancialRepository.RecordHandler -= BalanceTracker.HandleExpenseTransaction;
            }
        }

        public Income? GetIncomeById(Guid id)
        {
            return _repository.GetById<Income>(id);
        }

        public Expense? GetExpenseById(Guid id)
        {
            return _repository.GetById<Expense>(id);
        }

        public IEnumerable<Income> GetAllIncome()
        {
            return _repository.GetAllIncome();
        }

        public IEnumerable<Expense> GetAllExpense()
        {
            return _repository.GetAllExpense();
        }
    }
}
