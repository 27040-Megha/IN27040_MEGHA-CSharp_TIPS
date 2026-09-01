using System;
using CalculatorApp.ApplicationLayer.Service;
using CalculatorApp.Domain;

namespace CalculatorApp.PresentationLayer.View
{
    public class ConsoleOperations
    {
        public void Run()
        {
            Console.WriteLine("CALCULATOR APP");
            var expression = this.GetInput();
            if (expression == null)
            {
                return;
            }

            switch (expression.Operator)
            {
                case '+':
                    this.DisplayAddition(expression.Number1, expression.Number2);
                    break;
                case '-':
                    this.DisplaySubtraction(expression.Number1, expression.Number2);
                    break;
                case '*':
                    this.DisplayMultiplication(expression.Number1, expression.Number2);
                    break;
                case '/':
                    this.DisplayDivision(expression.Number1, expression.Number2);
                    break;
            }
        }

        private void DisplayAddition(int number1, int number2)
        {
            this.DisplayResult(number1, number2, '+', MathUtility.Add(number1, number2));
        }

        private void DisplaySubtraction(int number1, int number2)
        {
            this.DisplayResult(number1, number2, '-', MathUtility.Subtract(number1, number2));
        }

        private void DisplayMultiplication(int number1, int number2)
        {
            this.DisplayResult(number1, number2, '*', MathUtility.Multiply(number1, number2));
        }

        private void DisplayDivision(int number1, int number2)
        {
            var isDivideSuccessful = MathUtility.Divide(number1, number2, out int quotient);
            if (!isDivideSuccessful)
            {
                Console.WriteLine("Divisor should not be 0");
                return;
            }

            this.DisplayResult(number1, number2, '/', quotient);
        }

        private void DisplayResult(int number1, int number2, char op, int result)
        {
            Console.WriteLine($"{number1} {op} {number2} = {result}");
        }

        private MathematicalExpression GetInput()
        {
            Console.WriteLine("Enter Mathematical Expression (12 + 3): ");
            string inputExpression = Console.ReadLine();
            char[] operators = { '+', '-', '*', '/' };
            int operatorIndex = inputExpression.IndexOfAny(operators);
            if (operatorIndex != -1)
            {
                char op = inputExpression[operatorIndex];
                string[] expression = inputExpression.Split(op);
                if (expression.Length == 2)
                {
                    string inputNumber1 = expression[0].Trim();
                    string inputNumber2 = expression[1].Trim();

                    bool isValidNumber1 = int.TryParse(inputNumber1, out int number1);
                    bool isValidNumber2 = int.TryParse(inputNumber2, out int number2);
                    if (!isValidNumber1 || !isValidNumber2)
                    {
                        Console.WriteLine("Invalid Expression format!, Valid format : 12 + 3");
                        return null;
                    }

                    return new MathematicalExpression(number1, number2, op);
                }
            }

            return null;
        }
    }
}
