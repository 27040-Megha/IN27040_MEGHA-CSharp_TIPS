using System;
using ExpenseTracker.Repository;
using ExpenseTracker.Service;
using ExpenseTracker.View;

namespace Assignments
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var financialRepository = new FinancialRepository();

                var financialService = new FinancialRecordService(financialRepository);

                var view = new ExpenseTrackerView(financialService);
                view.Run();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception Caught: " + ex.Message);
                Console.ReadKey();
            }
        }
    }
}