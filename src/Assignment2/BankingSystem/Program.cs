using BankingSystem.View;

namespace Assignments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankingConsoleOperation bankingConsole = new BankingConsoleOperation();
            bankingConsole.HandleMenu();
        }
    }
}