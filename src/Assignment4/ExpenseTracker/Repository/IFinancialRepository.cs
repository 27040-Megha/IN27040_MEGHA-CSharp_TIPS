using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Models;

namespace ExpenseTracker.Repository
{
    public interface IFinancialRepository
    {
        public event FinancialRecordHandler? RecordHandler;

        public void AddIncome(Income record);

        public void AddExpense(Expense record);

        public void UpdateIncomeInRepo(Income oldRecord, Income newRecord);

        public void UpdateExpenseInRepo(Expense oldRecord, Expense newRecord);

        public void DeleteIncomeInRepo(Income record);

        public void DeleteExpenseInRepo(Expense record);

        public T? GetById<T>(Guid id)
            where T : class, IFinancialRecord;

        public IEnumerable<Expense> GetAllExpense();

        public IEnumerable<Income> GetAllIncome();
    }
}
