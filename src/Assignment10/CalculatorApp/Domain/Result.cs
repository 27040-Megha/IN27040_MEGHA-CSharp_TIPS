using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Domain
{
    public class Result
    {
        public Result(bool isSuccess, string message)
        {
            this.IsSuccess = isSuccess;
            this.Message = message;
        }

        public Result(bool isSuccess, string message, int resultData)
            : this(isSuccess, message)
        {
            this.ResultData = resultData;
        }

        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public int ResultData { get; set; }
    }
}
