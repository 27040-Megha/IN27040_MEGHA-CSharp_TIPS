namespace AdvancedLINQChallenges.Domain.DTO
{
    /// <summary>
    /// DTO for Products mapped with Suppliers
    /// </summary>
    public struct ProductSupplierDTO
    {
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

        /// <summary>
        /// Gets or sets the Supplier ID
        /// </summary>
        /// <value>
        /// Supplier ID of the Supplier
        /// </value>
        public int SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the Supplier Name
        /// </summary>
        /// <value>
        /// Supplier Name
        /// </value>
        public string SupplierName { get; set; }
    }
}
