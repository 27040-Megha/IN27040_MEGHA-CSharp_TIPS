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
                Task.Run(() => InteractWithUser());
                string downloadedData = await DownloadDataAsync();
                Console.SetCursorPosition(12, 13);
                Console.WriteLine($"Dowloaded Data: \n{downloadedData}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}");
            }
        }

        private static async Task<string> DownloadDataAsync()
        {
            string responseBody = await Client.GetStringAsync("https://meghaeg.vercel.app");
            await Task.Delay(3000);
            return responseBody;
        }

        private static void InteractWithUser()
        {
            Console.WriteLine("Hi user");
            Console.ReadLine();
            Task.Delay(3000);
        }
    }
}