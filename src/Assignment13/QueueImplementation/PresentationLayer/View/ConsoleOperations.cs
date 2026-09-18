using System;
using System.Linq;
using ConsoleUtilities;
using InputValidator;
using QueueImplementation.ApplicationLayer.Service;

namespace QueueImplementation.PresentationLayer.View
{
    /// <summary>
    /// Contains all methods that interacts with the user by getting input and displaying expected outcome
    /// </summary>
    public class ConsoleOperations
    {
        private QueueService<string> _queueService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleOperations"/> class.
        /// </summary>
        /// <param name="queueService">Queue Service object</param>
        public ConsoleOperations(QueueService<string> queueService)
        {
            this._queueService = queueService;
        }

        /// <summary>
        /// Initial method that is called from Program.cs
        /// </summary>
        public void Run()
        {
            this.AddPerson();
            this.DisplayWaitingQueue();
            this.RemovePerson();
            this.DisplayWaitingQueue();
        }

        private string GetPersonName()
        {
            Console.WriteLine(DisplayResource.PromptPersonName);
            string personName = Console.ReadLine().Trim();
            if (!StringValidator.ValidateString(personName))
            {
                ConsoleLogger.WriteColorLine(DisplayResource.NameFormatError, ConsoleColor.Red);
                return null;
            }

            return personName;
        }

        private void AddPerson()
        {
            ConsoleLogger.WriteColorLine(DisplayResource.AddPersonsHeading, ConsoleColor.Cyan);
            for (int i = 0; i < 5; i++)
            {
                string personName = this.GetPersonName();
                if (personName == null)
                {
                    return;
                }

                if (!this._queueService.EnqueuePeople(personName))
                {
                    ConsoleLogger.WriteColorLine(DisplayResource.DuplicateUser, ConsoleColor.Red);
                    return;
                }
            }
        }

        private void RemovePerson()
        {
            ConsoleLogger.WriteColorLine(DisplayResource.RemoveHeading, ConsoleColor.Cyan);
            if (!this._queueService.DequeuePeople())
            {
                ConsoleLogger.WriteColorLine(DisplayResource.UnsuccessfulDelete, ConsoleColor.Red);
                return;
            }

            ConsoleLogger.WriteColorLine(DisplayResource.SuccessfulDelete, ConsoleColor.Green);
        }

        private void DisplayWaitingQueue()
        {
            var waitingQueue = this._queueService.GetWaitingQueue();
            if (!waitingQueue.Any())
            {
                ConsoleLogger.WriteColorLine(DisplayResource.NoPeopleInQueue, ConsoleColor.Red);
                return;
            }

            ConsoleLogger.WriteColorLine(DisplayResource.PeopleInQueue, ConsoleColor.Cyan);
            foreach (var person in waitingQueue)
            {
                Console.WriteLine(person);
            }
        }
    }
}
