using System.Collections.Generic;
using InventoryManagement.Models;

namespace InventoryManagement.Repository
{
    /// <summary>
    /// Defines Storage and CRUD Operations for Inventory Management System
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Adds product to Inventory Repo
        /// </summary>
        /// <param name="product">Product Instance to be stored</param>
        public void SaveProduct(IProduct product);

        /// <summary>
        /// Returns all Products in Inventory Repo
        /// </summary>
        /// <returns>List of Product in Repo</returns>
        public List<IProduct> FetchAllProducts();

        /// <summary>
        /// Update product ib Inventory Repo
        /// </summary>
        /// <param name="existingProduct">Product Instance that has to be updated</param>
        /// <param name="updatedProduct">Product Instance to be Updated</param>
        public void UpdateProduct(IProduct existingProduct, IProduct updatedProduct);

        /// <summary>
        /// Deletes product from Inventory Repo
        /// </summary>
        /// <param name="productID">ProductID of the product to be deleted</param>
        /// <returns>true if product was successfully deleted, else false </returns>
        public bool RemoveProduct(string productID);

        /// <summary>
        /// Finds product by ID in Inventory Repo
        /// </summary>
        /// <param name="productID">ProductID to be searched</param>
        /// <returns>Product Object found with the ID, else null</returns>
        public IProduct FetchProductById(string productID);

        /// <summary>
        /// Returns List Of Products that is found with the same name matching the given product name
        /// </summary>
        /// <param name="productName">Product Name</param>
        /// <returns>List of Products matching the given product name</returns>
        public List<IProduct> FetchProductsByName(string productName);
    }
}
