using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQChallenges.Domain
{
    public class Product
    {
        public Product(int productId, string productName, decimal price, string category)
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Price = price;
            this.Category = category;
        }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }
    }
}
