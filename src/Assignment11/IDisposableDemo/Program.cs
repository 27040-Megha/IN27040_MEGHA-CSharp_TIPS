using System;
using IDisposableDemo;
using IDisposableDemo.InfrastructureLayer;

namespace Assignments
{
    /// <summary>
    /// Entry point of application
    /// </summary>
    public class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                using (var writer = new FileWriter(Resource.FilePath))
                {
                    writer.WriteFile(Resource.FileData);
                }

                using (var reader = new FileReader(Resource.FilePath))
                {
                    var fileContent = reader.ReadFile();
                    foreach (var line in fileContent)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exeption Caught: " + ex.Message);
            }
        }
    }
}