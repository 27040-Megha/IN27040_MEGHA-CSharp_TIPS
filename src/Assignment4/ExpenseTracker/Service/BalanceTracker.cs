using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        public static decimal TotalIncome { get; private set; }

        public static decimal TotalExpense { get; private set; }

        public static void HandleFinancialRecordChange(object? sender, FinancialEventArgs e)
        {
            if (e.CurrentRecord is Income)
            {
                HandleIncomeTransaction(e.Action, e.CurrentRecord, e.OldAmount);
            }
            else if (e.CurrentRecord is Expense)
            {
                HandleExpenseTransaction(e.Action, e.CurrentRecord, e.OldAmount);
            }
        }

        private static void HandleIncomeTransaction(TransactionAction action, IFinancialRecord currentRecord, decimal oldAmount)
        {
            switch (action)
            {
                case TransactionAction.Added:
                    BalanceAmount += currentRecord.Amount;
                    TotalIncome += currentRecord.Amount;
                    break;

                case TransactionAction.Updated:
                    BalanceAmount = BalanceAmount - oldAmount + currentRecord.Amount;
                    TotalIncome = TotalIncome - oldAmount + currentRecord.Amount;
                    break;

                case TransactionAction.Deleted:
                    BalanceAmount -= currentRecord.Amount;
                    TotalIncome -= currentRecord.Amount;
                    break;
            }
        }

        private static void HandleExpenseTransaction(TransactionAction action, IFinancialRecord currentRecord, decimal oldAmount)
        {
            switch (action)
            {
                case TransactionAction.Added:
                    BalanceAmount -= currentRecord.Amount;
                    TotalExpense += currentRecord.Amount;
                    break;

                case TransactionAction.Updated:
                    BalanceAmount = BalanceAmount + oldAmount - currentRecord.Amount;
                    TotalIncome = TotalIncome - oldAmount + currentRecord.Amount;
                    break;

                case TransactionAction.Deleted:
                    BalanceAmount += currentRecord.Amount;
                    TotalExpense -= currentRecord.Amount;
                    break;
            }
        }
    }
}
