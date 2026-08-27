using AdvancedLINQChallenges.ApplicationLayer.Service;
using AdvancedLINQChallenges.InfrastructureLayer;
using AdvancedLINQChallenges.PresentationLayer.View;

namespace Assignments
{
    public class Program
    {
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