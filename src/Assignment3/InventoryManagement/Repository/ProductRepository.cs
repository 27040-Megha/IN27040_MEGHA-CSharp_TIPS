using System.Collections.Generic;
using InventoryManagement.Models;

namespace InventoryManagement.Repository
{
    /// <summary>
    /// Implements IProductRepository and Provides concrete methods
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _productsRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        public ProductRepository()
        {
             this._productsRepo = new List<Product>();
        }

        /// <summary>
        /// Adds product to Inventory Repo
        /// </summary>
        /// <param name="product">Product Instance to be stored</param>
        public void SaveProduct(Product product)
        {
            this._productsRepo.Add(product);
        }

        /// <summary>
        /// Returns all Products in Inventory Repo
        /// </summary>
        /// <returns>List of Product in Repo</returns>
        public List<Product> FetchAllProducts()
        {
            return this._productsRepo;
        }

        /// <summary>
        /// Update product details in Inventory Repo
        /// </summary>
        /// <param name="existingProduct">existing Product Instance that needs to be updated</param>
        /// <param name="updatedProduct">Product Instance to be Updated</param>
        public void UpdateProduct(Product existingProduct, Product updatedProduct)
        {
            existingProduct.ProductName = updatedProduct.ProductName;
            existingProduct.Category = updatedProduct.Category;
            existingProduct.Price = updatedProduct.Price;
            existingProduct.StockQuantity = updatedProduct.StockQuantity;
        }

        /// <summary>
        /// Deletes product from Inventory Repo
        /// </summary>
        /// <param name="product">Product Object to be deleted</param>
        public void RemoveProduct(Product product)
        {
            this._productsRepo.Remove(product);
        }

        /// <summary>
        /// Finds Product By ID
        /// </summary>
        /// <param name="productID">Product ID of the product that needs to be searched</param>
        /// <returns>Product Details of the specified product</returns>
        public Product GetById(string productID)
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
    }
}
