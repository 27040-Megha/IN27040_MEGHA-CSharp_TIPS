using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Models;
using ExpenseTracker.Repository;
using Microsoft.VisualBasic;

namespace ExpenseTracker.Service
{
    public static class BalanceTracker
    {
        public static decimal BalanceAmount { get; private set; }

        public static void HandleIncomeTransaction(TransactionAction action, IFinancialRecord currentRecord, IFinancialRecord? oldRecord)
        {
            switch(action)
            {
                case TransactionAction.Added:
                    BalanceAmount += currentRecord.Amount;
                    break;

                case TransactionAction.Updated:
                    if(oldRecord is not null)
                    {
                        BalanceAmount -= oldRecord.Amount;
                        BalanceAmount += currentRecord.Amount;
                    }
                    break;

                case TransactionAction.Deleted:
                    BalanceAmount -= currentRecord.Amount;
                    break;
            }
        }

        public static void HandleExpenseTransaction(TransactionAction action, IFinancialRecord currentRecord, IFinancialRecord? oldRecord)
        {
            switch (action)
            {
                case TransactionAction.Added:
                    BalanceAmount -= currentRecord.Amount;
                    break;

                case TransactionAction.Updated:
                    if (oldRecord is not null)
                    {
                        BalanceAmount += oldRecord.Amount;
                        BalanceAmount -= currentRecord.Amount;
                    }
                    break;

                case TransactionAction.Deleted:
                    BalanceAmount += currentRecord.Amount;
                    break;
            }
        }
    }
}
