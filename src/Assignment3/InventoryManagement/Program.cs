using System;
using InventoryManagement.Repository;
using InventoryManagement.Service;
using InventoryManagement.View;

namespace InventoryManagement
{
    /// <summary>
    /// Main Class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of application
        /// </summary>
        /// <param name="args">args</param>
        public static void Main(string[] args)
        {
            try
            {
                IProductRepository productRepository = new ProductRepository();

                IInventoryService inventoryService = new InventoryServices(productRepository);

                InventoryConsoleOperations inventoryConsole = new InventoryConsoleOperations(inventoryService);
                inventoryConsole.HandleMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                Console.ReadKey();
            }
        }
    }
}