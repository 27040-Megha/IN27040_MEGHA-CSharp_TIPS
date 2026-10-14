using DisplayApp;
using MathApp;

namespace Assignments
{
    /// <summary>
    /// Main class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of calculator application
        /// </summary>
        public static void Main()
        {
            try
            {
                var mathUtility = new MathUtility();
                var consoleOperator = new ConsoleOperator(mathUtility);
                consoleOperator.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}");
            }
        }
    }
}