using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Models;

namespace InventoryManagement.Repository
{
    public interface IProductRepository
    {
        public bool AddProductInInventory(IProduct product);

        public List<IProduct> GetAllProductsFromInventory();

        public bool EditProductInInventory(IProduct updatedProduct);
        
        public bool DeleteProductFromInventory(string productID);

        public IProduct FindProductById(string newProductID);

        public List<IProduct> FindProductsByName(string productName);
    }
}
