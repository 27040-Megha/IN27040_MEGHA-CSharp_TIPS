using System;
using DynamicObjectInspector;

namespace Assignments
{
    /// <summary>
    /// Provides entry point to application
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of Application
        /// </summary>
        public static void Main()
        {
            try
            {
                var laptop = new Product(1, "HP PROBOOK", 75000m);
                var objectInspector = new ObjectInspector();
                Console.WriteLine("Property values before updating: ");
                objectInspector.DisplayProperties(laptop);
                var isValidPrice = GetProductPrice(out decimal newPrice);
                if (!isValidPrice)
                {
                    Console.WriteLine($"Invalid price format, price should be a decimal");
                    return;
                }

                Console.WriteLine("Property values after updating:");
                objectInspector.UpdateProperty(laptop, "Price", newPrice);
                objectInspector.DisplayProperties(laptop);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}");
            }
        }

        private static bool GetProductPrice(out decimal productPrice)
        {
            Console.WriteLine("Enter new Price for the product: ");
            return decimal.TryParse(Console.ReadLine(), out productPrice);
        }
    }
}