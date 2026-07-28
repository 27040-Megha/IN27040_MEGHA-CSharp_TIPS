using System;
using InventoryManagement.Repository;
using InventoryManagement.Service;
using InventoryManagement.View;

namespace Assignments
{
    public class Program
    {
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