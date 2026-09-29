using System;
using System.Net.Http;

namespace Assignments
{
    /// <summary>
    /// Main class
    /// </summary>
    public class Program
    {
        private static readonly HttpClient Client = new ();

        /// <summary>
        /// Downloads data from URI using HttpClient class and displays it to user
        /// </summary>
        /// <param name="args">Arguments</param>
        /// <returns>Asynchronous operation task object</returns>
        public static async Task Main(string[] args)
        {
            try
            {
                var downloadTask = await DownloadDataAsync();
                Console.WriteLine($"Dowloaded Data: \n{downloadTask}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}");
            }
        }

        private static async Task<string> DownloadDataAsync()
        {
            string responseBody = await Client.GetStringAsync("https://www.geeksforgeeks.org/c-sharp/async-and-await-in-c-sharp/");
            return responseBody;
        }
    }
}