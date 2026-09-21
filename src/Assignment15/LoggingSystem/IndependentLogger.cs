namespace LoggingSystem
{
    /// <summary>
    /// Class contains method to log error messages to independent files
    /// </summary>
    public class IndependentLogger
    {
        /// <summary>
        /// For each user, the error message will be logged to separate files
        /// </summary>
        /// <param name="userID">UserId to identify user(File will be created or opened for appending using user id)</param>
        /// <param name="errorMessage">Error message to be logged</param>
        /// <returns>Task object - Asynchronous Operation result</returns>
        public static async Task LogErrorAsync(string userID, string errorMessage)
        {
            string logFile = $"User{userID}log.txt";
            using (var writer = new StreamWriter(logFile, append: true))
            {
                await writer.WriteLineAsync(errorMessage);
            }
        }
    }
}
