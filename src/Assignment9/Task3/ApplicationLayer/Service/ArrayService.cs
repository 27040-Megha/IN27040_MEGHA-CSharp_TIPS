using System.Collections.Generic;
using System.Linq;

namespace Task3.ApplicationLayer.Service
{
    /// <summary>
    /// Businness logic to perform Array Operations
    /// </summary>
    public class ArrayService
    {
        /// <summary>
        /// Returns Second Highest Number
        /// </summary>
        /// <param name="arrayOfIntegers">Array of integers</param>
        /// <returns>Second Highest Number</returns>
        public int FindSecondHighestNumber(int[] arrayOfIntegers)
        {
            var sortedArray = arrayOfIntegers.OrderByDescending(number => number).ToArray();
            return sortedArray[1];
        }

        /// <summary>
        /// Returns All unique pairs of numbers in the array that add up to a specified target.
        /// </summary>
        /// <param name="arrayOfIntegers">Array of integers</param>
        /// <param name="targetSum">Target Sum</param>
        /// <returns>All unique pairs of numbers in the array that add up to a specified target</returns>
        public List<(int, int)> FindTargetSum(int[] arrayOfIntegers, int targetSum)
        {
            return arrayOfIntegers
                .SelectMany((element1, index) => arrayOfIntegers.Skip(index + 1).Select(element2 => new { element1, element2 })
                .Where((pair) => pair.element1 + pair.element2 == targetSum)
                .Select((pair) => (pair.element1, pair.element2))
                .Distinct())
                .ToList();
        }
    }
}
