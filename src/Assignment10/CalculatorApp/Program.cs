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
                var mathUtility = new MathUtility();
                var consoleOperator = new ConsoleOperations(mathUtility);
                consoleOperator.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught: " + ex.Message);
            }
        }
    }
}