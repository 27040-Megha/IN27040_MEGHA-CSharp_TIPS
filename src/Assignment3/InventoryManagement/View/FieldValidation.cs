using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Models;

namespace InventoryManagement.View
{
    public static class FieldValidation
    {
        public static bool ValidateProductID(string productID)
        {
            try
            {
                if(productID.Length != 8)
                {
                    return false;
                }
                if(!productID.Substring(0, 4).Equals("PROD"))
                {
                    return false;
                }
                string suffix = productID.Substring(4, 4);
                foreach(char ch in suffix)
                {
                    if(!char.IsDigit(ch))
                    {
                        return false;
                    }
                }
                return true;
            }
            catch(NullReferenceException ex)
            {
                InventoryConsoleOperations.WriteRedLine($"Null Reference Caught: {ex.Message}");
                return false;
            }
        }

        public static bool ValidateString(string inputString)
        {
            if(!inputString.All(char.IsLetter))
            {
                InventoryConsoleOperations.WriteRedLine($"Invalid input! The input should contain only letters");
                return false;
            }
            return true;
        }     
    }
}
