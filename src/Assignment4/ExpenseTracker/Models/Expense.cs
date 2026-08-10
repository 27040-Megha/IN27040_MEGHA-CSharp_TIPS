using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ExpenseTracker.Models
{
    /// <summary>
    /// Implements "IFinancialRecord" and defines string category property additionally
    /// </summary>
    public class Expense : FinancialRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Expense"/> class.
        /// </summary>
        /// <param name="transactionID">Transaction ID</param>
        /// <param name="amount">Expense amount</param>
        /// <param name="date">Date</param>
        /// <param name="description">Note or Description of expense</param>
        /// <param name="category">Category of Expense</param>
        public Expense(Guid transactionID, decimal amount, DateOnly date, string description, string category)
        {
            this.TransactionID = transactionID;
            this.Amount = amount;
            this.Date = date;
            this.Description = description;
            this.Category = category;
        }

        /// <summary>
        /// Gets the unique TransactionID of the Expense.
        /// </summary>
        /// <value>
        /// TransactionID
        /// </value>
        public Guid TransactionID { get; init; }

        /// <summary>
        /// Gets or sets the Expense Amount
        /// </summary>
        /// <value>
        /// Expense Amount
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
        /// Gets or sets the description of the Expense
        /// </summary>
        /// <value>
        /// Description
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Category of Expense
        /// </summary>
        /// <value>
        /// Category
        /// </value>
        public string Category { get; set; }
    }
}
