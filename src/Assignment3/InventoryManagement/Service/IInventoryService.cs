using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Models;

namespace InventoryManagement.Service
{
    public interface IInventoryService
    {
        public bool AddProductDetails(string productID, string productName, string productCategory, decimal unitPrice, int stockQuantity);

        public List<IProduct> GetAllProductDetails();

        public bool EditProductDetails(string productID, string productName, string productCategory, decimal unitPrice, int stockQuantity);

        public bool DeleteProductDetails(string productID);

        public IProduct FindProductById(string productID);

        public List<IProduct> GetProductsByName(string productName);
    }
}
