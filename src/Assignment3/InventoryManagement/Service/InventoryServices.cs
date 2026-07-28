using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Models;
using InventoryManagement.Repository;

namespace InventoryManagement.Service
{
    internal class InventoryServices : IInventoryService
    {
        private readonly IProductRepository _repository;

        public InventoryServices(IProductRepository repository)
        {
            _repository = repository;
        }

        public bool AddProductDetails(string productID, string productName, string productCategory, decimal unitPrice, int stockQuantity)
        {
            Product product = new Product(productID, productName, productCategory, unitPrice, stockQuantity);
            if(_repository.AddProduct(product))
            {
                return true;
            }
            return false;
        }

        public List<IProduct> GetAllProductDetails()
        {
            return _repository.GetAllProducts();
        }

        public bool EditProductDetails(string productID, string productName, string productCategory, decimal unitPrice, int stockQuantity)
        {
            Product updatedProduct = new Product(productID, productName, productCategory, unitPrice, stockQuantity);
            return _repository.EditProduct(updatedProduct);
        }

        public bool DeleteProductDetails(string productID)
        {
            return _repository.DeleteProduct(productID);
        }

        public IProduct FindProductById(string productID)
        {
            return _repository.FindProductById(productID);
        }

        public List<IProduct> GetProductsByName(string productName)
        {
            return _repository.FindProductsByName(productName);
        }
    }
}
