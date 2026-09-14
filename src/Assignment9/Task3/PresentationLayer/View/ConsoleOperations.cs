using System;
using Task3.ApplicationLayer.Service;
using Task3.PresentationLayer.Helper;

namespace Task3.PresentationLayer.View
{
    /// <summary>
    /// Interacts with the user
    /// </summary>
    public class ConsoleOperations
    {
        private readonly ArrayService _arrayService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleOperations"/> class.
        /// </summary>
        /// <param name="arrayService">ArraysService object</param>
        public ConsoleOperations(ArrayService arrayService)
        {
            this._arrayService = arrayService;
        }

        /// <summary>
        /// Initial method
        /// </summary>
        public void Run()
        {
            Console.WriteLine("Enter Array Size: ");
            string arrSize = Console.ReadLine();
            var arraySizeResult = InputValidation.ValidateInteger(arrSize);
            if (!arraySizeResult.IsSuccess || arraySizeResult.Number <= 0)
            {
                this.WriteColorLine(DisplayResource.ErrorInvalidArraySize, ConsoleColor.Red);
                return;
            }

            int arraySize = arraySizeResult.Number;
            var arrayOfIntegers = this.GetArrayInput(arraySize);
            if (arrayOfIntegers == null)
            {
                return;
            }

            if (arraySize < 2)
            {
                this.WriteColorLine(DisplayResource.ErrorMinimumElements, ConsoleColor.Red);
                return;
            }

            this.DisplaySecondHighestValue(arrayOfIntegers);
            this.FindTargetSum(arrayOfIntegers);
        }

        private void WriteColorLine(string text, ConsoleColor colorChoice)
        {
            Console.ForegroundColor = colorChoice;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private void DisplaySecondHighestValue(int[] arrayOfIntegers)
        {
            int secondHighestNumber = this._arrayService.FindSecondHighestNumber(arrayOfIntegers);
            this.WriteColorLine(string.Format(DisplayResource.LabelSecondHighest, secondHighestNumber), ConsoleColor.Cyan);
        }

        private void FindTargetSum(int[] arrayOfIntegers)
        {
            Console.WriteLine(DisplayResource.PromptTargetSum);
            var numberResult = InputValidation.ValidateInteger(Console.ReadLine());
            if (!numberResult.IsSuccess)
            {
                this.WriteColorLine(DisplayResource.ErrorInvalidInteger, ConsoleColor.Red);
                return;
            }

            int targetSum = numberResult.Number;
            var uniquePairs = this._arrayService.FindTargetSum(arrayOfIntegers, targetSum);
            if (uniquePairs.Count == 0)
            {
                this.WriteColorLine(DisplayResource.ErrorNoPairsFound, ConsoleColor.Yellow);
                return;
            }

            Console.WriteLine(DisplayResource.LabelTargetSumPairs);
            foreach (var pair in uniquePairs)
            {
                Console.WriteLine(string.Format(DisplayResource.PairFormat, pair.Item1, pair.Item2));
            }
        }

        private int[] GetArrayInput(int arraySize)
        {
            var array = new int[arraySize];
            Console.WriteLine(DisplayResource.PromptArrayElements);
            for (int i = 0; i < arraySize; i++)
            {
                Console.WriteLine(string.Format(DisplayResource.GetArrayElement, (i + 1)));
                var numberResult = InputValidation.ValidateInteger(Console.ReadLine());
                if (!numberResult.IsSuccess)
                {
                    this.WriteColorLine(DisplayResource.ErrorInvalidInteger, ConsoleColor.Red);
                    return null;
                }

                array[i] = numberResult.Number;
            }

            return array;
        }
    }
}
