using System;

namespace ErrorHandlingTasks.ApplicationLayer.Service
{
    /// <summary>
    /// Contains Business Logic for Methods - Divide and GetFifthElementFromArray
    /// </summary>
    public class ErrorHandlingService
    {
        /// <summary>
        /// Inside try block returns Division result, if divisor is 0, DivideByZeroException will be catched and the same exception will be rethrown.
        /// </summary>
        /// <param name="dividend">Dividened</param>
        /// <param name="divisor">Divisor</param>
        /// <returns>Division result</returns>
        public int Divide(int dividend, int divisor)
        {
            try
            {
                return dividend / divisor;
            }
            catch (DivideByZeroException ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Inside try block returns the fifth element of the array, IndexOutOfRangeException will be catched and different exception InvalidOperationException is thrown.
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
            catch (IndexOutOfRangeException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
