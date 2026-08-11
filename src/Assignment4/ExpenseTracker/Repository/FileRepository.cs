using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ExpenseTracker.Models;

namespace ExpenseTracker.Repository
{
    public class FileRepository : IFinancialRepository
    {
        private readonly string _incomeFilePath;

        private readonly string _expenseFilePath;

        public FileRepository()
        {
            this._incomeFilePath = "C:\\Users\\megha.easwaramoorthy\\IN27040_MEGHA-CSharp_TIPS\\src\\Assignment4\\ExpenseTracker\\Repository\\DataStorage\\income.json";
            this._expenseFilePath = "C:\\Users\\megha.easwaramoorthy\\IN27040_MEGHA-CSharp_TIPS\\src\\Assignment4\\ExpenseTracker\\Repository\\DataStorage\\expense.json";
            if (!File.Exists(this._incomeFilePath))
            {
                File.WriteAllText(this._incomeFilePath, "[]");
            }

            if (!File.Exists(this._expenseFilePath))
            {
                File.WriteAllText(this._expenseFilePath, "[]");
            }
        }

        public void AddExpense(Expense expenseRecord)
        {
            string jsonTextToWrite = this.AddJsonObject<Expense>(expenseRecord, this._expenseFilePath);
            File.WriteAllText(this._expenseFilePath, jsonTextToWrite);
        }

        public void AddIncome(Income incomeRecord)
        {
            string jsonTextToWrite = this.AddJsonObject<Income>(incomeRecord, this._incomeFilePath);
            File.WriteAllText(this._incomeFilePath, jsonTextToWrite);
        }

        public void DeleteExpense(Guid transactionID)
        {
            var expenseList = this.Deserialize<Expense>(this._expenseFilePath);
            var recordToDelete = expenseList.FirstOrDefault(e => e.TransactionID == transactionID);
            expenseList.Remove(recordToDelete);
            string jsonTextToWrite = this.Serialize<Expense>(expenseList);
            this.WriteFileData(this._expenseFilePath, jsonTextToWrite);
        }

        public void DeleteIncome(Guid transactionID)
        {
            var incomeList = this.Deserialize<Income>(this._incomeFilePath);
            var recordToDelete = incomeList.FirstOrDefault(e => e.TransactionID == transactionID);
            incomeList.Remove(recordToDelete);
            string jsonTextToWrite = this.Serialize<Income>(incomeList);
            this.WriteFileData(this._incomeFilePath, jsonTextToWrite);
        }

        public Expense FindExpense(Guid transactionID)
        {
            var expenseList = this.Deserialize<Expense>(this._expenseFilePath);
            var expenseRecord = expenseList.FirstOrDefault(e => e.TransactionID == transactionID);
            return expenseRecord;
        }

        public Income FindIncome(Guid transactionID)
        {
            var incomeList = this.Deserialize<Income>(this._incomeFilePath);
            var incomeRecord = incomeList.FirstOrDefault(e => e.TransactionID == transactionID);
            return incomeRecord;
        }

        public IReadOnlyList<Expense> ReturnAllExpense()
        {
            return this.Deserialize<Expense>(this._expenseFilePath);
        }

        public IReadOnlyList<Income> ReturnAllIncome()
        {
            return this.Deserialize<Income>(this._incomeFilePath);
        }

        public void UpdateExpense(Guid transactionId, Expense newRecord)
        {
            var expenseList = this.Deserialize<Expense>(this._expenseFilePath);
            var expenseRecord = this.FindById<Expense>(expenseList, transactionId);
            expenseRecord.Amount = newRecord.Amount;
            expenseRecord.Date = newRecord.Date;
            expenseRecord.Description = newRecord.Description;
            expenseRecord.Category = newRecord.Category;
            string jsonTextToWrite = this.Serialize<Expense>(expenseList);
            this.WriteFileData(this._expenseFilePath, jsonTextToWrite);
        }

        public void UpdateIncome(Guid transactionId, Income newRecord)
        {
            var incomeList = this.Deserialize<Income>(this._incomeFilePath);
            var incomeRecord = this.FindById<Income>(incomeList, transactionId);
            incomeRecord.Amount = newRecord.Amount;
            incomeRecord.Date = newRecord.Date;
            incomeRecord.Description = newRecord.Description;
            incomeRecord.Source = newRecord.Source;
            string jsonTextToWrite = this.Serialize<Income>(incomeList);
            this.WriteFileData(this._incomeFilePath, jsonTextToWrite);
        }

        private void WriteFileData(string filePath, string jsonTextToWrite)
        {
            File.WriteAllText(filePath, jsonTextToWrite);
        }

        private string AddJsonObject<T>(T recordToAdd, string filePath)
        {
            string existingJson = File.ReadAllText(filePath);
            var list = JsonSerializer.Deserialize<List<T>>(existingJson) ?? new List<T>();
            list.Add(recordToAdd);
            return JsonSerializer.Serialize(list);
        }

        private List<T> Deserialize<T>(string filePath)
        {
            string existingJson = File.ReadAllText(filePath);
            var list = JsonSerializer.Deserialize<List<T>>(existingJson) ?? new List<T>();
            return list;
        }

        private string Serialize<T>(List<T> financialRecords)
        {
            return JsonSerializer.Serialize(financialRecords);
        }

        private T FindById<T>(List<T> financialRecordList, Guid transactionId)
            where T : FinancialRecord
        {
            return financialRecordList.FirstOrDefault(e => e.TransactionID == transactionId);
        }
    }
}
