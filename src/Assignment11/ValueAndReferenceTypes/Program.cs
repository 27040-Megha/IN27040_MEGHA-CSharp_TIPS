using System;
using ValueAndReferenceTypes.ApplicationLayer.Service;
using ValueAndReferenceTypes.PresentationLayer.View;

namespace Assignments
{
    /// <summary>
    /// Entry point of Application
    /// </summary>
    public class Program
    {
        private static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;
            var updateService = new UpdateService();
            var consoleOperator = new ConsoleOperations(updateService);
            consoleOperator.Run();
        }

        private static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                Console.WriteLine($"Exception Message: {ex.Message}");
            }
        }
    }
}