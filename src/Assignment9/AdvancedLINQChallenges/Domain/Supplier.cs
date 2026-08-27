using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQChallenges.Domain
{
    public class Supplier
    {
        public Supplier(int supplierId, string supplierName, int productId)
        {
            this.SupplierId = supplierId;
            this.SupplierName = supplierName;
            this.ProductId = productId;
        }

        public int SupplierId { get; set; }

        public string SupplierName { get; set; }

        public int ProductId { get; set; }
    }
}
