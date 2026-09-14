namespace AdvancedLINQChallenges.Domain
{
    /// <summary>
    /// Model for Supplier Class
    /// </summary>
    public class Supplier
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Supplier"/> class.
        /// </summary>
        /// <param name="supplierId">Supplier ID</param>
        /// <param name="supplierName">Supplier Name</param>
        /// <param name="productId">Product ID</param>
        public Supplier(int supplierId, string supplierName, int productId)
        {
            this.SupplierId = supplierId;
            this.SupplierName = supplierName;
            this.ProductId = productId;
        }

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

        /// <summary>
        /// Gets or sets the Product ID
        /// </summary>
        /// <value>
        /// Product ID of the product
        /// </value>
        public int ProductId { get; set; }
    }
}
