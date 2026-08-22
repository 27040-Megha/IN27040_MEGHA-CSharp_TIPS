using System;
using ErrorHandlingTasks.ApplicationLayer.Service;
using ErrorHandlingTasks.PresentationLayer.View;

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
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;
            var applicationService = new ErrorHandlingService();
            var consoleOperator = new ConsoleOperations(applicationService);
            consoleOperator.Run();
        }

        /// <summary>
        /// Method that will subscribe to the AppDomain.CurrentDomain.UnhandledException that will catch Unhandled global exceptions
        /// </summary>
        /// <param name="sender">Object that invoked the unhandled exception event/param>
        /// <param name="e">Contains Event data and details about Exception</param>
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