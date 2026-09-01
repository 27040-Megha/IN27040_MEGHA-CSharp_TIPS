using CalculatorApp.Domain;

namespace CalculatorApp.ApplicationLayer.Service
{
    public static class MathUtility
    {
        public static int Add(int number1, int number2)
        {
            return number1 + number2;
        }

        public static int Subtract(int number1, int number2)
        {
            return number1 - number2;
        }

        public static int Multiply(int number1, int number2)
        {
            return number1 * number2;
        }

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
