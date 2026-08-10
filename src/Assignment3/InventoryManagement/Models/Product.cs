namespace InventoryManagement.Models
{
    /// <summary>
    /// Concrete class that implements IProduct interface
    /// </summary>
    public class Product : IProduct
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class with specified identity
        /// </summary>
        /// <param name="productId">The unique alphanumeric identifier for the product.</param>
        /// <param name="name">The  name of the product.</param>
        /// <param name="category">The category of the product.</param>
        /// <param name="price">The unit cost of the product.</param>
        /// <param name="stockQuantity">The count of items available in inventory stock.</param>
        public Product(string productId, string name, string category, decimal price, int stockQuantity)
        {
            this.ProductId = productId;
            this.ProductName = name;
            this.Category = category;
            this.Price = price;
            this.StockQuantity = stockQuantity;
        }

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
        public decimal TotalPrice => this.Price * this.StockQuantity;
    }
}
