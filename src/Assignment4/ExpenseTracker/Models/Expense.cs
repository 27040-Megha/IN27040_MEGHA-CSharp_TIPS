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
        public Expense(Guid transactionID, decimal amount, DateTime date, string description, string category)
            : base(transactionID, amount, date, description)
        {
            this.Category = category;
        }

        /// <summary>
        /// Gets or sets the Category of Expense
        /// </summary>
        /// <value>
        /// Category
        /// </value>
        public string Category { get; set; }
    }
}
