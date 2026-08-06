using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Models
{
    public enum TransactionAction { Added, Updated, Deleted}

    public interface IFinancialRecord
    {
        public Guid TransactionID { get; init; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }
    }
}
