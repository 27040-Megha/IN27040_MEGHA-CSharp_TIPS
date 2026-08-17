using System;

namespace ErrorHandlingTasks.Domain
{
    public class InvalidUserInputException : Exception
    {
        public InvalidUserInputException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
