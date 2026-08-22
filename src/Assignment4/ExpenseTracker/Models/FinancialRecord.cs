using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Models
{
    /// <summary>
    /// Abstract class for Financial Record
    /// </summary>
    public abstract class FinancialRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FinancialRecord"/> class.
        /// </summary>
        /// <param name="transactionID">Transaction ID</param>
        /// <param name="amount">Expense amount</param>
        /// <param name="date">Date</param>
        /// <param name="description">Note or Description of expense</param>
        protected FinancialRecord(Guid transactionID, decimal amount, DateTime date, string description)
        {
            this.TransactionID = transactionID;
            this.Amount = amount;
            this.Date = date;
            this.Description = description;
        }

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
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the description of the transaction.
        /// </summary>
        /// <value>
        /// Description
        /// </value>
        public string Description { get; set; }
    }
}
