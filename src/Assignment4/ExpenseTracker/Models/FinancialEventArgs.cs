using System;
using ExpenseTracker.Models.Enums;

namespace ExpenseTracker.Models
{
    /// <summary>
    /// Data Class that holds Transaction Action(Add, Update, Delete) and IFinancial Records
    /// </summary>
    public class FinancialEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FinancialEventArgs"/> class.
        /// </summary>
        /// <param name="action">Transaction Action(Added, Deleted)</param>
        /// <param name="currentRecord">Record that was Added/Deleted</param>
        public FinancialEventArgs(TransactionAction action, FinancialRecord currentRecord)
        {
            this.Action = action;
            this.CurrentRecord = currentRecord;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FinancialEventArgs"/> class.
        /// </summary>
        /// <param name="action">Transaction Action(Updated)</param>
        /// <param name="currentRecord">New Updated Record</param>
        /// <param name="oldAmount">Old amount that has to be subtracted from the net balance</param>
        public FinancialEventArgs(TransactionAction action, FinancialRecord currentRecord, decimal oldAmount = 0)
        {
            this.Action = action;
            this.CurrentRecord = currentRecord;
            this.OldAmount = oldAmount;
        }

        /// <summary>
        /// Gets the Transaction Action
        /// </summary>
        /// <value>
        /// Transaction Action
        /// </value>
        public TransactionAction Action { get; }

        /// <summary>
        /// Gets the Financial Record
        /// </summary>
        /// <value>
        /// FinancialRecord record
        /// </value>
        public FinancialRecord CurrentRecord { get; }

        /// <summary>
        /// Gets the Old Record Amount
        /// </summary>
        /// <value>
        /// Old Record Amount
        /// </value>
        public decimal OldAmount { get; }
    }
}
