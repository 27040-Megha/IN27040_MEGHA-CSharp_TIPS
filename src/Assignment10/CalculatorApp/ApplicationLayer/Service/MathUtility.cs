using CalculatorApp.Domain;

namespace CalculatorApp.ApplicationLayer.Service
{
    /// <summary>
    /// Contains Add, Subtract, Multiply and Divide methods
    /// </summary>
    public static class MathUtility
    {
        /// <summary>
        /// Performs addition of two numbers
        /// </summary>
        /// <param name="number1">Input Number 1</param>
        /// <param name="number2">Input Number 2</param>
        /// <returns>Addition of two numbers</returns>
        public static int Add(int number1, int number2)
        {
            return number1 + number2;
        }

        /// <summary>
        /// Performs subtraction of two numbers
        /// </summary>
        /// <param name="number1">Input Number 1</param>
        /// <param name="number2">Input Number 2</param>
        /// <returns>Subtraction of two numbers</returns>
        public static int Subtract(int number1, int number2)
        {
            return number1 - number2;
        }

        /// <summary>
        /// Performs Multiplication of two numbers
        /// </summary>
        /// <param name="number1">Input Number 1</param>
        /// <param name="number2">Input Number 2</param>
        /// <returns>Multiplication of two numbers</returns>
        public static int Multiply(int number1, int number2)
        {
            return number1 * number2;
        }

        /// <summary>
        /// Performs Division of two numbers
        /// </summary>
        /// <param name="dividend">Dividend</param>
        /// <param name="divisor">Divisor</param>
        /// <returns>Returns false result if divisor is 0, otherwise true result with quotient</returns>
        public static Result Divide(int dividend, int divisor)
        {
            if (divisor == 0)
            {
                return new Result(false, "Divisor should not be 0!");
            }

            return new Result(true, "Division successful", dividend / divisor);
        }
    }
}
