using System;
using Task3.ApplicationLayer.Service;
using Task3.PresentationLayer.Helper;

namespace Task3.PresentationLayer.View
{
    public class ConsoleOperations
    {
        private readonly ArrayService _arrayService;

        public ConsoleOperations(ArrayService arrayService)
        {
            this._arrayService = arrayService;
        }

        public void Run()
        {
            Console.WriteLine("Enter Array Size: ");
            string arrSize = Console.ReadLine();
            var arraySizeResult = InputValidation.ValidateInteger(arrSize);
            int arraySize;
            if (!arraySizeResult.IsSuccess || !(arraySizeResult.Number > 0))
            {
                Console.WriteLine("Invalid Array Size! Array size must be a positive integer");
                return;
            }

            arraySize = arraySizeResult.Number;
            var arrayOfIntegers = this.GetArrayInput(arraySize);
            if (arrayOfIntegers == null)
            {
                return;
            }

            if (arraySize < 2)
            {
                Console.WriteLine("There must be atleast two elements to display the Second Highest Value!");
                return;
            }

            this.DisplaySecondHighestValue(arrayOfIntegers);
            this.FindTargetSum(arrayOfIntegers);
        }

        private void DisplaySecondHighestValue(int[] arrayOfIntegers)
        {
            int secondHighestNumber = this._arrayService.FindSecondHighestNumber(arrayOfIntegers);
            Console.WriteLine($"The Second Highest Value in the Array: {secondHighestNumber}");
        }

        private void FindTargetSum(int[] arrayOfIntegers)
        {
            Console.WriteLine("Enter the target Sum: ");
            var numberResult = InputValidation.ValidateInteger(Console.ReadLine());
            if (!numberResult.IsSuccess)
            {
                Console.WriteLine("Invalid Integer format!");
                return;
            }

            int targetSum = numberResult.Number;
            var uniquePairs = this._arrayService.FindTargetSum(arrayOfIntegers, targetSum);
            if (uniquePairs.Count == 0)
            {
                Console.WriteLine("No pairs found that adds upto the specified target");
                return;
            }

            Console.WriteLine("Target Sum Pairs: ");
            foreach (var pair in uniquePairs)
            {
                Console.WriteLine($"({pair.Item1}, {pair.Item2})");
            }
        }

        private int[] GetArrayInput(int arraySize)
        {
            var array = new int[arraySize];
            Console.WriteLine("Enter Array Elements: ");
            for (int i = 0; i < arraySize; i++)
            {
                var numberResult = InputValidation.ValidateInteger(Console.ReadLine());
                if (!numberResult.IsSuccess)
                {
                    Console.WriteLine("Invalid Integer format!");
                    return null;
                }

                array[i] = numberResult.Number;
            }

            return array;
        }
    }
}
