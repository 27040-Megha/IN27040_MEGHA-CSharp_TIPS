using BasicContactManagement.Models;
using BasicContactManagement.Services;
using BasicContactManagement.View;

namespace BasicContactManagement
{
    /// <summary>
    /// Main Class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args">Doesn't return anything</param>
        public static void Main(string[] args)
        {
            ConsoleOperations consoleOperator = new ConsoleOperations();
            consoleOperator.DisplayAndHandlesMenu();
        }
    }
}