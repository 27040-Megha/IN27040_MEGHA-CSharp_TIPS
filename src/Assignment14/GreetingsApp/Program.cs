namespace Assignments
{
    /// <summary>
    /// Main class
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
                DisplayGreetingsMessage();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}");
            }
        }

        /// <summary>
        /// Display Greetings message to the Console.
        /// </summary>
        public static void DisplayGreetingsMessage()
        {
            Console.WriteLine($"Hi user, Welcome to Learning C#");
        }
    }
}