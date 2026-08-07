using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ExpenseTracker.Models
{
    public class Income : IFinancialRecord
    {
        public Income(decimal amount, DateOnly date, string description, string source)
        {
            this.TransactionID = Guid.NewGuid();
            this.Amount = amount;
            this.Date = date;
            this.Description = description;
            this.Source = source;
        }

        public Guid TransactionID { get; init; }

        public decimal Amount { get; set; }

        public DateOnly Date { get; set; }

        public string Description { get; set; }

        public string Source { get; set; }
    }
}
