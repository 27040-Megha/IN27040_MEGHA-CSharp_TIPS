using System;
using ExpenseTracker.Models;

namespace ExpenseTracker.Service
{
    /// <summary>
    /// Event Publisher Class - Notifies the Subscribers when Income or Expense is Added/Updated/Deleted (Like a BroadCaster)
    /// </summary>
    public static class FinancialEventPublisher
    {
        /// <summary>
        /// EventHandler to which subscribers will subscribe to
        /// </summary>
        public static event EventHandler<FinancialEventArgs> FinancialRecordChangeHandler;

        /// <summary>
        /// Notifies the subscribers by invoking
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="args">FinancialEventArgs object</param>
        public static void Notify(object sender, FinancialEventArgs args)
        {
            FinancialRecordChangeHandler?.Invoke(sender, args);
        }
    }
}
