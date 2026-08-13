using System.Collections.Generic;

namespace ExpenseTracker.Models
{
    /// <summary>
    /// Defines the monthly report for FinancialRecords - Used as DTO (Data Transfer Object)
    /// </summary>
    public class MonthlyFinancialReport
    {
        /// <summary>
        /// Gets or sets date part extracted from DateTime
        /// </summary>
        /// <value>
        /// Date of the financialRecord transaction
        /// </value>
        public int Date { get; set; }

        /// <summary>
        /// Gets or sets month part extracted from DateTime
        /// </summary>
        /// <value>
        /// Month of the financialRecord transaction
        /// </value>
        public int Month { get; set; }

        /// <summary>
        /// Gets or sets year part extracted from DateTime
        /// </summary>
        /// <value>
        /// Year of the financialRecord transaction
        /// </value>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets Total Amount (Income/Expense) of all the records in the in-memory list
        /// </summary>
        /// <value>
        /// Total Amount of the financial Records
        /// </value>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets List of income financialRecords after grouped year-wise and month-wise
        /// </summary>
        /// <value>
        /// List of month-wise report of income FinancialRecords
        /// </value>
        public List<Income> MonthWiseIncomeReport { get; set; }

        /// <summary>
        /// Gets or sets List of expense financialRecords after grouped year-wise and month-wise
        /// </summary>
        /// <value>
        /// List of month-wise report of expense FinancialRecords
        /// </value>
        public List<Expense> MonthWiseExpenseReport { get; set; }
    }
}
