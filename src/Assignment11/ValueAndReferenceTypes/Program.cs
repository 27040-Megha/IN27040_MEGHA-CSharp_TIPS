using ValueAndReferenceTypes.ApplicationLayer.Service;
using ValueAndReferenceTypes.PresentationLayer.View;

namespace Assignments
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;
            var updateService = new UpdateService();
            var consoleOperator = new ConsoleOperations(updateService);
            consoleOperator.Run();
        }

        public static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                Console.WriteLine($"Exception Message: {ex.Message}");
            }
        }
    }
}