using System;
using System.Collections.Generic;
using System.Linq;
using ExpenseTracker.Models;

namespace ExpenseTracker.Repository
{
    /// <summary>
    /// File Repository class that reads file data and then performs all CRUD operations in an in-memory list and writes back the in-memory list to file
    /// </summary>
    public class FileRepository : ITransactionRepository
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
        /// <param name="indexToUpdate">Index of the object to be edited</param>
        /// <param name="newRecord">New record</param>
        public void UpdateIncome(int indexToUpdate, Income newRecord)
        {
            this._incomeRepo[indexToUpdate] = newRecord;
        }

        /// <summary>
        /// Updates the existing expense record in repo
        /// </summary>
        /// <param name="indexToUpdate">Index of the object to be edited</param>
        /// <param name="newRecord">New record</param>
        public void UpdateExpense(int indexToUpdate, Expense newRecord)
        {
            this._expenseRepo[indexToUpdate] = newRecord;
        }

        /// <summary>
        /// Deletes Income record from income repo
        /// </summary>
        /// <param name="id">TransactionID of Income record to be deleted</param>
        public void DeleteIncome(Guid id)
        {
            var incomeToDelete = this._incomeRepo.FirstOrDefault(income => income.TransactionID == id);
            this._incomeRepo.Remove(incomeToDelete);
        }

        /// <summary>
        /// Deletes Expense record from income repo
        /// </summary>
        /// <param name="id">TransactionID of Expense record to be deleted</param>
        public void DeleteExpense(Guid id)
        {
            var expenseToDelete = this._expenseRepo.FirstOrDefault(expense => expense.TransactionID == id);
            this._expenseRepo.Remove(expenseToDelete);
        }

        /// <summary>
        /// Finds and returns an income record
        /// </summary>
        /// <param name="id">Unique id of record to be found</param>
        /// <returns>Income record found</returns>
        public Income FindIncome(Guid id)
        {
            var incomeRecord = this._incomeRepo.FirstOrDefault(income => income.TransactionID == id);
            return new Income(incomeRecord.TransactionID, incomeRecord.Amount, incomeRecord.Date, incomeRecord.Description, incomeRecord.Source);
        }

        /// <summary>
        /// Finds and returns an expense record
        /// </summary>
        /// <param name="id">Unique id of record to be found</param>
        /// <returns>Expense record found</returns>
        public Expense FindExpense(Guid id)
        {
            var expenseRecord = this._expenseRepo.FirstOrDefault(expense => expense.TransactionID == id);
            return new Expense(expenseRecord.TransactionID, expenseRecord.Amount, expenseRecord.Date, expenseRecord.Description, expenseRecord.Category);
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