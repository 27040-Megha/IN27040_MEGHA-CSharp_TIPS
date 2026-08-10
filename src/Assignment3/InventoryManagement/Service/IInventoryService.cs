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
        /// Adds Project Object to the Repo
        /// </summary>
        /// <param name="product">Product Object to be added</param>
        public void AddProductDetails(IProduct product);

        /// <summary>
        /// Returns all Products in Inventory Repo
        /// </summary>
        /// <returns>List of Product Items</returns>
        public List<IProduct> GetAllProductDetails();

        /// <summary>
        /// Edits Product Object in the repo
        /// </summary>
        /// <param name="existingProduct">Existing Product Object that needs to be edited</param>
        /// <param name="updatedProduct">Product object that has the updated Details</param>
        public void EditProductDetails(IProduct existingProduct, IProduct updatedProduct);

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
