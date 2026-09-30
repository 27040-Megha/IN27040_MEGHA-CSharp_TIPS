namespace AdvancedUseOfDelegates
{
    /// <summary>
    /// Model for Product
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="productName">Product Name</param>
        /// <param name="category">Category of Product</param>
        /// <param name="price">Product Price</param>
        public Product(string productName, string category, decimal price)
        {
            this.ProductName = productName;
            this.Category = category;
            this.Price = price;
        }

        /// <summary>
        /// Gets or sets the value of Product Name
        /// </summary>
        /// <value>
        /// Product Name
        /// </value>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the Category of Product
        /// </summary>
        /// <value>
        /// Category of Product
        /// </value>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the Price of Product
        /// </summary>
        /// <value>
        /// Product Price
        /// </value>
        public decimal Price { get; set; }
    }
}
