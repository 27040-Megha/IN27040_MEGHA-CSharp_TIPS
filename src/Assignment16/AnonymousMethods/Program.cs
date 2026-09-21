using AnonymousMethods;

namespace Assignments
{
    /// <summary>
    /// Main class
    /// </summary>
    public class Program
    {
        private static void Main(string[] args)
        {
            int[] array = { 12, 3, 56, 14, 7, 82, 18, 2, 31 };
            SortInAscendingOrder(array);
            Console.WriteLine(DisplayResource.AscendingOrder);
            DisplayArray(array);
            SortInDescendingOrder(array);
            Console.WriteLine(DisplayResource.DescendingOrder);
            DisplayArray(array);
        }

        private static void DisplayArray(int[] array)
        {
            foreach (var number in array)
            {
                Console.WriteLine(number);
            }
        }

        private static void SortInAscendingOrder(int[] array)
        {
            Array.Sort(array, delegate(int firstNumber, int secondNumber)
            {
                return firstNumber.CompareTo(secondNumber);
            });
        }

        private static void SortInDescendingOrder(int[] array)
        {
            Array.Sort(array, delegate(int firstNumber, int secondNumber)
            {
                return secondNumber.CompareTo(firstNumber);
            });
        }
    }
}
