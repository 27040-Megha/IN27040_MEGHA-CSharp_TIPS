using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.ApplicationLayer.Service
{
    public class ArrayService
    {
        public int FindSecondHighestNumber(int[] arrayOfIntegers)
        {
            var sortedArray = arrayOfIntegers.OrderByDescending(number => number).ToArray();
            return sortedArray[1];
        }

        //public List<(int, int)> FindTargetSum(int targetSum)
        //{

        //}
    }
}
