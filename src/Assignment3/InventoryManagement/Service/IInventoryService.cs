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
        public bool AddProductToRepo(string productID, string productName, string productCategory, decimal unitPrice, int stockQuantity);

        public List<IProduct> GetAllProductsFromRepo();

        public bool EditProductInRepo(string productID, string productName, string productCategory, decimal unitPrice, int stockQuantity);

        public bool DeleteProductFromRepo(string productID);

        public IProduct SearchProductByIdInRepo(string productID);

        public List<IProduct> GetProductsByName(string productName);
    }
}
