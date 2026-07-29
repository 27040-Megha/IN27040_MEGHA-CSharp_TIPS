using System.Collections.Generic;
using InventoryManagement.Models;

namespace InventoryManagement.Service
{
    /// <summary>
    /// Defines Business Logic of the Inventory Management System
    /// </summary>
    public interface IInventoryService
    {
        /// <summary>
        /// Creates Product Object and adds it to the Repo
        /// </summary>
        /// <param name="productID">Product ID of the product</param>
        /// <param name="productName">Nameof the product</param>
        /// <param name="productCategory">Category of the product</param>
        /// <param name="unitPrice">Unit Price of the product</param>
        /// <param name="stockQuantity">Stock Quantity of the product</param>
        /// <returns>true if successfully added, else false</returns>
        public bool AddProductDetails(string productID, string productName, string productCategory, decimal unitPrice, int stockQuantity);

        /// <summary>
        /// Returns all Products in Inventory Repo
        /// </summary>
        /// <returns>List of Product Items</returns>
        public List<IProduct> GetAllProductDetails();

        /// <summary>
        /// Edits Product Object in the repo
        /// </summary>
        /// <param name="productID">Product ID of the product</param>
        /// <param name="productName">Nameof the product</param>
        /// <param name="productCategory">Category of the product</param>
        /// <param name="unitPrice">Unit Price of the product</param>
        /// <param name="stockQuantity">Stock Quantity of the product</param>
        /// <returns>true if successfully updated, else false</returns>
        public bool EditProductDetails(string productID, string productName, string productCategory, decimal unitPrice, int stockQuantity);

        /// <summary>
        /// Deletes Product Object from the repo
        /// </summary>
        /// <param name="productID">Product ID of the product</param>
        /// <returns>true if successfully deleted, else false</returns>
        public bool DeleteProductDetails(string productID);

        /// <summary>
        /// Finds Product By ID from Repo
        /// </summary>
        /// <param name="productID">Product ID to be searched</param>
        /// <returns>Product Object if found otherwise null</returns>
        public IProduct FindProductById(string productID);

        /// <summary>
        /// Returns List Of Products that is found with the same name matching the given product name
        /// </summary>
        /// <param name="productName">Product Name</param>
        /// <returns>List of Products matching the given product name</returns>
        public List<IProduct> GetProductsByName(string productName);

        /// <summary>
        /// Returns total number of products in the Inventory
        /// </summary>
        /// <returns>Total Number of Products</returns>
        public int GetProductsCount();
    }
}
