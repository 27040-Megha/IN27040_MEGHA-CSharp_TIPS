using System.Text.Json;

namespace Assignments
{
    /// <summary>
    /// Main class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of Application
        /// </summary>
        /// <param name="args">Arguments</param>
        /// <returns>Asynchronous task object</returns>
        public static async Task Main(string[] args)
        {
            try
            {
                var totalPairs = await MethodC();
                Console.WriteLine($"Total key-value pairs found in the resource: {totalPairs}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}");
            }
        }

        private static async Task<int> MethodA()
        {
            int result = await Task.Run(() =>
            {
                int sum = 0;
                for (int i = 0; i < 1000000; i++)
                {
                    sum += i;
                }

                return sum;
            });
            return result % 100;
        }

        private static async Task<string> MethodB()
        {
            int resourceId = await MethodA();
            var client = new HttpClient();
            return await client.GetStringAsync($"https://typicode.com{resourceId}");
        }

        private static async Task<int> MethodC()
        {
            string data = await MethodB();
            var jsonData = JsonSerializer.Deserialize<Dictionary<string, object>>(data);
            int count = 0;
            foreach (var item in jsonData)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
                count++;
            }

            return count;
        }
    }
}