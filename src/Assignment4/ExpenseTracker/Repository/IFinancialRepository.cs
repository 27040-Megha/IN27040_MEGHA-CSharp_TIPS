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
        public void AddIncome(Income record);

        public void AddExpense(Expense record);

        public bool Update<T>(T existingRecord, T updatedRecord);

        public void DeleteIncomeInRepo(Income record);

        public void DeleteExpenseInRepo(Expense record);

        public T GetById<T>(Guid id) where T : class;

        public IEnumerable<Expense> GetAllExpense();

        public IEnumerable<Income> GetAllIncome();
    }
}
