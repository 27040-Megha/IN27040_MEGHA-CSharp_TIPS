using System;

namespace Assignments
{
    /// <summary>
    /// Main Class
    /// </summary>
    public class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                // Type of var keyword is checked during Compile Time
                var number = 5;
                Console.WriteLine(number);

                // Changing type of var keyword throws Compile-Time Error
                // CS0029 - Cannot implicitly convert type 'string' to 'int'
                // This is because C# is a strongly typed language (Ensures type safety during Compile Time)
                //number = "five";

                // The type of dynamic variables is checked at run-time, so changing type of variable is accepted with dynamic keyword
                dynamic message = "Hi";
                Console.WriteLine(message);
                Console.WriteLine($"Message Length: {message.Length}");

                // Here we have changed the type of message to double from string
                // Now trying to print the length of message will throw an Unhandled Run-time Exception
                message = 5.5;
                Console.WriteLine(message);
                Console.WriteLine($"Message Length: {message.Length}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}