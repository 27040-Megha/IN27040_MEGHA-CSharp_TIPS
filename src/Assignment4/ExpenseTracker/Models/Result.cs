using System;

namespace ExpenseTracker.Models
{
    /// <summary>
    /// Result Object to return Success Outcome
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class.
        /// </summary>
        /// <param name="isSuccess">true - Operation Sucess, false - Operation fail</param>
        /// <param name="message">Success/Failure Message</param>
        public Result(bool isSuccess, string message)
        {
            this.IsSuccess = isSuccess;
            this.Message = message;
            this.AmountData = 0;
            this.DateData = default;
            this.StringData = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class.
        /// </summary>
        /// <param name="isSuccess">true - Operation Sucess, false - Operation fail</param>
        /// <param name="message">Success/Failure Message</param>
        /// <param name="amountData">Amount of Financial Record entered by user</param>
        public Result(bool isSuccess, string message, decimal amountData)
            : this(isSuccess, message)
        {
            this.AmountData = amountData;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class.
        /// </summary>
        /// <param name="isSuccess">true - Operation Sucess, false - Operation fail</param>
        /// <param name="message">Success/Failure Message</param>
        /// <param name="dateData">Date of transaction entered by user</param>
        public Result(bool isSuccess, string message, DateTime dateData)
            : this(isSuccess, message)
        {
            this.DateData = dateData;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class.
        /// </summary>
        /// <param name="isSuccess">true - Operation Sucess, false - Operation fail</param>
        /// <param name="message">Success/Failure Message</param>
        /// <param name="stringData">String (Description/Category of expense/Source of Income) entered by User</param>
        public Result(bool isSuccess, string message, string stringData)
            : this(isSuccess, message)
        {
            this.StringData = stringData;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class.
        /// </summary>
        /// <param name="amount">Amount of Financial Record entered by user</param>
        /// <param name="dateData">Date of transaction entered by user</param>
        /// <param name="stringData">String (Description/Category of expense/Source of Income) entered by User</param>
        public Result(decimal amount, DateTime dateData, string stringData)
        {
            this.AmountData = amount;
            this.DateData = dateData;
            this.StringData = stringData;
        }

        /// <summary>
        /// Gets a value indicating whether operation is success
        /// </summary>
        /// <value>
        /// true/false
        /// </value>
        public bool IsSuccess { get; init; }

        /// <summary>
        /// Gets the Message
        /// </summary>
        /// <value>
        /// Success/Failure Message
        /// </value>
        public string Message { get; init; }

        /// <summary>
        /// Gets the Amount of the transaction
        /// </summary>
        /// <value>
        /// Amount
        /// </value>
        public decimal AmountData { get; init; }

        /// <summary>
        /// Gets the Transaction Date
        /// </summary>
        /// <value>
        /// Date of transaction
        /// </value>
        public DateTime DateData { get; init; }

        /// <summary>
        /// Gets the string data
        /// </summary>
        /// <value>
        /// Description/Category of expense/Source of Income
        /// </value>
        public string StringData { get; init; }
    }
}
