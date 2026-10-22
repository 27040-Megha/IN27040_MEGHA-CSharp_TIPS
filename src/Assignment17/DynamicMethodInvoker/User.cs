using System;

namespace DynamicMethodInvoker
{
    /// <summary>
    /// Class definition for User
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the value of UserName
        /// </summary>
        /// <value>
        /// The value of UserName
        /// </value>
        public string UserName { get; set; }

        /// <summary>
        /// Prints the greeting message to the Console
        /// </summary>
        public void GreetUser()
        {
            Console.WriteLine($"Hello User {this.UserName}");
        }
    }
}
