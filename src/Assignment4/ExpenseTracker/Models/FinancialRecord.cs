using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Models
{
    /// <summary>
    /// Interface for Financial Record
    /// </summary>
    public abstract class FinancialRecord
    {
        /// <summary>
        /// Gets the unique TransactionID of the record.
        /// </summary>
        /// <value>
        /// TransactionID
        /// </value>
        public Guid TransactionID { get; init; }

        /// <summary>
        /// Gets or sets the record.Amount
        /// </summary>
        /// <value>
        /// Amount
        /// </value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the Date of Transaction
        /// </summary>
        /// <value>
        /// Date
        /// </value>
        public DateOnly Date { get; set; }

        /// <summary>
        /// Gets or sets the description of the transaction.
        /// </summary>
        /// <value>
        /// Description
        /// </value>
        public string Description { get; set; }
    }
}
