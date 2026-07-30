using System.Collections.Generic;
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
        /// Creates Product Object and adds it to the Repo
        /// </summary>
        /// <param name="productID">Product ID of the product</param>
        /// <param name="productName">Nameof the product</param>
        /// <param name="productCategory">Category of the product</param>
        /// <param name="unitPrice">Unit Price of the product</param>
        /// <param name="stockQuantity">Stock Quantity of the product</param>
        public void AddProductDetails(string productID, string productName, string productCategory, decimal unitPrice, int stockQuantity)
        {
            Product product = new Product(productID, productName, productCategory, unitPrice, stockQuantity);

            this._repository.SaveProduct(product);
        }

        /// <summary>
        /// Returns all Products in Inventory Repo
        /// </summary>
        /// <returns>List of Product Items</returns>
        public List<IProduct> GetAllProductDetails()
        {
            return this._repository.FetchAllProducts();
        }

        /// <summary>
        /// Edits Product Object in the repo
        /// </summary>
        /// <param name="productID">Product ID of the product</param>
        /// <param name="productName">Nameof the product</param>
        /// <param name="productCategory">Category of the product</param>
        /// <param name="unitPrice">Unit Price of the product</param>
        /// <param name="stockQuantity">Stock Quantity of the product</param>
        /// <param name="existingProduct">Product Instance that needs to be updated</param>
        public void EditProductDetails(string productID, string productName, string productCategory, decimal unitPrice, int stockQuantity, IProduct existingProduct)
        {
            Product updatedProduct = new Product(productID, productName, productCategory, unitPrice, stockQuantity);
            this._repository.UpdateProduct(existingProduct, updatedProduct);
        }

        /// <summary>
        /// Deletes Product Object from the repo
        /// </summary>
        /// <param name="productID">Product ID of the product</param>
        /// <returns>true if successfully deleted, else false</returns>
        public bool DeleteProductDetails(string productID)
        {
            return this._repository.RemoveProduct(productID);
        }

        /// <summary>
        /// Finds Product By ID from Repo
        /// </summary>
        /// <param name="productID">Product ID to be searched</param>
        /// <returns>Product Object if found otherwise null</returns>
        public IProduct FindProductById(string productID)
        {
            return this._repository.FetchProductById(productID);
        }

        /// <summary>
        /// Returns List Of Products that is found with the same name matching the given product name
        /// </summary>
        /// <param name="productName">Product Name</param>
        /// <returns>List of Products matching the given product name</returns>
        public List<IProduct> GetProductsByName(string productName)
        {
            return this._repository.FetchProductsByName(productName);
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
