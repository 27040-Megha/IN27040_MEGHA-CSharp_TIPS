using System;

namespace DynamicObjectInspector
{
    /// <summary>
    /// Class definition for Product
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="productId">Product ID</param>
        /// <param name="productName">Name of the product</param>
        /// <param name="price">Price of the product</param>
        public Product(int productId, string productName, decimal price)
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Price = price;
        }

        /// <summary>
        /// Gets or sets the value of Product ID
        /// </summary>
        /// <value>
        /// The value of Product ID
        /// </value>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the value of Product Name
        /// </summary>
        /// <value>
        /// The value of Product Name
        /// </value>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the value of Product Price
        /// </summary>
        /// <value>
        /// The value of Product Price
        /// </value>
        public decimal Price { get; set; }
    }
}
