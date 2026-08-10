namespace InventoryManagement.Models
{
    /// <summary>
    /// Defines Product Entity for Inventory Management System
    /// </summary>
    public interface IProduct
    {
        /// <summary>
        /// Gets or sets the unique alphanumeric identifier for the product.
        /// </summary>
        /// <value>
        /// Product ID
        /// </value>
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets the Name of the product.
        /// </summary>
        /// <value>
        /// Product Name
        /// </value>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the Category of the product.
        /// </summary>
        /// <value>
        /// Product Category
        /// </value>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the Price of the product.
        /// </summary>
        /// <value>
        /// Unit Price of the Product
        /// </value>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the Stock Quantity of the product.
        /// </summary>
        /// <value>
        /// Product Name
        /// </value>
        public int StockQuantity { get; set; }

        /// <summary>
        /// Gets the Total Worth of the product in inventory.
        /// </summary>
        /// <value>
        /// Product Total Worth in Inventory
        /// </value>
        public decimal TotalPrice { get; }
    }
}
