using EmployeeHierarchy.View;

namespace Assignments
{
    /// <summary>
    /// Entry point of application
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Entry point - Starts the Employee Hierarchy
        /// </summary>
        /// <param name="args">Args</param>
        public static void Main(string[] args)
        {
            EmployeeConsoleOperations consoleOperations = new EmployeeConsoleOperations();

            consoleOperations.ShowEmployeeHierarchy();
        }
    }
}