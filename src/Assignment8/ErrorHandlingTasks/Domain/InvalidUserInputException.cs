using System;

namespace ErrorHandlingTasks.Domain
{
    /// <summary>
    /// Custom Exception- InvalidUserInputException that inherits from Exception class.
    /// The Exception will be used in InputValidator class, that checks whether user enters a valid integer input.
    /// If User enters an invalid input, FormatException will be caught which will throw the new InvalidUserInputException with a custom message
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
