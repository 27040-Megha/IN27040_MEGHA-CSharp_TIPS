using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQChallenges.Domain
{
    /// <summary>
    /// Structure for Model
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="productId">Product ID</param>
        /// <param name="productName">Product Name</param>
        /// <param name="price">Product Price</param>
        /// <param name="category">Product Category</param>
        public Product(int productId, string productName, decimal price, string category)
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Price = price;
            this.Category = category;
        }

        /// <summary>
        /// Gets or sets the Product ID
        /// </summary>
        /// <value>
        /// Product ID of the product
        /// </value>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the Product Name
        /// </summary>
        /// <value>
        /// Product Name of the product
        /// </value>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the Product price
        /// </summary>
        /// <value>
        /// Price of the product
        /// </value>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the Product Category
        /// </summary>
        /// <value>
        /// Category of the product
        /// </value>
        public string Category { get; set; }
    }
}
