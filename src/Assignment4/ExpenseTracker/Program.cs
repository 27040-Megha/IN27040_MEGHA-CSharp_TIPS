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
                var transactionRepository = new FileRepository();

                var financialService = new FinancialRecordService(transactionRepository);

                FinancialEventPublisher.FinancialRecordChangeHandler += financialService.HandleFinancialRecordChange;

                AppDomain.CurrentDomain.ProcessExit += financialService.OnProcessExit;

                Console.CancelKeyPress += (sender, e) =>
                {
                    e.Cancel = true;
                    financialService.OnProcessExit(sender, e);
                    Environment.Exit(0);
                };

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