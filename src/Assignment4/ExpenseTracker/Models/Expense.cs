using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ExpenseTracker.Models
{
    public class Expense : IFinancialRecord
    {
        private Expense _oldRecord;

        public Expense(Expense oldRecord)
        {
            this._oldRecord = oldRecord;
        }

        public Expense(decimal amount, DateTime date, string description, string category)
        {
            TransactionID = Guid.NewGuid();
            Amount = amount;
            Date = date;
            Description = description;
            Category = category;
        }

        public Guid TransactionID { get; init; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }
    }
}
