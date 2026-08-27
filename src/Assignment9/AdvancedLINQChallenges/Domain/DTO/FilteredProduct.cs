namespace AdvancedLINQChallenges.Domain.DTO
{
    /// <summary>
    /// DTO for Filtered Products
    /// </summary>
    public struct FilteredProduct
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FilteredProduct"/> struct.
        /// </summary>
        /// <param name="productName">Product Name</param>
        /// <param name="price">Product Price</param>
        public FilteredProduct(string productName, decimal price)
        {
            this.ProductName = productName;
            this.Price = price;
        }

        /// <summary>
        /// Gets or sets the product name
        /// </summary>
        /// <value>
        /// Product Name
        /// </value>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets product price
        /// </summary>
        /// <value>
        /// Product price
        /// </value>
        public decimal Price { get; set; }
    }
}
