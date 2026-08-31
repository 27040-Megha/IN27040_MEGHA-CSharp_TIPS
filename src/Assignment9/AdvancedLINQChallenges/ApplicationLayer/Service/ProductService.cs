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
    /// <summary>
    /// Business Logic for Product Service
    /// </summary>
    public class ProductService
    {
        private readonly ProductRepo _productRepo;

        private readonly SupplierService _supplierService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// </summary>
        /// <param name="productRepo">Product Repo</param>
        /// <param name="supplierService">Supplier Service</param>
        public ProductService(ProductRepo productRepo, SupplierService supplierService)
        {
            this._productRepo = productRepo;
            this._supplierService = supplierService;
        }

        /// <summary>
        /// Add product to repo
        /// </summary>
        /// <param name="product">Product Object</param>
        /// <returns>true if successfully added, false otherwise</returns>
        public bool AddProduct(Product product)
        {
            if (this._productRepo.ReturnAllProducts().Any(p => p.ProductId.Equals(product.ProductId)))
            {
                return false;
            }

            this._productRepo.CreateProduct(product);
            return true;
        }

        /// <summary>
        /// Fetches all products from product Repo
        /// </summary>
        /// <returns>IEnumerable List of products</returns>
        public IEnumerable<Product> FetchAllProducts()
        {
            return this._productRepo.ReturnAllProducts();
        }

        /// <summary>
        /// Filter products under the category "Electronics" with a price greater than $500 select only ProductName and Price, sort the product in descending order of price.
        /// </summary>
        /// <returns>Filtered Result</returns>
        public IEnumerable<FilteredProduct> FilterProducts()
        {
            return this.FetchAllProducts()
                .Where(product => string.Equals(product.Category, "Electronics", StringComparison.OrdinalIgnoreCase) && (product.Price > 500))
                .Select(product => new FilteredProduct(product.ProductName, product.Price))
                .OrderByDescending(product => product.Price);
        }

        /// <summary>
        /// Calculates average price of the list of products
        /// </summary>
        /// <param name="filteredProducts">List of products</param>
        /// <returns>Average price</returns>
        public decimal FindAveragePrice(IEnumerable<FilteredProduct> filteredProducts)
        {
            return filteredProducts.Average(p => p.Price);
        }

        /// <summary>
        /// Map products with Suppliers
        /// </summary>
        /// <returns>IEnumerable List of mapped products with suppliers</returns>
        public IEnumerable<ProductSupplierDTO> MapProductsWithSuppliers()
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
                });
        }

        /// <summary>
        /// Groups Products by category
        /// </summary>
        /// <returns>IEnumerable List of result objects</returns>
        public IEnumerable<CategorizedProducts> GroupProductsByCategory()
        {
            var productList = this.FetchAllProducts();
            return productList
                .GroupBy(products => products.Category)
                .Select(category => new CategorizedProducts
                {
                    Category = category.Key,
                    ProductCount = category.Count(),
                    ExpensiveProduct = category.MaxBy(p => p.Price),
                });
        }

        /// <summary>
        /// Sort Products by price
        /// </summary>
        /// <returns>IEnumerable List of products sorted by price</returns>
        public IEnumerable<Product> SortProductsByPrice()
        {
            return this.FetchAllProducts()
                .Where(product => string.Equals(product.Category, "Books", StringComparison.OrdinalIgnoreCase))
                .OrderByDescending(product => product.Price);
        }

        /// <summary>
        /// Filter products above 100 and Sort them by price and map them with their suppliers:
        /// </summary>
        /// <returns>IEnumerable List of result</returns>
        public IEnumerable<ProductSupplierDTO> FetchProductsWithSuppliers()
        {
            var supplierList = this._supplierService.FetchAllSuppliers();
            var queryBuilder = new QueryBuilder<Product>(this.FetchAllProducts());
            var result = queryBuilder
                .Filter(p => this.GreaterThanOrEqual(p.Price))
                .SortBy(p => p.Price)
                .Joins(
                supplierList,
                p => p.ProductId,
                s => s.ProductId,
                (p, s) => new ProductSupplierDTO
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    Category = p.Category,
                    SupplierId = s.SupplierId,
                    SupplierName = s.SupplierName
                })
                .Execute();
            return result;
        }

        private bool GreaterThanOrEqual(decimal price)
        {
            return price > 500;
        }
    }
}
