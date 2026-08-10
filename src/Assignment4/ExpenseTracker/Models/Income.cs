using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ExpenseTracker.Models
{
    /// <summary>
    /// Implements "IFinancialRecord" and defines string source property additionally
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
        public Income(Guid transactionID, decimal amount, DateOnly date, string description, string source)
        {
            this.TransactionID = transactionID;
            this.Amount = amount;
            this.Date = date;
            this.Description = description;
            this.Source = source;
        }

        /// <summary>
        /// Gets the unique TransactionID of the Income.
        /// </summary>
        /// <value>
        /// TransactionID
        /// </value>
        public Guid TransactionID { get; init; }

        /// <summary>
        /// Gets or sets the Income Amount
        /// </summary>
        /// <value>
        /// Income Amount
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
        /// Gets or sets the description of the Income
        /// </summary>
        /// <value>
        /// Description
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Source of Income
        /// </summary>
        /// <value>
        /// Category
        /// </value>
        public string Source { get; set; }
    }
}
