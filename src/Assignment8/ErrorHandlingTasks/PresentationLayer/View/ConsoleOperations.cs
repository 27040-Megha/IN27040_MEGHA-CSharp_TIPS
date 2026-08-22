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

        /// <summary>
        /// Prints the text in Specific Color
        /// </summary>
        /// <param name="text">Input string</param>
        /// <param name="colorChoice">Specific color of text to be displayed</param>
        private void WriteColorLine(string text, ConsoleColor colorChoice)
        {
            Console.ForegroundColor = colorChoice;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private void CalculateDivision()
        {
            try
            {
                Console.WriteLine(DisplayResource.PromptDividend);
                string number1 = Console.ReadLine();
                int dividend = InputValidator.ValidateNumber(number1);
                Console.WriteLine(DisplayResource.PromptDivisor);
                string number2 = Console.ReadLine();
                int divisor = InputValidator.ValidateNumber(number2);
                int divisionResult = this._service.Divide(dividend, divisor);
                Console.WriteLine(string.Format(DisplayResource.DivisionResult, divisionResult));
            }
            catch (InvalidUserInputException ex)
            {
                this.WriteColorLine(ex.Message, ConsoleColor.Red);
            }
            catch (DivideByZeroException ex)
            {
                this.WriteColorLine(ex.Message, ConsoleColor.Red);
            }
            finally
            {
                this.WriteColorLine(DisplayResource.FinallyBlockStatement, ConsoleColor.Cyan);
            }
        }

        private void GetArrayElements()
        {
            try
            {
                Console.WriteLine(DisplayResource.PromptArraySize);
                int arraySize = InputValidator.ValidateNumber(Console.ReadLine());
                var array = new int[arraySize];
                Console.WriteLine(DisplayResource.PromptArrayElements);
                for (int i = 0; i < arraySize; i++)
                {
                    array[i] = InputValidator.ValidateNumber(Console.ReadLine());
                }

                int fifthElementOfArray = this._service.GetFifthElementFromArray(array);
                Console.WriteLine(string.Format(DisplayResource.FifthElementOfArray, fifthElementOfArray));
            }
            catch (InvalidOperationException ex)
            {
                this.WriteColorLine(ex.Message, ConsoleColor.Red);
            }
        }
    }
}
