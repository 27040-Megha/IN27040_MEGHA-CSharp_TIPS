using BankingSystem.View;

namespace Assignments
{
    /// <summary>
    /// Entry point of application
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Entry point - Starts the Banking System's Handle Menu
        /// </summary>
        /// <param name="args">Args</param>
        private static void Main(string[] args)
        {
            BankingConsoleOperation bankingConsole = new BankingConsoleOperation();
            bankingConsole.HandleMenu();
        }
    }
}