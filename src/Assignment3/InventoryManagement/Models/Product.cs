using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class Product : IProduct
    {
        public Product(string productId, string name, string category, decimal price, int stockQuantity)
        {
            this.ProductId = productId;
            this.ProductName = name;
            this.Category = category;
            this.Price = price;
            this.StockQuantity = stockQuantity;
            TotalPrice = Price * StockQuantity;
        }

        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
