using System;
using DictionaryImplementation.ApplicationLayer.Service;
using DictionaryImplementation.InfrastructureLayer;
using DictionaryImplementation.PresentationLayer.View;

namespace Assignments
{
    public class Program
    {
        private static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;
            var studentRepo = new StudentRepo<string, int>();
            var studentService = new StudentService<string, int>(studentRepo);
            var consoleOperator = new ConsoleOperations(studentService);
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