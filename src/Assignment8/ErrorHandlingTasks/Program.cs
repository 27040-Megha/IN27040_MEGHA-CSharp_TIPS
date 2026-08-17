using System;
using ErrorHandlingTasks.ApplicationLayer.Service;
using ErrorHandlingTasks.PresentationLayer.View;

namespace Assignments
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;
            var applicationService = new ErrorHandlingService();
            var consoleOperator = new ConsoleOperations(applicationService);
            consoleOperator.Run();
        }

        public static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                Console.WriteLine($"Exception Message: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            }
        }
    }
}