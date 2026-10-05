using System.Collections.Generic;

namespace QueueImplementation.InfrastructureLayer
{
    /// <summary>
    /// Contains a generic queue to store the People names and CRUD operation methods.
    /// </summary>
    /// <typeparam name="T">generic type</typeparam>
    public class QueueRepo<T>
    {
        private Queue<T> _waitingQueue;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueRepo{T}"/> class.
        /// </summary>
        public QueueRepo()
        {
            this._waitingQueue = new Queue<T>();
        }

        /// <summary>
        /// Adds person to Queue
        /// </summary>
        /// <param name="person">Person to be added</param>
        public void AddPeople(T person)
        {
            this._waitingQueue.Enqueue(person);
        }

        /// <summary>
        /// Removes people from Queue
        /// </summary>
        public void RemovePeople()
        {
            this._waitingQueue.Dequeue();
        }

        /// <summary>
        /// Returns the complete waiting Queue
        /// </summary>
        /// <returns>WaitingQueue</returns>
        public Queue<T> ReturnWaitingQueue()
        {
            return this._waitingQueue;
        }

        /// <summary>
        /// Checks if a person is found in the Waiting queue
        /// </summary>
        /// <param name="person">Person object to be searched</param>
        /// <returns>true if found, otherwise false</returns>
        public bool FindPerson(T person)
        {
            return this._waitingQueue.Contains(person);
        }
    }
}
