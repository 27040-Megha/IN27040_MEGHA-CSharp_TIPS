using System;
using System.Linq;
using InputValidator;
using QueueImplementation.ApplicationLayer.Service;

namespace QueueImplementation.PresentationLayer.View
{
    public class ConsoleOperations
    {
        private QueueService<string> _queueService;

        public ConsoleOperations(QueueService<string> queueService)
        {
            this._queueService = queueService;
        }

        public void Run()
        {
            this.AddPerson();
            this.DisplayWaitingQueue();
            this.RemovePerson();
            this.DisplayWaitingQueue();
        }

        private string GetPersonName()
        {
            Console.WriteLine("Enter Person Name: ");
            string personName = Console.ReadLine();
            if (!StringValidator.ValidateString(personName))
            {
                Console.WriteLine("Person Name should not be null or empty, and should contain only characters");
                return null;
            }

            return personName;
        }

        private void AddPerson()
        {
            Console.WriteLine("Add Five Persons to Queue");
            for (int i = 0; i < 5; i++)
            {
                string personName = this.GetPersonName();
                if (personName == null)
                {
                    return;
                }

                if (!this._queueService.EnqueuePeople(personName))
                {
                    Console.WriteLine("Person Already added to Queue, Can't Add again!");
                    return;
                }
            }
        }

        private void RemovePerson()
        {
            Console.WriteLine("\nRemove people from Queue");
            if (!this._queueService.DequeuePeople())
            {
                Console.WriteLine("No people waiting in the Queue to delete!");
                return;
            }

            Console.WriteLine("Removed a person from Waiting Queue Successfully!");
        }

        private void DisplayWaitingQueue()
        {
            var waitingQueue = this._queueService.GetWaitingQueue();
            if (!waitingQueue.Any())
            {
                Console.WriteLine("\nNo people in the waiting queue!");
                return;
            }

            Console.WriteLine("\nPeople waiting in Waiting Queue!");
            foreach (var person in waitingQueue)
            {
                Console.WriteLine(person);
            }
        }
    }
}
