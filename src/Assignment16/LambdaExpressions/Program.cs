using LambdaExpressions;

namespace Assignments
{
    /// <summary>
    /// Main class
    /// </summary>
    public class Program
    {
        private static void Main(string[] args)
        {
            var listOfIntegers = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
            DisplayList(DisplayResource.ListOfIntegers, listOfIntegers);
            var oddNumbers = FilterOddNumbers(listOfIntegers);
            DisplayList(DisplayResource.OddNumbers, oddNumbers);
            var squaresOfFilteredNumbers = FindSquare(oddNumbers);
            DisplayList(DisplayResource.Squares, squaresOfFilteredNumbers);
        }

        private static void DisplayList(string description, List<int> list)
        {
            Console.WriteLine(description);
            foreach (var number in list)
            {
                Console.WriteLine(number);
            }
        }

        private static List<int> FilterOddNumbers(List<int> listOfIntegers)
        {
            return listOfIntegers.Where((int number) => number % 2 != 0).ToList();
        }

        private static List<int> FindSquare(List<int> listOfIntegers)
        {
            return listOfIntegers.Select((int number) => number * number).ToList();
        }
    }
}
