using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using CalculatorApp.ApplicationLayer.Utility;
using CalculatorApp.Domain;

namespace CalculatorApp.ApplicationLayer.Service
{
    /// <summary>
    /// Contains all Business logic to perform Calculator Operations.
    /// </summary>
    public class CalculatorService
    {
        /// <summary>
        /// Solves expression using BODMAS rule (First solves Division & Multiplication, then Addition & Subtraction)
        /// Calls MathUtility methods to perform Arithmetic Operations
        /// </summary>
        /// <param name="inputExpression">Input Mathematical Expression</param>
        /// <returns>Result of the Expression, or invalid format error message</returns>
        public Result EvaluateExpression(string inputExpression)
        {
            var expression = ExpressionParser.SplitExpression(inputExpression);
            var validationResult = ExpressionValidator.ValidateExpression(expression);
            if (!validationResult.IsSuccess || validationResult.Message.Contains("Result"))
            {
                return validationResult;
            }

            var calculatedResult = this.CalculateExpressionUsingBODMAS(expression);
            if (!calculatedResult.IsSuccess)
            {
                return calculatedResult;
            }

            return this.ValidateFinalResult(expression);
        }

        private Result CalculateExpressionUsingBODMAS(List<string> expression)
        {
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

            return new Result(true, "All arithmetic operations executed Successfully!");
        }

        private Result ValidateFinalResult(List<string> expression)
        {
            var isValidResult = int.TryParse(expression[0], out int evaluatedResult);
            if (!isValidResult)
            {
                return new Result(false, "Only Integer is supported, Doesn't support Long values");
            }

            return new Result(true, "Result of Expression: ", evaluatedResult);
        }

        private Result HandleDivisionAndMultiplication(List<string> expression)
        {
            while (expression.Contains(OperatorConstants.Multiplication) || expression.Contains(OperatorConstants.Division))
            {
                int indexOfDivide = expression.IndexOf(OperatorConstants.Division);
                int indexOfMultiply = expression.IndexOf(OperatorConstants.Multiplication);

                if (indexOfDivide != -1 && (indexOfMultiply == -1 || indexOfDivide < indexOfMultiply))
                {
                    var divisionResult = this.EvaluateDivide(expression, indexOfDivide);
                    if (!divisionResult.IsSuccess)
                    {
                        return divisionResult;
                    }
                }
                else
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
            while (expression.Contains(OperatorConstants.Addition) || expression.Contains(OperatorConstants.Subtraction))
            {
                int indexOfAdd = expression.IndexOf(OperatorConstants.Addition);
                int indexOfSubtract = expression.IndexOf(OperatorConstants.Subtraction);

                if (indexOfAdd != -1 && (indexOfSubtract == -1 || indexOfAdd < indexOfSubtract))
                {
                    var additionResult = this.EvaluateAdd(expression, indexOfAdd);
                    if (!additionResult.IsSuccess)
                    {
                        return additionResult;
                    }
                }
                else
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

        private Result ExecuteOperation(List<string> expression, int operatorIndex, Func<int, int, int> mathUtilityMethod)
        {
            if (!this.TryParseOperands(expression, operatorIndex, out int number1, out int number2))
            {
                return new Result(false, "Invalid Expression Format!");
            }

            this.UpdateExpressionList(expression, operatorIndex, mathUtilityMethod(number1, number2).ToString());
            return new Result(true);
        }

        private Result EvaluateAdd(List<string> expression, int indexOfAdd)
        {
            return this.ExecuteOperation(expression, indexOfAdd, MathUtility.Add);
        }

        private Result EvaluateSubtract(List<string> expression, int indexOfSubtract)
        {
            return this.ExecuteOperation(expression, indexOfSubtract, MathUtility.Subtract);
        }

        private Result EvaluateMultiply(List<string> expression, int indexOfMultiply)
        {
            return this.ExecuteOperation(expression, indexOfMultiply, MathUtility.Multiply);
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
            return new Result(true);
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
            if (operatorIndex - 1 < 0 || operatorIndex >= expression.Count - 1)
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
