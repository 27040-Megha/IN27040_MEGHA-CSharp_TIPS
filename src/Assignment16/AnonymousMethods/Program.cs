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
            Array.Sort(array, delegate(int a, int b)
            {
                return a.CompareTo(b);
            });

            Console.WriteLine(DisplayResource.AscendingOrder);
            foreach (var number in array)
            {
                Console.WriteLine(number);
            }

            Array.Sort(array, delegate(int a, int b)
            {
                return b.CompareTo(a);
            });

            Console.WriteLine(DisplayResource.DescendingOrder);
            foreach (var number in array)
            {
                Console.WriteLine(number);
            }
        }
    }
}
