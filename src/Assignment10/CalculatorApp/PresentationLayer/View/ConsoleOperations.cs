using System;
using System.Text;
using CalculatorApp.ApplicationLayer.Service;
using CalculatorApp.Domain;
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
            this.ExecuteCalculator();
        }

        private void ExecuteCalculator()
        {
            ConsoleKey exitKey = ConsoleKey.A;
            do
            {
                this.DisplayCalculatorApp();
                var expression = this.GetExpression();
                if (expression == null)
                {
                    continue;
                }

                this.DisplayCalculatedResult(expression);
                exitKey = this.GetExitChoice();
            }
            while (exitKey != ConsoleKey.Escape);
        }

        private void DisplayCalculatorApp()
        {
            Console.Clear();
            Console.WriteLine(DisplayResource.CalculatorApp);
        }

        private ConsoleKey GetExitChoice()
        {
            TextColor.WriteColoredLine(DisplayResource.PromptForEscape, ConsoleColor.Cyan);
            return Console.ReadKey().Key;
        }

        private string GetExpression()
        {
            this.DisplayCalculator();
            var expression = this.BuildExpression();
            return expression;
        }

        private ConsoleKeyInfo ReadUserInput()
        {
            return Console.ReadKey(true);
        }

        private bool ValidateInput(char inputCharacter)
        {
            if (!InputValidation.IsValidInput(inputCharacter))
            {
                CursorPositions.Error();
                TextColor.WriteColoredLine(DisplayResource.InvalidExpression, ConsoleColor.Red);
                TextColor.WriteColoredLine(DisplayResource.PromptForContinue, ConsoleColor.Cyan);
                Console.ReadKey();
                return false;
            }

            return true;
        }

        private string BuildExpression()
        {
            StringBuilder expression = new StringBuilder();
            while (true)
            {
                ConsoleKeyInfo input = this.ReadUserInput();
                char inputCharacter = input.KeyChar;
                if (input.Key == ConsoleKey.Enter || inputCharacter == '=')
                {
                    break;
                }

                if (!this.ValidateInput(inputCharacter))
                {
                    return null;
                }

                Console.Write(inputCharacter);
                expression.Append(inputCharacter);
            }

            return expression.ToString();
        }

        private void DisplayCalculator()
        {
            Console.WriteLine(DisplayResource.DisplayCalculatorDesign);
            CursorPositions.Input();
        }

        private Result GetCalculatedResult(string expression)
        {
            return this._calculatorService.EvaluateExpression(expression);
        }

        private void DisplayCalculatedResult(string expression)
        {
            var expressionResult = this.GetCalculatedResult(expression);
            if (expressionResult.IsSuccess)
            {
                CursorPositions.Result();
                TextColor.WriteColoredLine($"{expressionResult.ResultData}", ConsoleColor.Cyan);
                CursorPositions.Default();
            }
            else
            {
                CursorPositions.Error();
                TextColor.WriteColoredLine(expressionResult.Message, ConsoleColor.Red);
            }
        }
    }
}
