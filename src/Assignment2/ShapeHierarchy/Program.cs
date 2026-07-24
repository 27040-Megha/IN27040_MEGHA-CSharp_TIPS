using ShapeHierarchy.View;
namespace Assignments
{
    /// <summary>
    /// Entry point of application
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point - Starts the Shape Hierarchy
        /// </summary>
        /// <param name="args">Args</param>
        public static void Main(string[] args)
        {
            var consoleOperator = new ConsoleOperations();
            consoleOperator.ShowShapeHierarchy();
        }
    }
}