namespace ExpenseTracker.Models
{
    /// <summary>
    /// Menu Option to use in Switch Case
    /// </summary>
    public enum MenuOption : byte
    {
        /// <summary>
        /// Invalid Option - Start enum index with 0
        /// </summary>
        Invalid = 0,

        /// <summary>
        /// Choice - 1 : Add Income to Expense Tracker Application
        /// </summary>
        AddIncome,

        /// <summary>
        /// Choice - 2 : Add Expense to Expense Tracker Application
        /// </summary>
        AddExpense,

        /// <summary>
        /// View Income and Expense Records
        /// </summary>
        ViewAllRecord,

        /// <summary>
        /// Delete Income or Expense Record
        /// </summary>
        DeleteRecord,

        /// <summary>
        /// Edit Income or Expense Record
        /// </summary>
        EditRecord,

        /// <summary>
        /// To View Net Balance, Total Income and Total Expense (Summary Details)
        /// </summary>
        ViewSummary,

        /// <summary>
        /// Exit the Application
        /// </summary>
        Exit,
    }
}
