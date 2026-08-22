using System;
using ExpenseTracker.Repository;
using ExpenseTracker.Service;
using ExpenseTracker.View;

namespace Assignments
{
    /// <summary>
    /// Main Class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry Point of Application
        /// </summary>
        /// <param name="args">Arguments</param>
        public static void Main(string[] args)
        {
            try
            {
                FinancialEventPublisher.FinancialRecordChangeHandler += BalanceTracker.HandleFinancialRecordChange;
                var transactionRepository = new TransactionRepository();

                var financialService = new FinancialRecordService(transactionRepository);

                var view = new ExpenseTrackerView(financialService);
                view.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Caught: " + ex.Message);
                Console.ReadKey();
            }
        }
    }
}