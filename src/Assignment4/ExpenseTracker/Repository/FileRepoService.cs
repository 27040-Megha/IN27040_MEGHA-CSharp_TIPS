using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ExpenseTracker.Models;

namespace ExpenseTracker.Repository
{
    /// <summary>
    /// Helper method for file repository - Contains methods for Serialize and Deserialize and return List
    /// </summary>
    public static class FileRepoService
    {
        /// <summary>
        /// Method to deserialize JSON file and return as List
        /// </summary>
        /// <typeparam name="T">Generic Type: Could be Income or Expense Object</typeparam>
        /// <param name="filePath">Income Filepath or Expense Filepath</param>
        /// <returns>Deserialized List of Financial Record (Income or Expense object)</returns>
        public static List<T> ReadFile<T>(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<T>();
            }

            string existingJson = File.ReadAllText(filePath);
            var list = JsonSerializer.Deserialize<List<T>>(existingJson) ?? new List<T>();
            return list;
        }

        /// <summary>
        /// Method to serialize List of objects and write it in the file
        /// </summary>
        /// <typeparam name="T">Generic Type: Could be Income or Expense Object</typeparam>
        /// <param name="financialRecords"> List of Financial Record (Income or Expense object)</param>
        /// <param name="filePath">Income Filepath or Expense Filepath</param>
        public static void WriteFile<T>(List<T> financialRecords, string filePath)
        {
            string jsonTextToWrite = JsonSerializer.Serialize(financialRecords);
            File.WriteAllText(filePath, jsonTextToWrite);
        }

        /// <summary>
        /// Serializes Summary Data (BalanceTracker object) to Summary File
        /// </summary>
        /// <param name="balanceTracker">BalanceTracker object</param>
        /// <param name="filePath">Summary file path</param>
        public static void WriteSummaryFile(BalanceTracker balanceTracker, string filePath)
        {
            string jsonTextToWrite = JsonSerializer.Serialize(balanceTracker);
            File.WriteAllText(filePath, jsonTextToWrite);
        }

        /// <summary>
        /// Deserializes JSON text to BalanceTracker object and returns the object
        /// </summary>
        /// <param name="filePath">Summary file path</param>
        /// <returns>BalanceTracker object</returns>
        public static BalanceTracker ReadSummaryFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new BalanceTracker();
            }

            string existingJson = File.ReadAllText(filePath);
            var balanceTracker = JsonSerializer.Deserialize<BalanceTracker>(existingJson);
            return balanceTracker;
        }
    }
}
