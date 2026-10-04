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
        /// <returns>Asynchronous Task Object</returns>
        public static async Task Main(string[] args)
        {
            try
            {
                int result = await MethodB();
                Console.WriteLine($"Result is: {result}");
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

            await Task.Delay(1500).ConfigureAwait(false);
            return result;
        }

        private static async Task<int> MethodB()
        {
            Console.WriteLine($"Thread ID before awaiting MethodA: {Thread.CurrentThread.ManagedThreadId}");
            int result = await MethodA();
            Console.WriteLine($"Thread ID after awaiting MethodA: {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 0; i < 1000000; i++)
            {
                result -= i;
            }

            return result;
        }
    }
}