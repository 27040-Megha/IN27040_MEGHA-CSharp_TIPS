using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Models.Enums
{
    /// <summary>
    /// Enum for Menu Options
    /// </summary>
    public enum MenuOption : byte
    {
        /// <summary>
        /// Invalid Choice
        /// </summary>
        Invalid = 0,

        /// <summary>
        /// Add Product in Inventory
        /// </summary>
        CreateProduct,

        /// <summary>
        /// Update Product in Inventory
        /// </summary>
        UpdateProduct,

        /// <summary>
        /// Remove Product
        /// </summary>
        RemoveProduct,

        /// <summary>
        /// Search Product By Name
        /// </summary>
        SearchByName,

        /// <summary>
        /// Search Product by ProductID
        /// </summary>
        SearchByID,

        /// <summary>
        /// Display Product Details from Inventory
        /// </summary>
        DisplayInventory,

        /// <summary>
        /// Exit Application
        /// </summary>
        Exit,
    }
}
