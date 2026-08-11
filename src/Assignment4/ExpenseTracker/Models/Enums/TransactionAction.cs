using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Models.Enums
{
    /// <summary>
    /// Transaction Action
    /// </summary>
    public enum TransactionAction
    {
        /// <summary>
        /// Added Income/Expense Record
        /// </summary>
        Added,

        /// <summary>
        /// Updated Income/Expense Record
        /// </summary>
        Updated,

        /// <summary>
        /// Deleted Income/Expense Record
        /// </summary>
        Deleted,
    }
}
