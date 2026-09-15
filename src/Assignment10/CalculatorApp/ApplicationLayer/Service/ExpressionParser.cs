using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorApp.ApplicationLayer.Service
{
    /// <summary>
    /// Contains method to parse the given mathematical Expression
    /// </summary>
    public static class ExpressionParser
    {
        /// <summary>
        /// Parses the given mathematical Expression
        /// </summary>
        /// <param name="inputExpression">Input Mathematical expression</param>
        /// <returns>Parsed Expression - List of strings</returns>
        public static List<string> SplitExpression(string inputExpression)
        {
            StringBuilder spacedExpression = new StringBuilder();
            char[] op = { '+', '-', '*', '/' };
            for (int i = 0; i < inputExpression.Length; i++)
            {
                char ch = inputExpression[i];
                if (op.Contains(ch))
                {
                    if (ch == '-' && (i == 0 || op.Contains(inputExpression[i - 1])))
                    {
                        spacedExpression.Append(ch);
                    }
                    else
                    {
                        spacedExpression.Append($" {ch} ");
                    }
                }
                else
                {
                    spacedExpression.Append(ch);
                }
            }

            var expression = spacedExpression.ToString().Split(" ").ToList();
            return expression;
        }
    }
}
