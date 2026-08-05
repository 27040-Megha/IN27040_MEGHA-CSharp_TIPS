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
        public Income(decimal amount, DateTime date, string description, string source)
        {
            TransactionID = Guid.NewGuid();
            Amount = amount;
            Date = date;
            Description = description;
            Source = source;
        }
        public Guid TransactionID { get; init; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public string Source { get; set; }
    }
}
