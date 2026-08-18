using System;
using System.Collections.Generic;
using System.Linq;
using ExpenseTracker.Models;

namespace ExpenseTracker.Repository
{
    /// <summary>
    /// Repository implementation that stores records
    /// </summary>
    public class FinancialRepository : IFinancialRepository
    {
        private readonly List<Income> _incomeRepo;
        private readonly List<Expense> _expenseRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="FinancialRepository"/> class.
        /// </summary>
        public FinancialRepository()
        {
            this._expenseRepo = new List<Expense>();
            this._incomeRepo = new List<Income>();
        }

        /// <summary>
        /// Adds Income record to income repo
        /// </summary>
        /// <param name="record">Income record</param>
        public void AddIncome(Income record)
        {
            this._incomeRepo.Add(record);
        }

        /// <summary>
        /// Adds Expense record to repo
        /// </summary>
        /// <param name="record">Expensee record</param>
        public void AddExpense(Expense record)
        {
            this._expenseRepo.Add(record);
        }

        /// <summary>
        /// Updates the existing income record in repo
        /// </summary>
        /// <param name="transactionIDToUpdate">Guid of the object to be edited</param>
        /// <param name="newRecord">New record</param>
        public void UpdateIncome(Guid transactionIDToUpdate, Income newRecord)
        {
            var oldRecord = this._incomeRepo.FirstOrDefault(x => x.TransactionID == transactionIDToUpdate);
            oldRecord.Amount = newRecord.Amount;
            oldRecord.Date = newRecord.Date;
            oldRecord.Description = newRecord.Description;
            oldRecord.Source = newRecord.Source;
        }

        /// <summary>
        /// Updates the existing expense record in repo
        /// </summary>
        /// <param name="transactionIDToUpdate">Guid of the object to be edited</param>
        /// <param name="newRecord">New record</param>
        public void UpdateExpense(Guid transactionIDToUpdate, Expense newRecord)
        {
            var oldRecord = this._expenseRepo.FirstOrDefault(x => x.TransactionID == transactionIDToUpdate);
            oldRecord.Amount = newRecord.Amount;
            oldRecord.Date = newRecord.Date;
            oldRecord.Description = newRecord.Description;
            oldRecord.Category = newRecord.Category;
        }

        /// <summary>
        /// Deletes Income record from income repo
        /// </summary>
        /// <param name="id">TransactionID of Income record to be deleted</param>
        public void DeleteIncome(Guid id)
        {
            for (int i = 0; i < this._incomeRepo.Count; i++)
            {
                if (this._incomeRepo[i].TransactionID == id)
                {
                    this._incomeRepo.Remove(this._incomeRepo[i]);
                }
            }
        }

        /// <summary>
        /// Deletes Expense record from income repo
        /// </summary>
        /// <param name="id">TransactionID of Expense record to be deleted</param>
        public void DeleteExpense(Guid id)
        {
            for (int i = 0; i < this._expenseRepo.Count; i++)
            {
                if (this._expenseRepo[i].TransactionID == id)
                {
                    this._expenseRepo.Remove(this._expenseRepo[i]);
                }
            }
        }

        /// <summary>
        /// Finds and returns an income record
        /// </summary>
        /// <param name="id">Unique id of record to be found</param>
        /// <returns>Income record found</returns>
        public Income FindIncome(Guid id)
        {
            foreach (var incomeRecord in this._incomeRepo)
            {
                if (incomeRecord.TransactionID == id)
                {
                    return new Income(incomeRecord.TransactionID, incomeRecord.Amount, incomeRecord.Date, incomeRecord.Description, incomeRecord.Source);
                }
            }

            return null;
        }

        /// <summary>
        /// Finds and returns an expense record
        /// </summary>
        /// <param name="id">Unique id of record to be found</param>
        /// <returns>Expense record found</returns>
        public Expense FindExpense(Guid id)
        {
            foreach (var expenseRecord in this._expenseRepo)
            {
                if (expenseRecord.TransactionID == id)
                {
                    return new Expense(expenseRecord.TransactionID, expenseRecord.Amount, expenseRecord.Date, expenseRecord.Description, expenseRecord.Category);
                }
            }

            return null;
        }

        /// <summary>
        /// Returns Expense repo
        /// </summary>
        /// <returns>List of Expense repo</returns>
        public IReadOnlyList<Expense> ReturnAllExpense()
        {
            return this._expenseRepo.Select(expenseRecord => new Expense(expenseRecord.TransactionID, expenseRecord.Amount, expenseRecord.Date, expenseRecord.Description, expenseRecord.Category)).ToList();
        }

        /// <summary>
        /// Returns Income repo
        /// </summary>
        /// <returns>List of Income repo</returns>
        public IReadOnlyList<Income> ReturnAllIncome()
        {
            return this._incomeRepo.Select(incomeRecord => new Income(incomeRecord.TransactionID, incomeRecord.Amount, incomeRecord.Date, incomeRecord.Description, incomeRecord.Source)).ToList();
        }
    }
}
