using BankingSystem.View;

namespace Assignments
{
    /// <summary>
    /// Entry point of application
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point - Starts the Banking System's Handle Menu
        /// </summary>
        /// <param name="args">Args</param>
        public static void Main(string[] args)
        {
            BankingConsoleOperation bankingConsole = new BankingConsoleOperation();
            bankingConsole.HandleMenu();
        }
    }
}