using System;
using ErrorHandlingTasks.ApplicationLayer.Service;
using ErrorHandlingTasks.PresentationLayer.View;

namespace Assignments
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var applicationService = new ErrorHandlingService();

                var consoleOperator = new ConsoleOperations(applicationService);

                consoleOperator.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Caught: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Application Execution Completed - from Finally block");
            }
        }
    }
}