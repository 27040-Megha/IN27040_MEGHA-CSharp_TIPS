using System;

namespace CalculatorApp.PresentationLayer.View
{
    /// <summary>
    /// Class that contain methods to set cursor positions
    /// </summary>
    public static class CursorPositions
    {
        /// <summary>
        /// Cursor position to print the result
        /// </summary>
        public static void Result()
        {
            Console.SetCursorPosition(39, 4);
        }

        /// <summary>
        /// Cursor position to print the error
        /// </summary>
        public static void Error()
        {
            Console.SetCursorPosition(0, 12);
        }

        /// <summary>
        /// Cursor position to get the input
        /// </summary>
        public static void Input()
        {
            Console.SetCursorPosition(2, 3);
        }

        /// <summary>
        /// Cursor position to set default cursor position
        /// </summary>
        public static void Default()
        {
            Console.SetCursorPosition(0, 16);
        }
    }
}
