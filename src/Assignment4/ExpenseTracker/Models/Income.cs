using System;

namespace ExpenseTracker.Models
{
    /// <summary>
    ///  Inherits FinancialRecord and has additional property Source
    /// </summary>
    public class Income : FinancialRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Income"/> class.
        /// </summary>
        /// <param name="transactionID">Transaction ID</param>
        /// <param name="amount">Income amount</param>
        /// <param name="date">Date</param>
        /// <param name="description">Note or Description of Income</param>
        /// <param name="source">Source of Income</param>
        public Income(Guid transactionID, decimal amount, DateTime date, string description, string source)
            : base(transactionID, amount, date, description)
        {
            this.Source = source;
        }

        /// <summary>
        /// Gets or sets the Source of Income
        /// </summary>
        /// <value>
        /// Category
        /// </value>
        public string Source { get; set; }
    }
}
