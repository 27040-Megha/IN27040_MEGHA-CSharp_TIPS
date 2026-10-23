using System.Diagnostics;
using SerializationAPI;

namespace Assignments
{
    /// <summary>
    /// Provides an entry point to the Application
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
                var printer = new Printer();
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                for (int i = 0; i < 10000; i++)
                {
                    ReflectionSerializer.Serialize(printer);
                }

                stopwatch.Stop();
                Console.WriteLine($"Time taken to serialize objects using Reflection serializer: {stopwatch.ElapsedMilliseconds} ms");
                var emitSerializer = EmitSerializer.CreateSerializeMethod();
                stopwatch.Restart();
                for (int i = 0; i < 10000; i++)
                {
                    emitSerializer(printer);
                }

                stopwatch.Stop();
                Console.WriteLine($"Time taken to serialize objects using Emit serializer: {stopwatch.ElapsedMilliseconds} ms");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}");
            }
        }
    }
}