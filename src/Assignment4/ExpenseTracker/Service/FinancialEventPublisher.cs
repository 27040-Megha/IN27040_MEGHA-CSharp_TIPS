using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
