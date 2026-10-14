using System;
using UtilityApp;

namespace Assignments
{
    /// <summary>
    ///  Main class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of application
        /// </summary>
        public static void Main()
        {
            try
            {
                var firstNumberResult = GetInputNumber();
                if (!firstNumberResult.IsSuccess)
                {
                    return;
                }

                int firstNumber = firstNumberResult.ResultData;
                var secondNumberResult = GetInputNumber();
                if (!secondNumberResult.IsSuccess)
                {
                    return;
                }

                int secondNumber = secondNumberResult.ResultData;
                DisplayArithmeticOperations(firstNumber, secondNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}");
            }
        }

        private static void DisplayArithmeticOperations(int firstNumber, int secondNumber)
        {
            DisplayAddition(firstNumber, secondNumber);
            DisplaySubtraction(firstNumber, secondNumber);
            DisplayMultiplication(firstNumber, secondNumber);
            DisplayDivision(firstNumber, secondNumber);
        }

        private static Result GetInputNumber()
        {
            TextColor.WriteColoredLine("Enter number: ", ConsoleColor.Cyan);
            var isValidNumber = InputValidator.ValidateIntger(Console.ReadLine(), out int number);
            if (!isValidNumber)
            {
                TextColor.WriteColoredLine("Invalid integer format", ConsoleColor.Red);
                return new Result(false);
            }

            return new Result(true, "Successfully parsed", number);
        }

        private static void DisplayAddition(int value1, int value2)
        {
            Console.WriteLine($"{value1} + {value2} = {MathUtility.Add(value1, value2)}");
        }

        private static void DisplaySubtraction(int value1, int value2)
        {
            Console.WriteLine($"{value1} - {value2} = {MathUtility.Subtract(value1, value2)}");
        }

        private static void DisplayMultiplication(int value1, int value2)
        {
            Console.WriteLine($"{value1} * {value2} = {MathUtility.Multiply(value1, value2)}");
        }

        private static void DisplayDivision(int value1, int value2)
        {
            var divisionResult = MathUtility.Divide(value1, value2);
            if (!divisionResult.IsSuccess)
            {
                TextColor.WriteColoredLine(divisionResult.Message, ConsoleColor.Red);
                return;
            }

            Console.WriteLine($"{value1} / {value2} = {divisionResult.ResultData}");
        }
    }
}