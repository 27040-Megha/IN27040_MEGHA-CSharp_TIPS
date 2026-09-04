using System;

namespace CalculatorApp.PresentationLayer.Helper
{
    /// <summary>
    /// Provides method to display text in different colors
    /// </summary>
    public static class TextColor
    {
        /// <summary>
        /// Prints the text in Desired Color
        /// </summary>
        /// <param name="text">Input string</param>
        /// <param name="color">Color of the string</param>
        public static void WriteColoredLine(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
