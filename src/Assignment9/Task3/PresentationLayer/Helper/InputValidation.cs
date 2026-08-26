using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.PresentationLayer.Helper
{
    public static class InputValidation
    {
        public static Result ValidateInteger(string input)
        {
            int number;
            if (!int.TryParse(input, out number))
            {
                return new Result(false, -1);
            }

            return new Result(true, number);
        }
    }
}
