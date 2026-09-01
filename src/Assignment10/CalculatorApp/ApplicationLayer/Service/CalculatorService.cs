using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CalculatorApp.ApplicationLayer.Service;
using CalculatorApp.Domain;

namespace CalculatorApp.ApplicationLayer.Service
{
    /// <summary>
    /// Contains all Business logic to perform Calculator Operations.
    /// </summary>
    public class CalculatorService
    {
        /// <summary>
        /// Evaluates expression using BODMAS rule (First solves Division & Multiplication, the Addition & Subtraction
        /// </summary>
        /// <param name="inputExpression">Input Mathematical Expression</param>
        /// <returns>Result of the Expression, or invalid format error message</returns>
        public Result EvaluateExpression(string inputExpression)
        {
            var expression = this.SplitExpression(inputExpression);
            if (expression.Count == 1 && expression[0].All(char.IsDigit))
            {
                return new Result(true, "Result of Expression: ", int.Parse(expression[0]));
            }

            if (expression.Count < 3)
            {
                return new Result(false, "Invalid expression format! Must include numbers and operators (e.g., 12 + 4).");
            }

            var multiplicationAndDivisionResult = this.HandleDivisionAndMultiplication(expression);
            if (!multiplicationAndDivisionResult.IsSuccess)
            {
                return multiplicationAndDivisionResult;
            }

            var additionAndSubtractionResult = this.HandleAdditionAndSubtraction(expression);
            if (!additionAndSubtractionResult.IsSuccess)
            {
                return additionAndSubtractionResult;
            }

            return new Result(true, "Result of Expression: ", int.Parse(expression[0]));
        }

        private List<string> SplitExpression(string inputExpression)
        {
            string spacedExpression = "";
            char[] op = { '+', '-', '*', '/' };
            foreach (char ch in inputExpression)
            {
                if (op.Contains(ch))
                {
                    spacedExpression += $" {ch} ";
                }
                else
                {
                    spacedExpression += ch;
                }
            }

            var expression = spacedExpression.Split(" ").ToList();
            return expression;
        }

        private Result HandleDivisionAndMultiplication(List<string> expression)
        {
            while (true)
            {
                int indexOfDivide = expression.IndexOf("/");
                int indexOfMultiply = expression.IndexOf("*");
                if (indexOfDivide == -1 && indexOfMultiply == -1)
                {
                    break;
                }

                if (indexOfDivide != -1 && (indexOfMultiply == -1 || indexOfDivide < indexOfMultiply))
                {
                    var divisionResult = this.EvaluateDivide(expression, indexOfDivide);
                    if (!divisionResult.IsSuccess)
                    {
                        return divisionResult;
                    }
                }
                else if (indexOfMultiply != -1)
                {
                    var multiplicationResult = this.EvaluateMultiply(expression, indexOfMultiply);
                    if (!multiplicationResult.IsSuccess)
                    {
                        return multiplicationResult;
                    }
                }
            }

            return new Result(true, "Complete Multiplication and Division");
        }

        private Result HandleAdditionAndSubtraction(List<string> expression)
        {
            while (true)
            {
                int indexOfAdd = expression.IndexOf("+");
                int indexOfSubtract = expression.IndexOf("-");
                if (indexOfAdd == -1 && indexOfSubtract == -1)
                {
                    break;
                }

                if (indexOfAdd != -1 && (indexOfSubtract == -1 || indexOfAdd < indexOfSubtract))
                {
                    var additionResult = this.EvaluateAdd(expression, indexOfAdd);
                    if (!additionResult.IsSuccess)
                    {
                        return additionResult;
                    }
                }
                else if (indexOfSubtract != -1)
                {
                    var subtractionResult = this.EvaluateSubtract(expression, indexOfSubtract);
                    if (!subtractionResult.IsSuccess)
                    {
                        return subtractionResult;
                    }
                }
            }

            return new Result(true, "Complete Addition and Subtraction");
        }

        private Result EvaluateAdd(List<string> expression, int indexOfAdd)
        {
            if (!this.TryParseOperands(expression, indexOfAdd, out int number1, out int number2))
            {
                return new Result(false, "Invalid Expression Format!");
            }

            this.UpdateExpressionList(expression, indexOfAdd, MathUtility.Add(number1, number2).ToString());
            return new Result(true, "Addition Successful!");
        }

        private Result EvaluateSubtract(List<string> expression, int indexOfSubtract)
        {
            if (!this.TryParseOperands(expression, indexOfSubtract, out int number1, out int number2))
            {
                return new Result(false, "Invalid Expression Format!");
            }

            this.UpdateExpressionList(expression, indexOfSubtract, MathUtility.Subtract(number1, number2).ToString());
            return new Result(true, "Subtraction Successful!");
        }

        private Result EvaluateMultiply(List<string> expression, int indexOfMultiply)
        {
            if (!this.TryParseOperands(expression, indexOfMultiply, out int number1, out int number2))
            {
                return new Result(false, "Invalid Expression Format!");
            }

            this.UpdateExpressionList(expression, indexOfMultiply, MathUtility.Multiply(number1, number2).ToString());
            return new Result(true, "Multiplication Successful!");
        }

        private Result EvaluateDivide(List<string> expression, int indexOfDivide)
        {
            if (!this.TryParseOperands(expression, indexOfDivide, out int number1, out int number2))
            {
                return new Result(false, "Invalid Expression Format!");
            }

            var divisionResult = MathUtility.Divide(number1, number2);
            if (!divisionResult.IsSuccess)
            {
                return new Result(false, "Divisor must not be 0");
            }

            this.UpdateExpressionList(expression, indexOfDivide, divisionResult.ResultData.ToString());
            return new Result(true, "Division Successful!");
        }

        private void UpdateExpressionList(List<string> expression, int operatorIndex, string calculatedResult)
        {
            expression.RemoveAt(operatorIndex + 1);
            expression.RemoveAt(operatorIndex);
            expression.RemoveAt(operatorIndex - 1);
            expression.Insert(operatorIndex - 1, calculatedResult);
        }

        private bool TryParseOperands(List<string> expression, int operatorIndex, out int number1, out int number2)
        {
            number1 = 0;
            number2 = 0;
            if (operatorIndex < 0 || operatorIndex >= expression.Count - 1)
            {
                return false;
            }

            string inputNumber1 = expression[operatorIndex - 1].Trim();
            string inputNumber2 = expression[operatorIndex + 1].Trim();

            bool isValidNumber1 = int.TryParse(inputNumber1, out number1);
            bool isValidNumber2 = int.TryParse(inputNumber2, out number2);
            return isValidNumber1 && isValidNumber2;
        }
    }
}