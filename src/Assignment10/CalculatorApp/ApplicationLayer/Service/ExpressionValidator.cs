using System.Collections.Generic;
using CalculatorApp.Domain;

namespace CalculatorApp.ApplicationLayer.Service
{
    /// <summary>
    /// Contains method to check if Expression is valid
    /// </summary>
    public static class ExpressionValidator
    {
        /// <summary>
        /// Checks if the input expression is valid
        /// User can enter a single number 123 and press =, this will give the same number if the entered value could be parsed as integer, otherwise false
        /// Expression should be of odd length and should atleast be of length 3 to evaluate the expression
        /// </summary>
        /// <param name="expression">Input mathematical expression</param>
        /// <returns>Result object with Success message</returns>
        public static Result ValidateExpression(List<string> expression)
        {
            if (expression.Count == 1)
            {
                if (int.TryParse(expression[0], out int expressionResult))
                {
                    return new Result(true, "Result of Expression: ", expressionResult);
                }

                return new Result(false, "Only integer values Supported!");
            }

            if (expression.Count % 2 == 0 || expression.Count < 3)
            {
                return new Result(false, "Invalid expression format! Must include numbers and operators (e.g., 12 + 4).");
            }

            return new Result(true, "Valid Expression!");
        }
    }
}
