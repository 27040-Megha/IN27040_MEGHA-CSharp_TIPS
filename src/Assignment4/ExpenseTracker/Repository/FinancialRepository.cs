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
        private readonly List<Income> _incomeRepo;

        private readonly List<Expense> _expenseRepo;

        public FinancialRepository()
        {
            _incomeRepo = new List<Income>();
            _expenseRepo = new List<Expense>();
        }

        public static event FinancialRecordHandler RecordHandler;

        public decimal Balance { get; set; }

        public void AddIncome(Income record)
        {
            _incomeRepo.Add(record);
            RecordHandler.Invoke(TransactionAction.Added, record, null);
        }

        public void AddExpense(Expense record)
        {
            _expenseRepo.Add(record);
            RecordHandler.Invoke(TransactionAction.Added, record, null);
        }

        public bool Update<T>(T existingRecord, T updatedRecord)
        {
            throw new Exception();
        }

        public void DeleteIncomeInRepo(Income record)
        {
            if (record==null)
            {
                return;
            }

            _incomeRepo.Remove(record);
            RecordHandler?.Invoke(TransactionAction.Deleted, record, null);
        }

        public void DeleteExpenseInRepo(Expense record)
        {
            if (record == null)
            {
                return;
            }

            _expenseRepo.Remove(record);
            RecordHandler?.Invoke(TransactionAction.Deleted, record, null);
        }

        public T GetById<T>(Guid id) where T : class
        {
            if (typeof(T) == typeof(Income))
            {
                foreach (var transaction in _incomeRepo)
                {
                    if (transaction.TransactionID == id)
                    {
                        return transaction as T;
                    }
                }
            }

            if (typeof(T) == typeof(Expense))
            {
                foreach (var transaction in _expenseRepo)
                {
                    if (transaction.TransactionID == id)
                    {
                        return transaction as T;
                    }
                }
            }

            return default;
        }

        public IEnumerable<Expense> GetAllExpense()
        {
            return _expenseRepo;
        }

        public IEnumerable<Income> GetAllIncome()
        {
            return _incomeRepo;
        }
    }
}
