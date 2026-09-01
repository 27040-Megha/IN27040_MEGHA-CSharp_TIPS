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

        public static bool Divide(int dividend, int divisor, out int quotient)
        {
            if (divisor == 0)
            {
                quotient = -1;
                return false;
            }

            quotient = dividend / divisor;
            return true;
        }
    }
}
