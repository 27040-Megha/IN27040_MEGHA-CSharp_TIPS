using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
