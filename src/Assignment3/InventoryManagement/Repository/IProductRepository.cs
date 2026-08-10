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
        /// Update product details in Inventory Repo
        /// </summary>
        /// <param name="existingProduct">Product Instance that has to be updated</param>
        /// <param name="updatedProduct">Product Instance to be Updated</param>
        public void UpdateProduct(IProduct existingProduct, IProduct updatedProduct);

        /// <summary>
        /// Deletes product from Inventory Repo
        /// </summary>
        /// <param name="product">Product Instance to be deleted from the repo</param>
        public void RemoveProduct(IProduct product);

        /// <summary>
        /// Finds Product By ID
        /// </summary>
        /// <param name="productID">Product ID of the product that needs to be searched</param>
        /// <returns>Product Details of the specified product</returns>
        public IProduct GetById(string productID);
    }
}
