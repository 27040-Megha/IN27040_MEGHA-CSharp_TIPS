using System;
using CalculatorApp.ApplicationLayer.Service;
using CalculatorApp.PresentationLayer.View;

namespace Assignments
{
    public class Program
    {
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