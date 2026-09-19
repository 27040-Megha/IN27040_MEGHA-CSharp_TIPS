using System.Diagnostics;

namespace LoggingSystem
{
    /// <summary>
    /// Contains method to create multiple tasks and call Logger methods
    /// </summary>
    public class PerformanceTester
    {
        /// <summary>
        /// Create 100 tasks (Simulating 100 users logging errors at the same time)
        /// Each task runs Logger.LogError() which logs errors to the same file
        /// </summary>
        /// <returns>Task object - Asynchronous Operation result</returns>
        public static async Task RunLoadForSameFileLogger()
        {
            var tasks = new Task[100];
            for (int i = 0; i < 100; i++)
            {
                string currentUserId = i.ToString();
                tasks[i] = Task.Run(() => Logger.LogError($"ERROR:USERID{currentUserId} Don't have access! "));
            }

            await Task.WhenAll(tasks);
        }

        /// <summary>
        /// Create 100 tasks (Simulating 100 users logging errors at the same time)
        /// Each task runs IndependentLogger.LogErrorAsync() which logs errors to independent files
        /// </summary>
        /// <returns>Task object - Asynchronous Operation result</returns>
        public static async Task RunLoadForIndependentLogger()
        {
            var tasks = new Task[100];
            for (int i = 0; i < 100; i++)
            {
                string currentUserId = i.ToString();
                tasks[i] = Task.Run(async () => await IndependentLogger.LogErrorAsync(currentUserId, $"ERROR:USERID{currentUserId} Don't have access! "));
            }

            await Task.WhenAll(tasks);
        }
    }
}
