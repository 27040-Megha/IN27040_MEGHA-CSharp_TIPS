using System;
using CalculatorApp.ApplicationLayer.Service;
using CalculatorApp.PresentationLayer.View;

namespace Assignments
{
    /// <summary>
    /// Entry point of Application
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args">Arguments</param>
        public static void Main(string[] args)
        {
            try
            {
                var calculatorService = new CalculatorService();
                var consoleOperator = new ConsoleOperations(calculatorService);
                consoleOperator.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught: " + ex.Message);
            }
        }
    }
}