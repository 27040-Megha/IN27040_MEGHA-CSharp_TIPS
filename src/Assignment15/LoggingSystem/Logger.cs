namespace LoggingSystem
{
    /// <summary>
    /// Class contains method to log error messages to same file using lock mechanism
    /// </summary>
    public class Logger
    {
        private static readonly object _fileLock = new ();

        private static string _logFilePath = "log.txt";

        /// <summary>
        /// Multiple users (task threads) logs to the same file
        /// Provides threadsafe logging using lock mechanism
        /// </summary>
        /// <param name="errorMessage">Error message to be logged</param>
        public static void LogError(string errorMessage)
        {
            lock (_fileLock)
            {
                using (var writer = new StreamWriter(_logFilePath, append: true ))
                {
                    writer.WriteLine(errorMessage);
                }
            }
        }
    }
}
