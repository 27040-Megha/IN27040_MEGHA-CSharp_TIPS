using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.PresentationLayer.Helper
{
    /// <summary>
    /// Input Validator class
    /// </summary>
    public static class InputValidation
    {
        /// <summary>
        /// Validates String
        /// </summary>
        /// <param name="input">Input String to be validated</param>
        /// <returns>false if string is null or empty, otherwise true</returns>
        public static bool ValidateString(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            return true;
        }
    }
}
