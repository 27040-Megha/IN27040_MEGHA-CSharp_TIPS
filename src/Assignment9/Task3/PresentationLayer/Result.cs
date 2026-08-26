using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.PresentationLayer
{
    public class Result
    {
        public Result(bool isSuccess, int number)
        {
            this.IsSuccess = isSuccess;
            this.Number = number;
        }

        public bool IsSuccess { get; set; }

        public int Number { get; set; }
    }
}
