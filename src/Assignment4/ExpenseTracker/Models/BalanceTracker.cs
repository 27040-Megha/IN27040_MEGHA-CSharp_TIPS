using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Models
{
    /// <summary>
    /// Manage the global balance, total income and total expense accurately
    /// </summary>
    public class BalanceTracker
    {
        /// <summary>
        /// Gets the Balance Amount
        /// </summary>
        /// <value>
        /// Balance Amount
        /// </value>
        public decimal BalanceAmount => this.TotalIncome - this.TotalExpense;

        /// <summary>
        /// Gets or sets the Total Income
        /// </summary>
        /// <value>
        /// Total Income
        /// </value>
        public decimal TotalIncome { get; set; }

        /// <summary>
        /// Gets or sets the Total Expense
        /// </summary>
        /// <value>
        /// Total Expense
        /// </value>
        public decimal TotalExpense { get; set; }
    }
}
