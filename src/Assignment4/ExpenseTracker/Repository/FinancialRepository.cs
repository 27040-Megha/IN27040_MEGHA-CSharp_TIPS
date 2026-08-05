using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Models;

namespace ExpenseTracker.Repository
{
    public class FinancialRepository : IFinancialRepository
    {
        private readonly List<Income> _incomeRepo = new();
        private readonly List<Expense> _expenseRepo = new();

        public event FinancialRecordHandler? RecordHandler;

        public void AddIncome(Income record)
        {
            _incomeRepo.Add(record);
            RecordHandler?.Invoke(TransactionAction.Added, record, null);
        }

        public void AddExpense(Expense record)
        {
            _expenseRepo.Add(record);
            RecordHandler?.Invoke(TransactionAction.Added, record, null);
        }

        public void UpdateIncomeInRepo(Income oldRecord, Income newRecord)
        {
            RecordHandler?.Invoke(TransactionAction.Updated, newRecord, oldRecord);
            Income oldRecordCopy = new Income(oldRecord);
            oldRecord.Amount = newRecord.Amount;
            oldRecord.Date = newRecord.Date;
            oldRecord.Description = newRecord.Description;
            oldRecord.Source = newRecord.Source;
        }

        public void UpdateExpenseInRepo(Expense oldRecord, Expense newRecord)
        {
            RecordHandler?.Invoke(TransactionAction.Updated, newRecord, oldRecord);
            oldRecord.Amount = newRecord.Amount;
            oldRecord.Date = newRecord.Date;
            oldRecord.Description = newRecord.Description;
            oldRecord.Category = newRecord.Category;
        }

        public void DeleteIncomeInRepo(Income record)
        {
            if (_incomeRepo.Remove(record))
            {
                RecordHandler?.Invoke(TransactionAction.Deleted, record, null);
            }
        }

        public void DeleteExpenseInRepo(Expense record)
        {
            if (_expenseRepo.Remove(record))
            {
                RecordHandler?.Invoke(TransactionAction.Deleted, record, null);
            }
        }

        public T? GetById<T>(Guid id) where T : class, IFinancialRecord
        {
            if (typeof(T) == typeof(Income))
            {
                return _incomeRepo.FirstOrDefault(x => x.TransactionID == id) as T;
            }
            if (typeof(T) == typeof(Expense))
            {
                return _expenseRepo.FirstOrDefault(x => x.TransactionID == id) as T;
            }
            return null;
        }

        public IEnumerable<Expense> GetAllExpense() => _expenseRepo;
        public IEnumerable<Income> GetAllIncome() => _incomeRepo;
    }
}
