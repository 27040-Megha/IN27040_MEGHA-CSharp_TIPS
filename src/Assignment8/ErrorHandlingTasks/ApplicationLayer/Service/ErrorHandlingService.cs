using System;

namespace ErrorHandlingTasks.ApplicationLayer.Service
{
    /// <summary>
    /// Contains Business Logic for Methods - Divide and GetFifthElementFromArray
    /// </summary>
    public class ErrorHandlingService
    {
        /// <summary>
        /// Returns the division result, if divisor is zero, DivideByZeroException will be thrown that will be catched in the Presentation layer.
        /// </summary>
        /// <param name="dividend">Dividened</param>
        /// <param name="divisor">Divisor</param>
        /// <returns>Division result</returns>
        public int Divide(int dividend, int divisor)
        {
            return dividend / divisor;
        }

        /// <summary>
        /// The try block attempts to return the fifth element of the array. If an IndexOutOfRangeException occurs, it is caught, and an InvalidOperationException with custom message will be thrown.
        /// </summary>
        /// <param name="array">Integer array</param>
        /// <returns>Fifth element of Array</returns>
        /// <exception cref="InvalidOperationException">InvalidOperationException will be thrown</exception>
        public int GetFifthElementFromArray(int[] array)
        {
            try
            {
                return array[4];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException("Invalid Operation Exception");
            }
        }
    }
}
