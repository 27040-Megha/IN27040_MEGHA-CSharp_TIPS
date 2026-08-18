using System;
using ErrorHandlingTasks.ApplicationLayer.Service;
using ErrorHandlingTasks.Domain;
using ErrorHandlingTasks.PresentationLayer.Helper;

namespace ErrorHandlingTasks.PresentationLayer.View
{
    /// <summary>
    /// Contains all methods that involves Console Operations
    /// </summary>
    public class ConsoleOperations
    {
        private readonly ErrorHandlingService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleOperations"/> class.
        /// </summary>
        /// <param name="service">Service Object to access service in Application Layer</param>
        public ConsoleOperations(ErrorHandlingService service)
        {
            this._service = service;
        }

        /// <summary>
        /// Initiates the ConsoleOperations Execution
        /// </summary>
        public void Run()
        {
            this.CalculateDivision();
            this.GetArrayElements();
            Console.ReadKey();
        }

        private void CalculateDivision()
        {
            try
            {
                Console.WriteLine("Enter Dividend: ");
                string number1 = Console.ReadLine();
                int dividend = InputValidator.ValidateNumber(number1);
                Console.WriteLine("Enter Divisor: ");
                string number2 = Console.ReadLine();
                int divisor = InputValidator.ValidateNumber(number2);
                int divisionResult = this._service.Divide(dividend, divisor);
                Console.WriteLine($"Division: {divisionResult}");
            }
            catch (InvalidUserInputException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Finally Block of Division Operation");
            }
        }

        private void GetArrayElements()
        {
            try
            {
                Console.WriteLine("Enter Array Size: ");
                int arraySize = InputValidator.ValidateNumber(Console.ReadLine());
                var array = new int[arraySize];
                Console.WriteLine("Enter Array Elements: ");

                for (int i = 0; i < arraySize; i++)
                {
                    array[i] = InputValidator.ValidateNumber(Console.ReadLine());
                }

                int fifthElementOfArray = this._service.GetFifthElementFromArray(array);
                Console.WriteLine($"Fifth element of the Array: {fifthElementOfArray}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
