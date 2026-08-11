using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.View
{
    /// <summary>
    /// Provides methods to display text in different colors
    /// </summary>
    public static class TextColor
    {
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
    }
}
