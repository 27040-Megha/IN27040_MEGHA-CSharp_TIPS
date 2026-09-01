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
    public class CalculatorService
    {
        public Result Evaluate(string inputExpression)
        {
            var expression = this.SplitExpression(inputExpression);

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
                    string inputNumber1 = expression[indexOfDivide - 1].Trim();
                    string inputNumber2 = expression[indexOfDivide + 1].Trim();

                    bool isValidNumber1 = int.TryParse(inputNumber1, out int number1);
                    bool isValidNumber2 = int.TryParse(inputNumber2, out int number2);
                    if (!isValidNumber1 || !isValidNumber2)
                    {
                        return new Result(false, "Invalid expression format!");
                    }

                    var divisionResult = MathUtility.Divide(number1, number2);
                    if (divisionResult.IsSuccess)
                    {
                        expression.RemoveAt(indexOfDivide + 1);
                        expression.RemoveAt(indexOfDivide);
                        expression.RemoveAt(indexOfDivide - 1);
                        expression.Insert(indexOfDivide - 1, divisionResult.ResultData.ToString());
                    }
                    else
                    {
                        return new Result(false, "Divisor must not be 0");
                    }
                }
                else if (indexOfMultiply != -1)
                {
                    string inputNumber1 = expression[indexOfMultiply - 1].Trim();
                    string inputNumber2 = expression[indexOfMultiply + 1].Trim();

                    bool isValidNumber1 = int.TryParse(inputNumber1, out int number1);
                    bool isValidNumber2 = int.TryParse(inputNumber2, out int number2);
                    if (!isValidNumber1 || !isValidNumber2)
                    {
                        return new Result(false, "Invalid expression format!");
                    }

                    expression.RemoveAt(indexOfMultiply + 1);
                    expression.RemoveAt(indexOfMultiply);
                    expression.RemoveAt(indexOfMultiply - 1);
                    expression.Insert(indexOfMultiply - 1, MathUtility.Multiply(number1, number2).ToString());
                }
            }

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
                    string inputNumber1 = expression[indexOfAdd - 1].Trim();
                    string inputNumber2 = expression[indexOfAdd + 1].Trim();

                    bool isValidNumber1 = int.TryParse(inputNumber1, out int number1);
                    bool isValidNumber2 = int.TryParse(inputNumber2, out int number2);
                    if (!isValidNumber1 || !isValidNumber2)
                    {
                        return new Result(false, "Invalid expression format!");
                    }

                    expression.RemoveAt(indexOfAdd + 1);
                    expression.RemoveAt(indexOfAdd);
                    expression.RemoveAt(indexOfAdd - 1);
                    expression.Insert(indexOfAdd - 1, MathUtility.Add(number1, number2).ToString());
                }
                else if (indexOfSubtract != -1)
                {
                    string inputNumber1 = expression[indexOfSubtract - 1].Trim();
                    string inputNumber2 = expression[indexOfSubtract + 1].Trim();

                    bool isValidNumber1 = int.TryParse(inputNumber1, out int number1);
                    bool isValidNumber2 = int.TryParse(inputNumber2, out int number2);
                    if (!isValidNumber1 || !isValidNumber2)
                    {
                        return new Result(false, "Invalid expression format!");
                    }

                    expression.RemoveAt(indexOfSubtract + 1);
                    expression.RemoveAt(indexOfSubtract);
                    expression.RemoveAt(indexOfSubtract - 1);
                    expression.Insert(indexOfSubtract - 1, MathUtility.Subtract(number1, number2).ToString());
                }
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
    }
}