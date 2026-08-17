using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorHandlingTasks.ApplicationLayer.Service
{
    public class ErrorHandlingService
    {
        public int Divide(int dividend, int divisor)
        {
            try
            {
                return dividend / divisor;
            }
            catch (DivideByZeroException ex)
            {
                throw;
            }
        }

        public int GetFifthElementFromArray(int[] array)
        {
            try
            {
                return array[4];
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
