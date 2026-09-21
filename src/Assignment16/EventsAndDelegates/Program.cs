using System;
using EventsAndDelegates;

namespace Assignments
{
    /// <summary>
    /// Main class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Create object for Notifier class, Subscribe methods to the event and triggers the event
        /// </summary>
        /// <param name="args">Args</param>
        public static void Main(string[] args)
        {
            var notifier = new Notifier();
            notifier.OnAction += SendWhatsAppNotification;
            notifier.OnAction += SendEmailNotification;
            notifier.Trigger("Your Order has been confirmed!");
            notifier.OnAction -= SendEmailNotification;
            notifier.OnAction -= SendWhatsAppNotification;
        }

        private static void SendWhatsAppNotification(string message)
        {
            TextColor.WriteColorLine(message, ConsoleColor.Green);
        }

        private static void SendEmailNotification(string message)
        {
            TextColor.WriteColorLine(message, ConsoleColor.Blue);
        }
    }
}