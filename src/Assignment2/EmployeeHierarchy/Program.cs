using EmployeeHierarchy.View;

namespace Assignments
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            EmployeeConsoleOperations consoleOperations = new EmployeeConsoleOperations();

            consoleOperations.ShowEmployeeHierarchy();
        }
    }
}