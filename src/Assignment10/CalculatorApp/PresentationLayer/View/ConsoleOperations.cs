using System;
using CalculatorApp.ApplicationLayer.Service;
using CalculatorApp.PresentationLayer.Helper;

namespace CalculatorApp.PresentationLayer.View
{
    /// <summary>
    /// Handles All interaction with the user
    /// </summary>
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

        /// <summary>
        /// Entry point of PresentationLayer (called from Main())
        /// </summary>
        public void Run()
        {
            Console.WriteLine(DisplayResource.CalculatorApp);
            var expression = this.GetExpression();
            if (expression == null)
            {
                return;
            }

            this.DisplayCalculatedResult(expression);
        }

        private string GetExpression()
        {
            Console.WriteLine(DisplayResource.PromptExpression);
            string expression = Console.ReadLine();
            if (!InputValidation.ValidateString(expression))
            {
                TextColor.WriteColoredLine(DisplayResource.InvalidExpression, ConsoleColor.Red);
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
