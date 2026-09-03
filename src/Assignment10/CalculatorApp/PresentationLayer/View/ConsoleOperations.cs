using System;
using System.Text;
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
            ConsoleKey key = ConsoleKey.A;
            do
            {
                Console.Clear();
                Console.WriteLine(DisplayResource.CalculatorApp);
                var expression = this.GetExpression();
                if (expression == null)
                {
                    continue;
                }

                this.DisplayCalculatedResult(expression);
                TextColor.WriteColoredLine(DisplayResource.PromptForEscape, ConsoleColor.Cyan);
                key = Console.ReadKey().Key;
            }
            while (key != ConsoleKey.Escape);
        }

        private string GetExpression()
        {
            Console.WriteLine(DisplayResource.DisplayCalculatorDesign);
            Console.SetCursorPosition(2, 3);
            StringBuilder expression = new StringBuilder();
            while (true)
            {
                ConsoleKeyInfo input = Console.ReadKey(true);
                char inputCharacter = input.KeyChar;
                if (input.Key == ConsoleKey.Enter || inputCharacter == '=')
                {
                    break;
                }

                if (!InputValidation.IsValidInput(inputCharacter))
                {
                    Console.SetCursorPosition(0, 9);
                    TextColor.WriteColoredLine(DisplayResource.InvalidExpression, ConsoleColor.Red);
                    TextColor.WriteColoredLine(DisplayResource.PromptForContinue, ConsoleColor.Cyan);
                    Console.ReadKey();
                    return null;
                }

                Console.Write(inputCharacter);
                expression.Append(inputCharacter);
            }

            return expression.ToString();
        }

        private void DisplayCalculatedResult(string expression)
        {
            var expressionResult = this._calculatorService.EvaluateExpression(expression);
            if (expressionResult.IsSuccess)
            {
                Console.SetCursorPosition(39, 4);
                TextColor.WriteColoredLine($"{expressionResult.ResultData}", ConsoleColor.Cyan);
                Console.SetCursorPosition(0, 16);
            }
            else
            {
                Console.SetCursorPosition(0, 12);
                TextColor.WriteColoredLine(expressionResult.Message, ConsoleColor.Red);
            }
        }
    }
}
