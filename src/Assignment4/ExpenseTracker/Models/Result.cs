using System;

namespace ExpenseTracker.Models
{
    public class Result
    {
        public Result(bool isSuccess, string message)
        {
            this.IsSuccess = isSuccess;
            this.Message = message;
            this.AmountData = 0;
            this.DateData = default;
            this.StringData = string.Empty;
            this.GuidData = Guid.Empty;
        }

        public Result(bool isSuccess, string message, decimal amountData)
            : this(isSuccess, message)
        {
            this.AmountData = amountData;
        }

        public Result(bool isSuccess, string message, DateOnly dateData)
            : this(isSuccess, message)
        {
            this.DateData = dateData;
        }

        public Result(bool isSuccess, string message, string stringData)
            : this(isSuccess, message)
        {
            this.StringData = stringData;
        }

        public Result(bool isSuccess, string message, Guid guidData)
            : this(isSuccess, message)
        {
            this.GuidData = guidData;
        }

        public bool IsSuccess { get; init; }

        public string Message { get; init; }

        public decimal AmountData { get; init; }

        public DateOnly DateData { get; init; }

        public string StringData { get; init; }

        public Guid GuidData { get; init; }
    }
}
