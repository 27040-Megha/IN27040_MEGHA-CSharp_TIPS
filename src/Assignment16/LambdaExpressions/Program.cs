namespace Assignments
{
    /// <summary>
    /// Main class
    /// </summary>
    public class Program
    {
        private static void Main(string[] args)
        {
            var listOfIntgers = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
            var evenNumbers = listOfIntgers.Where((int number) => number % 2 == 0).ToList();

        }

        private static void DisplayList(List<int> list)
        {
            foreach (var number in list)
            {
                Console.WriteLine(number);
            }
        }
    }
}