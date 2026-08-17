using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ExpenseTracker.Models;
using ExpenseTracker.Service;

namespace ExpenseTracker.Repository
{
    /// <summary>
    /// File Repository class that reads file data and then performs all CRUD operations in an in-memory list and writes back the in-memory list to file
    /// </summary>
    public class FileRepository : IFinancialRepository
    {
        private readonly List<Income> _incomeRepo;

        private readonly List<Expense> _expenseRepo;

        private BalanceTracker _balanceTracker;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileRepository"/> class.
        /// </summary>
        public FileRepository()
        {
            this._incomeRepo = FileRepoService.ReadFile<Income>(FilePath.IncomeFilePath);
            this._expenseRepo = FileRepoService.ReadFile<Expense>(FilePath.ExpenseFilePath);
            this._balanceTracker = FileRepoService.ReadSummaryFile(FilePath.SummaryFilePath);
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
            return new List<Expense>(this._expenseRepo);
        }

        /// <summary>
        /// Returns Income repo
        /// </summary>
        /// <returns>List of Income repo</returns>
        public IReadOnlyList<Income> ReturnAllIncome()
        {
            return new List<Income>(this._incomeRepo);
        }

        /// <summary>
        /// Write the in-memory list back to file before closing the application
        /// </summary>
        /// <param name="balanceTracker">BalanceTracker object</param>
        public void SaveInMemory(BalanceTracker balanceTracker)
        {
            FileRepoService.WriteFile(this._incomeRepo, FilePath.IncomeFilePath);
            FileRepoService.WriteFile(this._expenseRepo, FilePath.ExpenseFilePath);
            FileRepoService.WriteSummaryFile(balanceTracker, FilePath.SummaryFilePath);
        }

        /// <summary>
        /// return summary details from the summary file
        /// </summary>
        /// <returns>BalanceTracker object</returns>
        public BalanceTracker GetSummaryDetails()
        {
            return this._balanceTracker;
        }

        /// <summary>
        /// Updates the BalanceTracker summary details
        /// </summary>
        /// <param name="balanceTracker">BalanceTracker object</param>
        public void UpdateSummary(BalanceTracker balanceTracker)
        {
            if (balanceTracker == null)
            {
                return;
            }

            this._balanceTracker.TotalIncome = balanceTracker.TotalIncome;
            this._balanceTracker.TotalExpense = balanceTracker.TotalExpense;
        }
    }
}
