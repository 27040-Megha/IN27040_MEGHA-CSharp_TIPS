namespace CalculatorApp.Domain
{
    /// <summary>
    /// Result Object
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class.
        /// </summary>
        /// <param name="isSuccess">true if operation success, otherwise false</param>
        /// <param name="message">Result Message</param>
        public Result(bool isSuccess, string message)
        {
            this.IsSuccess = isSuccess;
            this.Message = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class.
        /// </summary>
        /// <param name="isSuccess">true if operation success, otherwise false</param>
        /// <param name="message">Result Message</param>
        /// <param name="resultData">Result of Arithmetic Operation</param>
        public Result(bool isSuccess, string message, int resultData)
            : this(isSuccess, message)
        {
            this.ResultData = resultData;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the input is valid or not
        /// </summary>
        /// <value>
        /// true, if validation is success otherwise false
        /// </value>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Gets or sets the Message
        /// </summary>
        /// <value>
        /// Success/Failure Message
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets a result data
        /// </summary>
        /// <value>
        /// Result of Arithmetic Operation
        /// </value>
        public int ResultData { get; set; }
    }
}
