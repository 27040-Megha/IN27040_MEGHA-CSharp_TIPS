using System;
using ListImplementation.ApplicationLayer.Service;
using ListImplementation.InfrastructureLayer;
using ListImplementation.PresentationLayer.View;

namespace Assignments
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;
            var bookRepo = new BookRepo<string>();
            var bookService = new BookService<string>(bookRepo);
            var consoleOperator = new ConsoleOperations(bookService);
            consoleOperator.Run();
        }

        public static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                Console.WriteLine("Exception Caught: " + ex.Message);
            }
        }
    }
}