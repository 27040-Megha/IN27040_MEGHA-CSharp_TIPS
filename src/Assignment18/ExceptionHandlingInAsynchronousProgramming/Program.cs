namespace Assignments
{
    /// <summary>
    /// Main class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Calls TaskMethod and VoidMethod within separate try-catch block to observe how exception is handled
        /// </summary>
        /// <param name="args">Arguments</param>
        /// <returns>Asynchronous Task object</returns>
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Application crashes when exception occurs in Async Void methods");
            //try
            //{
            //    VoidMethod();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Exception Caught In VoidMethod: {ex.Message}");
            //}

            try
            {
                await TaskMethod();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Caught In TaskMethod: {ex.Message}");
            }
        }

        private static async void VoidMethod()
        {
            await Task.Delay(100);
            throw new Exception();
        }

        private static async Task TaskMethod()
        {
            await Task.Delay(100);
            throw new Exception();
        }
    }
}