using System.Diagnostics;

namespace Assignments
{
    /// <summary>
    /// Main class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Declares an array of integers and compares the difference between time taken for execution between Calculating Square of array elements Sequentially vs Parallely
        /// </summary>
        /// <param name="args">Arguments</param>
        public static void Main(string[] args)
        {
            int[] array = Enumerable.Range(1, 10000).ToArray();
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            CalculateSquareParallelly(array);
            stopwatch.Stop();
            Console.WriteLine($"Time taken to calculate square of array elements Parallely: {stopwatch.ElapsedMilliseconds} ms");
            array = Enumerable.Range(1, 10000).ToArray();
            stopwatch.Restart();
            CalculateSquareSequentially(array);
            stopwatch.Stop();
            Console.WriteLine($"Time taken to calculate square of array elements Sequentially: {stopwatch.ElapsedMilliseconds} ms");
            DisplayArray(array);
        }

        private static void DisplayArray(int[] array)
        {
            Console.WriteLine("Square of Array Numbers: ");
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }

        private static void CalculateSquareParallelly(int[] array)
        {
            Parallel.For(0, array.Length, index =>
            {
                array[index] = array[index] * array[index];
            });
        }

        private static void CalculateSquareSequentially(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array[i] * array[i];
            }
        }
    }
}