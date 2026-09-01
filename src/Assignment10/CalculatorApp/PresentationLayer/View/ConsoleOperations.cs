using System;
using CalculatorApp.ApplicationLayer.Service;
using CalculatorApp.PresentationLayer.Helper;

namespace CalculatorApp.PresentationLayer.View
{
    public class ConsoleOperations
    {
        private readonly CalculatorService _calculatorService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleOperations"/> class.
        /// </summary>
        /// <param name="calculatorService">Calculator Service object</param>
        public ConsoleOperations(CalculatorService calculatorService)
        {
            this._calculatorService = calculatorService;
        }

        public void Run()
        {
            Console.WriteLine("CALCULATOR APP");
            var expression = this.GetExpression();
            if (expression == null)
            {
                return;
            }

            this.DisplayCalculatedResult(expression);
        }

        private string GetExpression()
        {
            Console.WriteLine("Enter mathematical Expression (12+4*7/10): ");
            string expression = Console.ReadLine();
            if (!InputValidation.ValidateString(expression))
            {
                TextColor.WriteColoredLine("Expression should not be empty or null", ConsoleColor.Red);
                return null;
            }

            return expression;
        }

        private void DisplayCalculatedResult(string expression)
        {
            var expressionResult = this._calculatorService.EvaluateExpression(expression);
            if (expressionResult.IsSuccess)
            {
                TextColor.WriteColoredLine($"{expressionResult.ResultData}", ConsoleColor.Cyan);
            }
            else
            {
                TextColor.WriteColoredLine(expressionResult.Message, ConsoleColor.Red);
            }
        }
    }
}
