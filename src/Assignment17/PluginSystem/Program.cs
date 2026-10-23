using System.Reflection;
using SecurityInterface;

namespace Host
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
                Console.Write("Enter text to Encrypt: ");
                string text = Console.ReadLine();
                var files = Directory.GetFiles(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Plugins")));
                foreach (var file in files)
                {
                    var assembly = Assembly.LoadFrom(file);
                    foreach (var type in assembly.GetTypes())
                    {
                        if (type.IsClass && !type.IsAbstract && typeof(ISecurity).IsAssignableFrom(type))
                        {
                            var encryptor = (ISecurity)Activator.CreateInstance(type);
                            Console.WriteLine(encryptor.AlgorithmName);
                            var encryptedText = encryptor.Encrypt(text);
                            Console.WriteLine("Encrypted Text: " + encryptedText);
                            var decryptedText = encryptor.Decrypt(encryptedText);
                            Console.WriteLine("Decrypted Text: " + decryptedText);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}");
            }
        }
    }
}
