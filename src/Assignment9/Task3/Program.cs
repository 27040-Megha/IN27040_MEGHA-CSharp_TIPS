using System;
using Task3.ApplicationLayer.Service;
using Task3.PresentationLayer.View;

namespace Assignments
{
    /// <summary>
    /// Entry point of application
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main class
        /// </summary>
        /// <param name="args">Arguments</param>
        public static void Main(string[] args)
        {
            try
            {
                var arrayService = new ArrayService();

                var consoleOperator = new ConsoleOperations(arrayService);

                consoleOperator.Run();

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Caught: " + ex.Message);
            }
        }
    }
}