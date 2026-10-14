using UtilityApp;

namespace MathApp
{
    /// <summary>
    /// Implements IMathUtility and provides defintion for the abstract methods
    /// </summary>
    public class MathUtility : IMathUtility
    {
        /// <summary>
        /// Returns the sum of two integer values
        /// </summary>
        /// <param name="value1">First Number</param>
        /// <param name="value2">Second Number</param>
        /// <returns>Sum of two numbers</returns>
        public int Add(int value1, int value2)
        {
            return value1 + value2;
        }

        /// <summary>
        /// Returns the Divsion result of two integer values
        /// </summary>
        /// <param name="value1">First Number</param>
        /// <param name="value2">Second Number</param>
        /// <returns>Division result of two numbers</returns>
        public Result Divide(int value1, int value2)
        {
            if (value2 == 0)
            {
                return new Result(false);
            }

            return new Result(true, value1 / value2);
        }

        /// <summary>
        /// Returns the product of two integer values
        /// </summary>
        /// <param name="value1">First Number</param>
        /// <param name="value2">Second Number</param>
        /// <returns>Product of two numbers</returns>
        public int Multiply(int value1, int value2)
        {
            return value1 * value2;
        }

        /// <summary>
        /// Returns the difference between two integer values
        /// </summary>
        /// <param name="value1">First Number</param>
        /// <param name="value2">Second Number</param>
        /// <returns>Difference of two numbers</returns>
        public int Subtract(int value1, int value2)
        {
            return value1 - value2;
        }
    }
}
