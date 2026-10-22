using System;
using DynamicMethodInvoker;

namespace Assignments
{
    /// <summary>
    /// Provides an entry point to application
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of Application
        /// </summary>
        public static void Main()
        {
            try
            {
                var methodInvoker = new MethodInvoker();
                var user = new User()
                {
                    UserName = "Megha",
                };
                methodInvoker.InvokeMethod(user, "GreetUser");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}");
            }
        }
    }
}