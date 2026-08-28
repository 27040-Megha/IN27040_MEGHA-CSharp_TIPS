using AdvancedLINQChallenges.ApplicationLayer.Service;
using AdvancedLINQChallenges.Domain;
using ConsoleTables;

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

        /// <summary>
        /// Prints the text in Specific Color
        /// </summary>
        /// <param name="text">Input string</param>
        /// <param name="colorChoice">Specific color of text to be displayed</param>
        private static void WriteColorLine(string text, ConsoleColor colorChoice)
        {
            Console.ForegroundColor = colorChoice;
            Console.WriteLine(text);
            Console.ResetColor();
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
                    Console.WriteLine(DisplayResource.DuplicateProductError);
                }
            }
        }

        private void DisplayTask1()
        {
            WriteColorLine(DisplayResource.Task1Title, ConsoleColor.Yellow);
            var sortedProducts = this._productService.FilterProducts();
            var table = new ConsoleTable("Product Name", "Price");
            foreach (var product in sortedProducts)
            {
                table.AddRow(product.ProductName, product.Price);
            }

            table.Write();
            WriteColorLine(string.Format(DisplayResource.Task1AveragePrice, Math.Round(this._productService.FindAveragePrice(sortedProducts), 2)), ConsoleColor.Cyan);
        }

        private void DisplayTask2()
        {
            WriteColorLine(DisplayResource.Task2Title, ConsoleColor.Yellow);
            var mappedProducts = this._productService.MapProductsWithSuppliers();
            var table = new ConsoleTable("Product ID", "Product Name", "Price", "Category", "Supplier ID", "Supplier Name");
            foreach (var product in mappedProducts)
            {
                table.AddRow(product.ProductId, product.ProductName, product.Price, product.Category, product.SupplierId, product.SupplierName);
            }

            table.Write();

            WriteColorLine(DisplayResource.Task2CategorizedHeader, ConsoleColor.Yellow);
            var categorizedProducts = this._productService.GroupProductsByCategory();
            foreach (var category in categorizedProducts)
            {
                WriteColorLine(string.Format(DisplayResource.Task2CategoryLabel, category.Category), ConsoleColor.Cyan);
                Console.WriteLine(string.Format(DisplayResource.Task2ProductCountLabel, category.ProductCount));
                Console.WriteLine(string.Format(DisplayResource.Task2ExpensiveProductLabel, category.ExpensiveProduct.ProductId, category.ExpensiveProduct.ProductName, category.ExpensiveProduct.Price));
            }
        }

        private void DisplayTask4()
        {
            var sortedBooks = this._productService.SortProductsByPrice();
            WriteColorLine(DisplayResource.Task4Title, ConsoleColor.Yellow);
            var table = new ConsoleTable("Book Name", "Price");
            foreach (var product in sortedBooks)
            {
                table.AddRow(product.ProductName, product.Price);
            }

            table.Write();
        }

        private void DisplayTask5()
        {
            var filteredResult = this._productService.FetchProductsWithSuppliers();
            WriteColorLine(DisplayResource.Task5Title, ConsoleColor.Yellow);
            var table = new ConsoleTable("Product ID", "Product Name", "Price", "Product Category", "Supplier ID", "Supplier Name");
            foreach (var product in filteredResult)
            {
                table.AddRow(product.ProductId, product.ProductName, product.Price, product.Category, product.SupplierId, product.SupplierName);
            }

            table.Write();
        }
    }
}
