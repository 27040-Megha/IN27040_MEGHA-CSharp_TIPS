using Multithreading;

namespace Assignments
{
    /// <summary>
    /// Main class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Creates 3 threads to perform 3 operations concurrently, and wait using Thread.join() and then prints result to the console
        /// </summary>
        /// <param name="args">Arguments</param>
        public static void Main(string[] args)
        {
            int[] array = Enumerable.Range(1, 100).ToArray();
            int sum = 0, average = 0;
            var thread1 = new Thread(() => sum = CalculateSum(array));
            var thread2 = new Thread(() => SortArray(array));
            var thread3 = new Thread(() => average = FindAverage(array));
            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread1.Join();
            thread2.Join();
            thread3.Join();
            DisplayResult(sum, average, array);
        }

        private static void DisplayResult(int sum, int average, int[] array)
        {
            Console.WriteLine(string.Format(DisplayResource.Result, sum, average));
            DisplayArray(array);
        }

        private static int CalculateSum(int[] array)
        {
            return array.Sum();
        }

        private static void SortArray(int[] array)
        {
            Array.Sort(array);
        }

        private static void DisplayArray(int[] array)
        {
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }

        private static int FindAverage(int[] array)
        {
            return array.Sum() / array.Length;
        }
    }
}