using AdvancedLINQChallenges.ApplicationLayer.Service;
using AdvancedLINQChallenges.InfrastructureLayer;
using AdvancedLINQChallenges.PresentationLayer.View;

namespace Assignments
{
    /// <summary>
    /// Starting point of application
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args">Arguments</param>
        public static void Main(string[] args)
        {
            try
            {
                var productRepo = new ProductRepo();
                var supplierRepo = new SupplierRepo();
                var supplierService = new SupplierService(supplierRepo);
                var productService = new ProductService(productRepo, supplierService);
                var consoleOperator = new ConsoleOperations(productService, supplierService);
                consoleOperator.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught: " + ex.Message);
            }
        }
    }
}