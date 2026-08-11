using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ExpenseTracker.Models
{
    /// <summary>
<<<<<<< HEAD
    ///  Inherits FinancialRecord and has additional property Source
=======
    /// Inherits FinancialRecord and has additional Source property
>>>>>>> feature-user-27040-Megha-Assignments-Assignment4-ExpenseTracker
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
