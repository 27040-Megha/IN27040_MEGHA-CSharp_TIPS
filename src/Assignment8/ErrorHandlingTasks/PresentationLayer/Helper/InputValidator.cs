using System;
using ErrorHandlingTasks.Domain;

namespace ErrorHandlingTasks.PresentationLayer.Helper
{
    public static class InputValidator
    {
        public static int ValidateNumber(string number)
        {
            try
            {
                return int.Parse(number);
            }
            catch (FormatException ex)
            {
                throw new InvalidUserInputException($"Input should be a valid Integer", ex);
            }
        }
    }
}
