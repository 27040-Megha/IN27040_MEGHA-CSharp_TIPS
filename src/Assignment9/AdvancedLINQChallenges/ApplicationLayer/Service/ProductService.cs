using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedLINQChallenges.Domain;
using AdvancedLINQChallenges.Domain.DTO;
using AdvancedLINQChallenges.InfrastructureLayer;

namespace AdvancedLINQChallenges.ApplicationLayer.Service
{
    public class ProductService
    {
        private readonly ProductRepo _productRepo;

        private readonly SupplierService _supplierService;

        public ProductService(ProductRepo productRepo, SupplierService supplierService)
        {
            this._productRepo = productRepo;
            this._supplierService = supplierService;
        }

        public bool AddProduct(Product product)
        {
            if (this._productRepo.ReturnAllProducts().Any(p => p.ProductId.Equals(product.ProductId)))
            {
                return false;
            }

            this._productRepo.CreateProduct(product);
            return true;
        }

        public IEnumerable<Product> FetchAllProducts()
        {
            return this._productRepo.ReturnAllProducts();
        }

        public List<FilteredProduct> FilterProducts()
        {
            return this.FetchAllProducts()
                .Where(product => string.Equals(product.Category, "Electronics", StringComparison.OrdinalIgnoreCase) && (product.Price > 500))
                .Select(product => new FilteredProduct(product.ProductName, product.Price))
                .OrderByDescending(product => product.Price)
                .ToList();
        }

        public decimal FindAveragePrice(List<FilteredProduct> filteredProducts)
        {
            return filteredProducts.Average(p => p.Price);
        }

        public List<ProductSupplierDTO> MapProductsWithSuppliers()
        {
            var productList = this.FetchAllProducts();
            var supplierList = this._supplierService.FetchAllSuppliers();
            return productList.Join(
                supplierList,
                p => p.ProductId,
                s => s.ProductId,
                (p, s) => new ProductSupplierDTO
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Category = p.Category,
                    Price = p.Price,
                    SupplierId = s.SupplierId,
                    SupplierName = s.SupplierName,
                })
                .ToList();
        }

        public List<CategorizedProducts> GroupProductsByCategory()
        {
            var productList = this.MapProductsWithSuppliers();
            return productList
                .GroupBy(products => products.Category)
                .Select(category => new CategorizedProducts
                {
                    Category = category.Key,
                    ProductCount = category.Count(),
                    ExpensiveProduct = category.MaxBy(p => p.Price),
                })
                .ToList();
        }

        public List<Product> SortProductsByPrice()
        {
            return this.FetchAllProducts()
                .Where(product => string.Equals(product.Category, "Books", StringComparison.OrdinalIgnoreCase))
                .OrderByDescending(product => product.Price)
                .ToList();
        }
    }
}
