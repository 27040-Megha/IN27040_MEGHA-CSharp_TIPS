using ReadOnlyCollections.ApplicationLayer.Service;
using ReadOnlyCollections.PresentationLayer.View;

namespace Assignments
{
    public class Program
    {
        private static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;
            var collectionService = new CollectionService();
            var consoleOperator = new ConsoleOperations(collectionService);
            consoleOperator.Run();
        }

        private static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                Console.WriteLine("Exception Caught: " + ex.Message);
            }
        }
    }
}