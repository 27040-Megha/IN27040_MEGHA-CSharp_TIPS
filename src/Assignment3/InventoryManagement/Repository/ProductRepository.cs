using System.Collections.Generic;
using InventoryManagement.Models;

namespace InventoryManagement.Repository
{
    /// <summary>
    /// Implements IProductRepository and Provides concrete methods
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly List<IProduct> _productsRepo = new List<IProduct>();

        /// <summary>
        /// Adds product to Inventory Repo
        /// </summary>
        /// <param name="product">Product Instance to be stored</param>
        public void SaveProduct(IProduct product)
        {
            this._productsRepo.Add(product);
        }

        /// <summary>
        /// Returns all Products in Inventory Repo
        /// </summary>
        /// <returns>List of Product in Repo</returns>
        public List<IProduct> FetchAllProducts()
        {
            return this._productsRepo;
        }

        /// <summary>
        /// Update product ib Inventory Repo
        /// </summary>
        /// <param name="existingProduct">existing Product Instance that needs to be updated</param>
        /// <param name="updatedProduct">Product Instance to be Updated</param>
        public void UpdateProduct(IProduct existingProduct, IProduct updatedProduct)
        {
            existingProduct.ProductName = updatedProduct.ProductName;
            existingProduct.Category = updatedProduct.Category;
            existingProduct.Price = updatedProduct.Price;
            existingProduct.StockQuantity = updatedProduct.StockQuantity;
            existingProduct.TotalPrice = updatedProduct.Price * updatedProduct.StockQuantity;
        }

        /// <summary>
        /// Deletes product from Inventory Repo
        /// </summary>
        /// <param name="product">Product Object to be deleted</param>
        public void RemoveProduct(IProduct product)
        {
            this._productsRepo.Remove(product);
        }
    }
}
