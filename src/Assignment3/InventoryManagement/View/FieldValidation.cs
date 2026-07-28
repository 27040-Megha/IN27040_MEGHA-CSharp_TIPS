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
                if (productID.Length != 8)
                {
                    return false;
                }
                if (!productID.Substring(0, 4).Equals("PROD"))
                {
                    return false;
                }
                string suffix = productID.Substring(4, 4);
                foreach (char ch in suffix)
                {
                    if (!char.IsDigit(ch))
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (NullReferenceException ex)
            {
                InventoryConsoleOperations.WriteRedLine(string.Format(InventoryResource.NullReferenceMessage, ex.Message));
                return false;
            }
        }

        public static bool ValidateString(string inputString)
        {
            if (string.IsNullOrEmpty(inputString) || !inputString.All(char.IsLetter))
            {
                InventoryConsoleOperations.WriteRedLine(InventoryResource.InvalidStringFormat);
                 return false;
            }
            return true;
        }
    }
}
