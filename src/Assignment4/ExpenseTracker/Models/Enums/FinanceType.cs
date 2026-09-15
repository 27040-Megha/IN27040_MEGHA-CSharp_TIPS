using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Models.Enums
{
    /// <summary>
    /// Finance Type as Income or Expense
    /// </summary>
    public enum FinanceType
    {
        /// <summary>
        /// Unknown Finance Type
        /// </summary>
        Unknown = -1,

        /// <summary>
        /// Income Finance Type
        /// </summary>
        Income = 1,

        /// <summary>
        /// Expense Finance Type
        /// </summary>
        Expense = 2,
    }
}
