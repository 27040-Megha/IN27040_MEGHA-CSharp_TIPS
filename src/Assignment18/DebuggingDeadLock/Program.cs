namespace Assignments
{
    /// <summary>
    /// Main class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of application
        /// </summary>
        /// <param name="args">Arguments</param>
        /// <returns>Asynchronous task object</returns>
        public static async Task Main(string[] args)
        {
            try
            {
                await DeadlockMethod();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}");
            }
        }

        private static async Task DeadlockMethod()
        {
            var result = await SomeAsyncOperation();
            Console.WriteLine(result);
        }

        private static async Task<string> SomeAsyncOperation()
        {
            await Task.Delay(1000);
            return "Hello, World!";
        }
    }
}