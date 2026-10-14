using System;
using UtilityApp;

namespace DisplayApp
{
    /// <summary>
    /// Contains methods that interacts with user
    /// </summary>
    public class ConsoleOperator
    {
        private readonly IMathUtility _mathUtility;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleOperator"/> class.
        /// </summary>
        /// <param name="mathUtility">MathUtility object</param>
        public ConsoleOperator(IMathUtility mathUtility)
        {
            this._mathUtility = mathUtility;
        }

        /// <summary>
        /// Starts the execution of DisplayApp
        /// </summary>
        public void Start()
        {
            try
            {
                var firstNumberResult = this.GetInputNumber();
                if (!firstNumberResult.IsSuccess)
                {
                    return;
                }

                int firstNumber = firstNumberResult.ResultData;
                var secondNumberResult = this.GetInputNumber();
                if (!secondNumberResult.IsSuccess)
                {
                    return;
                }

                int secondNumber = secondNumberResult.ResultData;
                this.DisplayArithmeticOperations(firstNumber, secondNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}");
            }
        }

        private void DisplayArithmeticOperations(int firstNumber, int secondNumber)
        {
            this.DisplayAddition(firstNumber, secondNumber);
            this.DisplaySubtraction(firstNumber, secondNumber);
            this.DisplayMultiplication(firstNumber, secondNumber);
            this.DisplayDivision(firstNumber, secondNumber);
        }

        private void DisplayAddition(int firstNumber, int secondNumber)
        {
            Console.WriteLine($"{firstNumber} + {secondNumber} = {this._mathUtility.Add(firstNumber, secondNumber)}");
        }

        private void DisplaySubtraction(int firstNumber, int secondNumber)
        {
            Console.WriteLine($"{firstNumber} - {secondNumber} = {this._mathUtility.Subtract(firstNumber, secondNumber)}");
        }

        private void DisplayMultiplication(int firstNumber, int secondNumber)
        {
            Console.WriteLine($"{firstNumber} + {secondNumber} = {this._mathUtility.Multiply(firstNumber, secondNumber)}");
        }

        private void DisplayDivision(int firstNumber, int secondNumber)
        {
            var divisionResult = this._mathUtility.Divide(firstNumber, secondNumber);
            if (!divisionResult.IsSuccess)
            {
                Console.WriteLine("Cannot Divide a number by Zero!");
                return;
            }

            Console.WriteLine($"{firstNumber} / {secondNumber} = {divisionResult.ResultData}");
        }

        private Result GetInputNumber()
        {
            Console.WriteLine("Enter number: ");
            var isValidNumber = InputValidator.ValidateIntger(Console.ReadLine(), out int number);
            if (!isValidNumber)
            {
                Console.WriteLine("Invalid integer format", ConsoleColor.Red);
                return new Result(false);
            }

            return new Result(true, number);
        }
    }
}
