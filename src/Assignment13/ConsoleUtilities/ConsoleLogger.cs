namespace ConsoleUtilities
{
    /// <summary>
    /// Contains method to print text in specific colors
    /// </summary>
    public static class ConsoleLogger
    {
        /// <summary>
        /// Prints the text in Specific Color
        /// </summary>
        /// <param name="text">Input String</param>
        /// <param name="colorChoice">Specific color of text to be displayed</param>
        public static void WriteColorLine(string text, ConsoleColor colorChoice)
        {
            Console.ForegroundColor = colorChoice;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
