using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Models;

namespace InventoryManagement.Repository
{
    internal class ProductRepository : IProductRepository
    {
        private readonly List<IProduct> _productsRepo = new List<IProduct>();

        public bool AddProduct(IProduct product)
        {
            if (FindProductById(product.ProductId)==null)
            {
                _productsRepo.Add(product);
                return true;
            }
            return false;
        }

        public List<IProduct> GetAllProducts()
        {
            return _productsRepo;
        }

        public bool EditProduct(IProduct updatedProduct)
        {
            var existingProduct = FindProductById(updatedProduct.ProductId);
            if (existingProduct==null)
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

        public bool DeleteProduct(string productID)
        {
            var product = FindProductById(productID);
            if (product != null)
            {
                _productsRepo.Remove(product);
                return true;
            }
            return false;
        }

        public IProduct FindProductById(string newProductID)
        {
            foreach(var product in _productsRepo)
            {
                if (product.ProductId.Equals(newProductID))
                {
                    return product;
                }
            }
            return null;
        }

        public List<IProduct> FindProductsByName(string newProductName)
        {
            var matchingProductList = new List<IProduct>();
            foreach (var product in _productsRepo)
            {
                if (product.ProductName.Equals(newProductName))
                {
                    matchingProductList.Add(product);
                }
            }
            return matchingProductList;
        }
    }
}
