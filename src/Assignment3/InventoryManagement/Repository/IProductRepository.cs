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
        public bool AddProduct(IProduct product);

        public List<IProduct> GetAllProducts();

        public bool EditProduct(IProduct updatedProduct);
        
        public bool DeleteProduct(string productID);

        public IProduct FindProductById(string newProductID);

        public List<IProduct> FindProductsByName(string productName);
    }
}
