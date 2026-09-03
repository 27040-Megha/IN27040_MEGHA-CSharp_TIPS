using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.PresentationLayer
{
    /// <summary>
    /// Result Object
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class.
        /// </summary>
        /// <param name="isSuccess">true if input is valid, otherwise false</param>
        /// <param name="number">Valid Integer</param>
        public Result(bool isSuccess, int number)
        {
            this.IsSuccess = isSuccess;
            this.Number = number;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the input is valid or not
        /// </summary>
        /// <value>
        /// true, if validation is success otherwise false
        /// </value>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Gets or sets a value of valid number
        /// </summary>
        /// <value>
        /// Valid Integer
        /// </value>
        public int Number { get; set; }
    }
}
