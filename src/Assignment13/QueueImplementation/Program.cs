using System;
using QueueImplementation.ApplicationLayer.Service;
using QueueImplementation.InfrastructureLayer;
using QueueImplementation.PresentationLayer.View;

namespace Assignments
{
    public class Program
    {
        private static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;
            var queueRepo = new QueueRepo<string>();
            var queueService = new QueueService<string>(queueRepo);
            var consoleOperator = new ConsoleOperations(queueService);
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