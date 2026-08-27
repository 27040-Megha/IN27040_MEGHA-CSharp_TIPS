using System.Collections.Generic;
using System.Linq;

namespace Task3.ApplicationLayer.Service
{
    public class ArrayService
    {
        public int FindSecondHighestNumber(int[] arrayOfIntegers)
        {
            var sortedArray = arrayOfIntegers.OrderByDescending(number => number).ToArray();
            return sortedArray[1];
        }

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
