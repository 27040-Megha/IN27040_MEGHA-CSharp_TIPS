using System;

namespace EventsAndDelegates
{
    /// <summary>
    /// Class contains Notify delegate, OnAction event and Trigger method (Publisher class that publishes the event)
    /// </summary>
    public class Notifier
    {
        /// <summary>
        /// Delegate accepts string message and returns void
        /// </summary>
        /// <param name="message">Message</param>
        public delegate void Notify(string message);

        /// <summary>
        /// Event created using the Notify Delegate
        /// </summary>
        public event Notify OnAction;

        /// <summary>
        /// Method triggers the event using Invoke
        /// All the methods that has subscribed to the event will be notified and is executed in the order in which they are subscribed
        /// </summary>
        /// <param name="message">Message</param>
        public void Trigger(string message)
        {
            this.OnAction?.Invoke(message);
        }
    }
}
