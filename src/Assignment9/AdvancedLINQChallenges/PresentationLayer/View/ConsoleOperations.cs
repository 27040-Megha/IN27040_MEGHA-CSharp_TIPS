using AdvancedLINQChallenges.ApplicationLayer.Service;
using AdvancedLINQChallenges.Domain;
using AdvancedLINQChallenges.Domain.DTO;

namespace AdvancedLINQChallenges.PresentationLayer.View
{
    /// <summary>
    /// Interacts witho User
    /// </summary>
    public class ConsoleOperations
    {
        private readonly ProductService _productService;

        private readonly SupplierService _supplierService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleOperations"/> class.
        /// </summary>
        /// <param name="productService">Product Service</param>
        /// <param name="supplierService">Supplier Service</param>
        public ConsoleOperations(ProductService productService, SupplierService supplierService)
        {
            this._productService = productService;
            this._supplierService = supplierService;
        }

        /// <summary>
        /// Initial method
        /// </summary>
        public void Run()
        {
            this.LoadProducts();
            this.LoadSuppliers();
            this.DisplayTask1();
            this.DisplayTask2();
            this.DisplayTask4();
            this.DisplayTask5();
        }

        private void LoadSuppliers()
        {
            var suppliers = new List<Supplier>
            {
                new Supplier(1, "HP", 1),
                new Supplier(1, "HP", 3),
                new Supplier(2, "BoAT", 4),
                new Supplier(3, "S-Books", 5),
            };

            foreach (var supplier in suppliers)
            {
                this._supplierService.AddSupplier(supplier);
            }
        }

        private void LoadProducts()
        {
            var products = new List<Product>
            {
                new Product(1, "Laptop", 48000m, "Electronics"),
                new Product(2, "Mouse", 1200m, "Electronics"),
                new Product(3, "Keyboard", 3500m, "Electronics"),
                new Product(3, "Airpods", 3500m, "Electronics"),
                new Product(4, "Headphones", 450m, "Electronics"),
                new Product(5, "C# in Depth", 2500m, "Books"),
                new Product(6, "Clean Code", 1800m, "Books"),
                new Product(7, "Design Patterns", 3200m, "Books"),
            };

            foreach (var product in products)
            {
                bool isAdded = this._productService.AddProduct(product);

                if (!isAdded)
                {
                    Console.WriteLine($"Duplicate Product with ID : {product.ProductId} found, Could not Add Product");
                }
            }
        }

        private void DisplayTask1()
        {
            Console.WriteLine("\nTASK1: ");
            Console.WriteLine("Electronic Products with price greater than $500 Sorted By Descending order: ");
            var sortedProducts = this._productService.FilterProducts();
            foreach (var product in sortedProducts)
            {
                Console.WriteLine($"Product Name : {product.ProductName} | Price : {product.Price}");
            }

            Console.WriteLine("Average price of all the electronic products above $500: " + Math.Round(this._productService.FindAveragePrice(sortedProducts), 2));
        }

        private void DisplayTask2()
        {
            Console.WriteLine("\nTASK2: ");
            Console.WriteLine("Mapping Suppliers with Products: ");
            var mappedProducts = this._productService.MapProductsWithSuppliers();
            foreach (var product in mappedProducts)
            {
                Console.WriteLine($"Product ID: {product.ProductId} | Product Name : {product.ProductName} | Price : {product.Price} | Category : {product.Category} | Supplier ID: {product.SupplierId} | Supplier Name: {product.SupplierName}");
            }

            Console.WriteLine("\nCategorized Products: ");
            var categorizedProducts = this._productService.GroupProductsByCategory();
            foreach (var category in categorizedProducts)
            {
                Console.WriteLine($"Category : {category.Category}");
                Console.WriteLine($"Count of products : {category.ProductCount} ");
                Console.WriteLine($"Most Expensive Product ID: {category.ExpensiveProduct.ProductId}, | Product Name : {category.ExpensiveProduct.ProductName} | Product Price : {category.ExpensiveProduct.Price}");
            }
        }

        private void DisplayTask4()
        {
            var sortedBooks = this._productService.SortProductsByPrice();
            Console.WriteLine("\nTASK4: ");
            Console.WriteLine("Books sorted from Highest to lowest");
            foreach (var product in sortedBooks)
            {
                Console.WriteLine($"Book Name : {product.ProductName} | Price : {product.Price}");
            }
        }

        private void DisplayTask5()
        {
            var filteredResult = this._productService.FetchProductsWithSuppliers();

            Console.WriteLine("\nTASK5: ");
            Console.WriteLine("Filter products above 100 and Sort them by price and map them with their suppliers: ");
            foreach (var product in filteredResult)
            {
                Console.WriteLine($"Product ID : {product.ProductId}  | Product Name : {product.ProductName} | Price : {product.Price} | Product Category : {product.Category} | Supplier ID : {product.SupplierId} | Supplier Name : {product.SupplierName}");
            }
        }
    }
}
