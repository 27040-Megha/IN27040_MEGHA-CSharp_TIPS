using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Models;
using InventoryManagement.Service;

namespace InventoryManagement.View
{
    /// <summary>
    /// Provides methods for all Console Operations
    /// </summary>
    public class InventoryConsoleOperations
    {
        private readonly IInventoryService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryConsoleOperations"/> class.
        /// </summary>
        /// <param name="service">Service object injected in Program.cs while creating object for InventoryConsoleOperations</param>
        public InventoryConsoleOperations(IInventoryService service)
        {
            this._service = service;
        }

        /// <summary>
        /// Prints the text in Red Color
        /// </summary>
        /// <param name="text">Input string</param>
        public static void WriteRedLine(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        /// <summary>
        /// Prints the text in Green Color
        /// </summary>
        /// <param name="text">Input string</param>
        public static void WriteGreenLine(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        /// <summary>
        /// Prints the text in Yellow Color
        /// </summary>
        /// <param name="text">Input string</param>
        public static void WriteYellowLine(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        /// <summary>
        /// Handles Menu Options
        /// </summary>
        public void HandleMenu()
        {
            Console.WriteLine(InventoryResource.MenuHeader);
            byte choice;
            do
            {
                this.DisplayMenu();
                bool isValidChoice = byte.TryParse(Console.ReadLine(), out choice);
                if (!isValidChoice)
                {
                    choice = 0;
                }

                switch (choice)
                {
                    case 1:
                        this.AddProducts();
                        break;
                    case 2:
                        this.EditProducts();
                        break;
                    case 3:
                        this.DeleteProducts();
                        break;
                    case 4:
                        this.SearchProductByName();
                        break;
                    case 5:
                        this.SearchProductByID();
                        break;
                    case 6:
                        this.ViewAllProducts();
                        break;
                    default:
                        WriteRedLine(InventoryResource.InvalidChoiceError);
                        break;
                }
            }
            while (choice != 7);
        }

        private void DisplayMenu()
        {
            Console.WriteLine(InventoryResource.MenuOptions);
        }

        private void AddProducts()
        {
            string productID = this.GetProductIDInput();
            if (productID == null)
            {
                return;
            }

            var details = this.GetProductDetailsInput();
            if (details == null)
            {
                return;
            }

            bool isSuccessfullyAdded = this._service.AddProductDetails(productID, details.Value.Name, details.Value.Category, details.Value.Price, details.Value.Stock);
            if (isSuccessfullyAdded)
            {
                WriteGreenLine(InventoryResource.AddSuccess);
            }
            else
            {
                WriteRedLine(InventoryResource.AddDuplicateError);
            }
        }

        private (string Name, string Category, decimal Price, int Stock)? GetProductDetailsInput()
        {
            Console.WriteLine(InventoryResource.PromptProductName);
            string productName = Console.ReadLine();
            if (!FieldValidation.ValidateString(productName))
            {
                WriteRedLine(InventoryResource.InvalidNameError);
                return null;
            }

            Console.WriteLine(InventoryResource.PromptProductCategory);
            string productCategory = Console.ReadLine();
            if (!FieldValidation.ValidateString(productCategory))
            {
                WriteRedLine(InventoryResource.InvalidCategoryError);
                return null;
            }

            Console.WriteLine(InventoryResource.PromptUnitPrice);
            string inputPrice = Console.ReadLine();
            if (!decimal.TryParse(inputPrice, out decimal unitPrice) || !(unitPrice > 0))
            {
                WriteRedLine(InventoryResource.InvalidPriceError);
                return null;
            }

            Console.WriteLine(InventoryResource.PromptStockQuantity);
            string stockInput = Console.ReadLine();
            bool isStockValid = int.TryParse(stockInput, out int stockQuantity) && stockQuantity >= 0;
            if (!isStockValid)
            {
                WriteRedLine(InventoryResource.InvalidStockError);
                return null;
            }

            return (productName, productCategory, unitPrice, stockQuantity);
        }

        private string GetProductIDInput()
        {
            Console.WriteLine(InventoryResource.PromptProductID);
            string productID = Console.ReadLine();

            if (!FieldValidation.ValidateProductID(productID))
            {
                WriteRedLine(InventoryResource.InvalidIDError);
                return null;
            }

            return productID;
        }

        private void EditProducts()
        {
            string productID = this.GetProductIDInput();
            if (productID == null)
            {
                return;
            }

            var details = this.GetProductDetailsInput();
            if (details == null)
            {
                return;
            }

            bool isSuccessfullyEdited = this._service.EditProductDetails(productID, details.Value.Name, details.Value.Category, details.Value.Price, details.Value.Stock);
            if (isSuccessfullyEdited)
            {
                WriteGreenLine(InventoryResource.EditSuccess);
            }
            else
            {
                WriteRedLine(InventoryResource.EditNotFoundError);
            }
        }

        private void DeleteProducts()
        {
            string productID = this.GetProductIDInput();
            if (productID == null)
            {
                return;
            }

            bool isDeleted = this._service.DeleteProductDetails(productID);
            if (isDeleted)
            {
                WriteGreenLine(InventoryResource.DeleteSuccess);
            }
            else
            {
                WriteRedLine(InventoryResource.DeleteNotFoundError);
            }
        }

        private void SearchProductByName()
        {
            Console.WriteLine(InventoryResource.PromptProductName);
            string productName = Console.ReadLine();
            if (!FieldValidation.ValidateString(productName))
            {
                WriteRedLine(InventoryResource.InvalidNameError);
                return;
            }

            List<IProduct> productList = this._service.GetProductsByName(productName);
            if (productList.Count == 0)
            {
                WriteRedLine(InventoryResource.SearchNameNotFoundError);
                return;
            }

            foreach (var product in productList)
            {
                this.DisplayProduct(product);
            }
        }

        private void SearchProductByID()
        {
            string productID = this.GetProductIDInput();
            if (productID == null)
            {
                return;
            }

            IProduct product = this._service.FindProductById(productID);
            if (product == null)
            {
                WriteRedLine(InventoryResource.SearchIDNotFoundError);
                return;
            }

            this.DisplayProduct(product);
        }

        private void ViewAllProducts()
        {
            List<IProduct> productsList = this._service.GetAllProductDetails();
            if (productsList.Count == 0)
            {
                WriteYellowLine(InventoryResource.InventoryEmptyWarning);
                return;
            }

            foreach (var product in productsList)
            {
                this.DisplayProduct(product);
            }
        }

        private void DisplayProduct(IProduct product)
        {
            Console.WriteLine(string.Format(InventoryResource.DisplayDetails, product.ProductId, product.ProductName, product.Category, product.Price, product.StockQuantity, product.TotalPrice));
            Console.WriteLine(InventoryResource.DisplayDivider);
        }
    }
}
