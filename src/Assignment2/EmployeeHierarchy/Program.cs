using EmployeeHierarchy.View;

namespace Assignments
{
    /// <summary>
    /// Entry point of application
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point - Starts the Employee Hierarchy
        /// </summary>
        /// <param name="args">Args</param>
        public static void Main(string[] args)
        {
            var consoleOperations = new EmployeeConsoleOperations();

            consoleOperations.ShowEmployeeHierarchy();
        }
    }
}