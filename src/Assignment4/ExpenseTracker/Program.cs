using System;
using ExpenseTracker.Models;
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
                var financialRepository = new FileRepository();

                var financialService = new FinancialRecordService(financialRepository);

                FinancialEventPublisher.FinancialRecordChangeHandler += financialService.HandleFinancialRecordChange;

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