using System;
using StackImplementation.ApplicationLayer.Service;
using StackImplementation.PresentationLayer.View;

namespace Assignments
{
    public class Program
    {
        private static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;
            var stringReversalService = new StringReversalService();
            var consoleOperator = new ConsoleOperations(stringReversalService);
            consoleOperator.Run();
        }

        private static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                Console.WriteLine("Exception Caught: " + ex.Message);
            }
        }
    }
}