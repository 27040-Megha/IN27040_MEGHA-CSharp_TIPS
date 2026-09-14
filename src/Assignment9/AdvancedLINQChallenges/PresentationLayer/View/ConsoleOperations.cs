using System;
using System.Collections.Generic;
using System.Linq;
using AdvancedLINQChallenges.ApplicationLayer.Service;
using AdvancedLINQChallenges.Domain;
using ConsoleTables;

namespace AdvancedLINQChallenges.PresentationLayer.View
{
    /// <summary>
    /// Interacts with User
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

        private void WriteColorLine(string text, ConsoleColor colorChoice)
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
                new Product(4, "Headphones", 450m, "Electronics"),
                new Product(5, "C# in Depth", 2500m, "Books"),
                new Product(6, "Clean Code", 1800m, "Books"),
                new Product(7, "Design Patterns", 3200m, "Books"),
            };

            foreach (var product in products)
            {
                this._productService.AddProduct(product);
            }
        }

        private void DisplayTask1()
        {
            this.WriteColorLine(DisplayResource.Task1Title, ConsoleColor.Yellow);
            var sortedElectronicProducts = this._productService.FilterElectronicProducts();
            this.DisplayConsoleTable(sortedElectronicProducts);
            decimal averagePrice = Math.Round(this._productService.FindAveragePrice(sortedElectronicProducts), 2);
            this.WriteColorLine(string.Format(DisplayResource.Task1AveragePrice, averagePrice), ConsoleColor.Cyan);
        }

        private void DisplayTask2()
        {
            this.WriteColorLine(DisplayResource.Task2Title, ConsoleColor.Yellow);
            this.DisplayProductsMappedWithSuppliers();
            this.DisplayProductsCategoryWise();
        }

        private void DisplayProductsMappedWithSuppliers()
        {
            var mappedProducts = this._productService.MapProductsWithSuppliers();
            this.DisplayConsoleTable(mappedProducts);
        }

        private void DisplayProductsCategoryWise()
        {
            this.WriteColorLine(DisplayResource.Task2CategorizedHeader, ConsoleColor.Yellow);
            var categorizedProducts = this._productService.GroupProductsByCategory();
            foreach (var category in categorizedProducts)
            {
                this.WriteColorLine(string.Format(DisplayResource.Task2CategoryLabel, category.Category), ConsoleColor.Cyan);
                Console.WriteLine(string.Format(DisplayResource.Task2ProductCountLabel, category.ProductCount));
                Console.WriteLine(string.Format(DisplayResource.Task2ExpensiveProductLabel, category.ExpensiveProduct.ProductId, category.ExpensiveProduct.ProductName, category.ExpensiveProduct.Price));
            }
        }

        private void DisplayTask4()
        {
            var sortedBooks = this._productService.SortProductsByPrice();
            this.WriteColorLine(DisplayResource.Task4Title, ConsoleColor.Yellow);
            this.DisplayConsoleTable(sortedBooks);
        }

        private void DisplayTask5()
        {
            var filteredResult = this._productService.FetchProductsWithSuppliers();
            this.WriteColorLine(DisplayResource.Task5Title, ConsoleColor.Yellow);
            this.DisplayConsoleTable(filteredResult);
        }

        private void DisplayConsoleTable<T>(IEnumerable<T> data)
        {
            var properties = typeof(T).GetProperties();
            var columnNames = properties.Select(p => p.Name).ToArray();
            var table = new ConsoleTable(columnNames);
            foreach (var item in data)
            {
                var row = properties.Select(p => p.GetValue(item)).ToArray();
                table.AddRow(row);
            }

            table.Write();
        }
    }
}
