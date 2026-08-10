using System;
using System.Collections.Generic;
using System.Linq;
using InventoryManagement.Models;
using InventoryManagement.Repository;

namespace InventoryManagement.Service
{
    /// <summary>
    /// Implements IInventoryService and Provides business logic for all operations
    /// </summary>
    public class InventoryServices : IInventoryService
    {
        private readonly IProductRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryServices"/> class.
        /// </summary>
        /// <param name="repository">repository object injected in Program.cs while creating object for InventoryService</param>
        public InventoryServices(IProductRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Adds Project Object to the Repo
        /// </summary>
        /// <param name="product">Product object to be added</param>
        public void AddProductDetails(Product product)
        {
            this._repository.SaveProduct(product);
        }

        /// <summary>
        /// Returns all Products in Inventory Repo
        /// </summary>
        /// <returns>List of Product Items</returns>
        public List<Product> GetAllProductDetails()
        {
            return this._repository.FetchAllProducts();
        }

        /// <summary>
        /// Edits Product Object in the repo
        /// </summary>
        /// <param name="existingProduct">Existing Product Object that needs to be edited</param>
        /// <param name="updatedProduct">Product object that has the updated Details</param>
        public void EditProductDetails(Product existingProduct, Product updatedProduct)
        {
            this._repository.UpdateProduct(existingProduct, updatedProduct);
        }

        /// <summary>
        /// Deletes Product Object from the repo
        /// </summary>
        /// <param name="productID">Product ID of the product</param>
        /// <returns>true if successfully deleted, else false</returns>
        public bool DeleteProductDetails(string productID)
        {
            var product = this.FindProductById(productID);
            if (product != null)
            {
                this._repository.RemoveProduct(product);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Finds Product By ID from Repo
        /// </summary>
        /// <param name="productID">Product ID to be searched</param>
        /// <returns>Product Object if found otherwise null</returns>
        public Product FindProductById(string productID)
        {
            var productFound = this._repository.GetById(productID);
            return productFound;
        }

        /// <summary>
        /// Returns List Of Products that is found with the same name matching the given product name
        /// </summary>
        /// <param name="productName">Product Name</param>
        /// <returns>List of Products matching the given product name</returns>
        public List<Product> GetProductsByName(string productName)
        {
            var productList = this.GetAllProductDetails();
            return productList.Where(p => p.ProductName.Equals(productName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        /// <summary>
        /// Returns total number of products in the Inventory
        /// </summary>
        /// <returns>Total Number of Products</returns>
        public int GetProductsCount()
        {
            return this.GetAllProductDetails().Count;
        }
    }
}
