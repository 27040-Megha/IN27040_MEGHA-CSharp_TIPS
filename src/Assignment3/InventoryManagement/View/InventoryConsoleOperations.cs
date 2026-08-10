using System;
using System.Collections.Generic;
using InventoryManagement.Helper;
using InventoryManagement.Models;
using InventoryManagement.Models.Enums;
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
        /// Handles Menu Options
        /// </summary>
        public void HandleMenu()
        {
            Console.WriteLine(InventoryResource.MenuHeader);
            byte input;
            MenuOption choice;
            do
            {
                this.DisplayMenu();
                bool isValidChoice = byte.TryParse(Console.ReadLine(), out input);
                choice = isValidChoice ? (MenuOption)input : MenuOption.Invalid;
                switch (choice)
                {
                    case MenuOption.CreateProduct:
                        this.CreateProduct();
                        break;
                    case MenuOption.UpdateProduct:
                        this.UpdateProduct();
                        break;
                    case MenuOption.RemoveProduct:
                        this.RemoveProduct();
                        break;
                    case MenuOption.SearchByName:
                        this.SearchByName();
                        break;
                    case MenuOption.SearchByID:
                        this.SearchByID();
                        break;
                    case MenuOption.DisplayInventory:
                        this.DisplayInventory();
                        break;
                    case MenuOption.Exit:
                        break;
                    default:
                        TextColor.WriteRedLine(InventoryResource.InvalidChoiceError);
                        break;
                }
            }
            while (choice != MenuOption.Exit);
        }

        private void DisplayMenu()
        {
            Console.WriteLine(InventoryResource.MenuOptions);
        }

        private void CreateProduct()
        {
            string productID = this.GetProductIDInput();
            if (productID == null)
            {
                return;
            }

            if (this._service.FindProductById(productID) != null)
            {
                TextColor.WriteRedLine(InventoryResource.AddDuplicateError);
                return;
            }

            var productToAdd = this.GetProductDetailsInput(productID);
            if (productToAdd == null)
            {
                return;
            }

            this._service.AddProductDetails(productToAdd);
            TextColor.WriteGreenLine(InventoryResource.AddSuccess);
        }

        private Product GetProductDetailsInput(string productID)
        {
            Console.WriteLine(InventoryResource.PromptProductName);
            string productName = Console.ReadLine();
            if (!FieldValidation.ValidateString(productName))
            {
                TextColor.WriteRedLine(InventoryResource.InvalidNameError);
                return null;
            }

            Console.WriteLine(InventoryResource.PromptProductCategory);
            string productCategory = Console.ReadLine();
            if (!FieldValidation.ValidateString(productCategory))
            {
                TextColor.WriteRedLine(InventoryResource.InvalidCategoryError);
                return null;
            }

            Console.WriteLine(InventoryResource.PromptUnitPrice);
            string inputPrice = Console.ReadLine();
            if (!decimal.TryParse(inputPrice, out decimal unitPrice) || !(unitPrice > 0))
            {
                TextColor.WriteRedLine(InventoryResource.InvalidPriceError);
                return null;
            }

            Console.WriteLine(InventoryResource.PromptStockQuantity);
            string stockInput = Console.ReadLine();
            bool isStockValid = int.TryParse(stockInput, out int stockQuantity) && stockQuantity >= 0;
            if (!isStockValid)
            {
                TextColor.WriteRedLine(InventoryResource.InvalidStockError);
                return null;
            }

            return new Product(productID, productName, productCategory, unitPrice, stockQuantity);
        }

        private string GetProductIDInput()
        {
            Console.WriteLine(InventoryResource.PromptProductID);
            string productID = Console.ReadLine();

            try
            {
                if (!FieldValidation.ValidateProductID(productID))
                {
                    TextColor.WriteRedLine(InventoryResource.InvalidIDError);
                    return null;
                }
            }
            catch (NullReferenceException ex)
            {
                TextColor.WriteRedLine(string.Format(InventoryResource.NullReferenceMessage, ex.Message));
                return null;
            }

            return productID;
        }

        private void UpdateProduct()
        {
            if (!this.HasProducts())
            {
                return;
            }

            string productID = this.GetProductIDInput();
            if (productID == null)
            {
                return;
            }

            var existingProduct = this._service.FindProductById(productID);
            if (existingProduct == null)
            {
                TextColor.WriteRedLine(InventoryResource.EditIDNotFound);
                return;
            }

            var productToUpdate = this.GetProductDetailsInput(productID);
            if (productToUpdate == null)
            {
                return;
            }

            this._service.EditProductDetails(existingProduct, productToUpdate);
            TextColor.WriteGreenLine(InventoryResource.EditSuccess);
        }

        private bool HasProducts()
        {
            if (this._service.GetProductsCount() == 0)
            {
                TextColor.WriteYellowLine(InventoryResource.InventoryEmptyWarning);
                return false;
            }

            return true;
        }

        private void RemoveProduct()
        {
            if (!this.HasProducts())
            {
                return;
            }

            string productID = this.GetProductIDInput();
            if (productID == null)
            {
                return;
            }

            bool isDeleted = this._service.DeleteProductDetails(productID);
            if (isDeleted)
            {
                TextColor.WriteGreenLine(InventoryResource.DeleteSuccess);
            }
            else
            {
                TextColor.WriteRedLine(InventoryResource.DeleteNotFoundError);
            }
        }

        private void SearchByName()
        {
            if (!this.HasProducts())
            {
                return;
            }

            Console.WriteLine(InventoryResource.PromptProductName);
            string productName = Console.ReadLine();
            if (!FieldValidation.ValidateString(productName))
            {
                TextColor.WriteRedLine(InventoryResource.InvalidNameError);
                return;
            }

            List<Product> productList = this._service.GetProductsByName(productName);
            if (productList.Count == 0)
            {
                TextColor.WriteRedLine(InventoryResource.SearchNameNotFoundError);
                return;
            }

            foreach (var product in productList)
            {
                this.DisplayProduct(product);
            }
        }

        private void SearchByID()
        {
            if (!this.HasProducts())
            {
                return;
            }

            string productID = this.GetProductIDInput();
            if (productID == null)
            {
                return;
            }

            Product product = this._service.FindProductById(productID);
            if (product == null)
            {
                TextColor.WriteRedLine(InventoryResource.SearchIDNotFoundError);
                return;
            }

            this.DisplayProduct(product);
        }

        private void DisplayInventory()
        {
            if (!this.HasProducts())
            {
                return;
            }

            List<Product> productsList = this._service.GetAllProductDetails();

            Console.WriteLine(new string('-', 95));
            Console.WriteLine("| {0,-10} | {1,-20} | {2,-15} | {3,-10} | {4,-10} | {5,-12} |", "ID", "Name", "Category", "Price", "Stock", "Total Price");
            foreach (var product in productsList)
            {
                this.DisplayProduct(product);
            }
        }

        private void DisplayProduct(Product product)
        {
            Console.WriteLine(new string('-', 95));
            Console.WriteLine("| {0,-10} | {1,-20} | {2,-15} | {3,-10:N2} | {4,-10} | {5,-12:N2} |",
                product.ProductId,
                product.ProductName,
                product.Category,
                product.Price,
                product.StockQuantity,
                product.TotalPrice);
            Console.WriteLine(new string('-', 95));
        }
    }
}
