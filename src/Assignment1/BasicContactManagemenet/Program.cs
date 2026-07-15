using BasicContactManagement.Models;
using BasicContactManagement.Services;
using BasicContactManagement.View;

namespace BasicContactManagement
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ConsoleOperations consoleOperator = new ConsoleOperations();
            consoleOperator.DisplayAndHandlesMenu();
        }
    }
}