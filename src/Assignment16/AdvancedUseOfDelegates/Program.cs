using System;
using System.Collections.Generic;
using AdvancedUseOfDelegates;

namespace Assignments
{
    /// <summary>
    /// Main class
    /// </summary>
    public class Program
    {
        private static void Main(string[] args)
        {
            var products = LoadProducts();
            TextColor.WriteColorLine(DisplayResource.SortByName, ConsoleColor.Cyan);
            SortAndDisplay(ProductSortingService.SortByName, products);
            TextColor.WriteColorLine(DisplayResource.SortByCategory, ConsoleColor.Cyan);
            SortAndDisplay(ProductSortingService.SortByCategory, products);
            TextColor.WriteColorLine(DisplayResource.SortByPrice, ConsoleColor.Cyan);
            SortAndDisplay(ProductSortingService.SortByPrice, products);
        }

        private static List<Product> LoadProducts()
        {
            return new List<Product>()
            {
                new Product("Pen", "Stationary", 50),
                new Product("Notebook", "Stationary", 120),
                new Product("Wireless Mouse", "Electronics", 900),
                new Product("Bluetooth Earbuds", "Electronics", 2500),
                new Product("Bread Toaster", "Kitchen", 1600),
                new Product("Sticky Notes", "Stationary", 60),
            };
        }

        private static void SortAndDisplay(SortDelegate sortDelegate, List<Product> products)
        {
            products.Sort((firstProduct, secondProduct) => sortDelegate(firstProduct, secondProduct));
            foreach (var product in products)
            {
                Console.WriteLine(string.Format(DisplayResource.DisplayProduct, product.ProductName, product.Category, product.Price));
            }
        }
    }
}