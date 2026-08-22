using System;

namespace ErrorHandlingTasks.Domain
{
    /// <summary>
    /// Custom Exception- InvalidUserInputException that inherits from Exception class
    /// </summary>
    public class InvalidUserInputException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidUserInputException"/> class.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Exception that was caught initially, which threw this custom exception</param>
        public InvalidUserInputException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
