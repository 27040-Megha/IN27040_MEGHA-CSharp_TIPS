using MemoryOptimization;

namespace Assignments
{
    /// <summary>
    /// Main Class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of Application
        /// </summary>
        /// <param name="args">Arguments</param>
        public static void Main(string[] args)
        {
            MemoryEater me = new MemoryEater();
            me.Allocate();
        }
    }
}