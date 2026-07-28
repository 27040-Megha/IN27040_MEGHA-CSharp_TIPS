using System.Collections.Generic;
using InventoryManagement.Models;

namespace InventoryManagement.Repository
{
    /// <summary>
    /// Implements IProductRepository and Provides concrete methods
    /// </summary>
    internal class ProductRepository : IProductRepository
    {
        private readonly List<IProduct> _productsRepo = new List<IProduct>();

        /// <summary>
        /// Adds product to Inventory Repo
        /// </summary>
        /// <param name="product">Product Instance to be stored</param>
        /// <returns>true if product was successfully added, else false </returns>
        public bool AddProduct(IProduct product)
        {
            if (this.FindProductById(product.ProductId) == null)
            {
                this._productsRepo.Add(product);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns all Products in Inventory Repo
        /// </summary>
        /// <returns>List of Product in Repo</returns>
        public List<IProduct> GetAllProducts()
        {
            return this._productsRepo;
        }

        /// <summary>
        /// Update product ib Inventory Repo
        /// </summary>
        /// <param name="updatedProduct">Product Instance to be Updated</param>
        /// <returns>true if product was successfully updated, else false </returns>
        public bool EditProduct(IProduct updatedProduct)
        {
            var existingProduct = this.FindProductById(updatedProduct.ProductId);
            if (existingProduct == null)
            {
                return false;
            }

            existingProduct.ProductName = updatedProduct.ProductName;
            existingProduct.Category = updatedProduct.Category;
            existingProduct.Price = updatedProduct.Price;
            existingProduct.StockQuantity = updatedProduct.StockQuantity;
            existingProduct.TotalPrice = updatedProduct.Price * updatedProduct.StockQuantity;
            return true;
        }

        /// <summary>
        /// Deletes product from Inventory Repo
        /// </summary>
        /// <param name="productID">ProductID of the product to be deleted</param>
        /// <returns>true if product was successfully deleted, else false </returns>
        public bool DeleteProduct(string productID)
        {
            var product = this.FindProductById(productID);
            if (product != null)
            {
                this._productsRepo.Remove(product);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Finds product by ID in Inventory Repo
        /// </summary>
        /// <param name="productID">ProductID to be searched</param>
        /// <returns>Product Object found with the ID, else null</returns>
        public IProduct FindProductById(string productID)
        {
            foreach (var product in this._productsRepo)
            {
                if (product.ProductId.Equals(productID))
                {
                    return product;
                }
            }

            return null;
        }

        /// <summary>
        /// Returns List Of Products that is found with the same name matching the given product name
        /// </summary>
        /// <param name="productName">Product Name</param>
        /// <returns>List of Products matching the given product name</returns>
        public List<IProduct> FindProductsByName(string productName)
        {
            var matchingProductList = new List<IProduct>();
            foreach (var product in this._productsRepo)
            {
                if (product.ProductName.Equals(productName))
                {
                    matchingProductList.Add(product);
                }
            }

            return matchingProductList;
        }
    }
}
