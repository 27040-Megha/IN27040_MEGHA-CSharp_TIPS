using System;
using ExpenseTracker.Models;

namespace ExpenseTracker.Service
{
    public static class FinancialEventPublisher
    {
        public static event EventHandler<FinancialEventArgs> FinancialRecordChangeHandler;

        public static void Notify(object sender, FinancialEventArgs args)
        {
            FinancialRecordChangeHandler?.Invoke(sender, args);
        }
    }
}
