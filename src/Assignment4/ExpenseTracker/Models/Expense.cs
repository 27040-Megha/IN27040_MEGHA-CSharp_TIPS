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
        public Expense(decimal amount, DateOnly date, string description, string category)
        {
            this.TransactionID = Guid.NewGuid();
            this.Amount = amount;
            this.Date = date;
            this.Description = description;
            this.Category = category;
        }

        public Guid TransactionID { get; init; }

        public decimal Amount { get; set; }

        public DateOnly Date { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }
    }
}
