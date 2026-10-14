namespace UtilityApp
{
    /// <summary>
    /// Result Object to return Success Outcome
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class.
        /// </summary>
        /// <param name="isSuccess">returns true if success, otherwise false</param>
        public Result(bool isSuccess)
        {
            this.IsSuccess = isSuccess;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class.
        /// </summary>
        /// <param name="isSuccess">returns true if success, otherwise false</param>
        /// <param name="resultData">Integer Result of a function</param>
        public Result(bool isSuccess, int resultData)
        {
            this.IsSuccess = isSuccess;
            this.ResultData = resultData;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the result is true or false
        /// </summary>
        /// <value>
        /// true, if operation is success otherwise false
        /// </value>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Gets or sets a value indicating result of the operation
        /// </summary>
        /// <value>
        /// Integer result of the arithmetic operation
        /// </value>
        public int ResultData { get; set; }
    }
}
