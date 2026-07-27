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

        public bool AddProductToRepo(string productID, string productName, string productCategory, decimal unitPrice, int stockQuantity)
        {
            Product product = new Product(productID, productName, productCategory, unitPrice, stockQuantity);
            if(_repository.AddProductInInventory(product))
            {
                return true;
            }
            return false;
        }

        public List<IProduct> GetAllProductsFromRepo()
        {
            return _repository.GetAllProductsFromInventory();
        }

        public bool EditProductInRepo(string productID, string productName, string productCategory, decimal unitPrice, int stockQuantity)
        {
            Product updatedProduct = new Product(productID, productName, productCategory, unitPrice, stockQuantity);
            return _repository.EditProductInInventory(updatedProduct);
        }

        public bool DeleteProductFromRepo(string productID)
        {
            return _repository.DeleteProductFromInventory(productID);
        }

        public IProduct SearchProductByIdInRepo(string productID)
        {
            return _repository.FindProductById(productID);
        }

        public List<IProduct> GetProductsByName(string productName)
        {
            return _repository.FindProductsByName(productName);
        }
    }
}
