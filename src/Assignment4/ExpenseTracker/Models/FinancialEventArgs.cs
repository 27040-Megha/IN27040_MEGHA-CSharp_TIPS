using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Models
{
    public class FinancialEventArgs : EventArgs
    {
        public FinancialEventArgs(TransactionAction action, IFinancialRecord currentRecord)
        {
            Action = action;
            CurrentRecord = currentRecord;
        }

        public FinancialEventArgs(TransactionAction action, IFinancialRecord currentRecord, decimal oldAmount=0)
        {
            Action = action;
            CurrentRecord = currentRecord;
            OldAmount = oldAmount;
        }

        public TransactionAction Action { get; }

        public IFinancialRecord CurrentRecord { get; }

        public decimal OldAmount { get; }
    }
}
