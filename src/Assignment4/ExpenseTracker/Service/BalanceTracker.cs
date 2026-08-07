using ExpenseTracker.Models;

namespace ExpenseTracker.Service
{
    /// <summary>
    /// Manage the global balance, total income and total expense accurately
    /// </summary>
    public static class BalanceTracker
    {
        /// <summary>
        /// Gets the Balance Amount
        /// </summary>
        /// <value>
        /// Balance Amount
        /// </value>
        public static decimal BalanceAmount { get; private set; }

        /// <summary>
        /// Gets the Total Income
        /// </summary>
        /// <value>
        /// Total Income
        /// </value>
        public static decimal TotalIncome { get; private set; }

        /// <summary>
        /// Gets the Total Expense
        /// </summary>
        /// <value>
        /// Total Expense
        /// </value>
        public static decimal TotalExpense { get; private set; }

        /// <summary>
        /// EventHandler method matching EventArgs(Built-in Delegate) that handles which Transaction(Income/Expense) has to be executed based on the record
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">FinancialEventArgs object</param>
        public static void HandleFinancialRecordChange(object sender, FinancialEventArgs e)
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
                    TotalExpense = TotalExpense - oldAmount + currentRecord.Amount;
                    break;

                case TransactionAction.Deleted:
                    BalanceAmount += currentRecord.Amount;
                    TotalExpense -= currentRecord.Amount;
                    break;
            }
        }
    }
}
