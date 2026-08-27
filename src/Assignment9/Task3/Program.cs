using System;
using Task3.ApplicationLayer.Service;
using Task3.PresentationLayer.View;

namespace Assignments
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var arrayService = new ArrayService();

                var consoleOperator = new ConsoleOperations(arrayService);

                consoleOperator.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Caught: " + ex.Message);
            }
        }
    }
}