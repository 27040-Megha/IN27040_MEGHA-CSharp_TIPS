using System.Collections.Generic;
using System.Linq;
using QueueImplementation.InfrastructureLayer;

namespace QueueImplementation.ApplicationLayer.Service
{
    /// <summary>
    /// Contains business logic to perform operations in Queue
    /// </summary>
    /// <typeparam name="T">Generic Type</typeparam>
    public class QueueService<T>
    {
        private QueueRepo<T> _queueRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueService{T}"/> class.
        /// </summary>
        /// <param name="queueRepo">Repository Object</param>
        public QueueService(QueueRepo<T> queueRepo)
        {
            this._queueRepo = queueRepo;
        }

        /// <summary>
        /// Checks if person already exists in queue, then adds to Queue
        /// </summary>
        /// <param name="person">Person to be added to queue</param>
        /// <returns>true if successfully added, otherwise false</returns>
        public bool EnqueuePeople(T person)
        {
            if (this._queueRepo.FindPerson(person))
            {
                return false;
            }

            this._queueRepo.AddPeople(person);
            return true;
        }

        /// <summary>
        /// Checks if any perso is there in Queue and then Dequeue's person from Queue
        /// </summary>
        /// <returns>true if successfully removed people from queue, otherwise false</returns>
        public bool DequeuePeople()
        {
            if (!this.GetWaitingQueue().Any())
            {
                return false;
            }

            this._queueRepo.RemovePeople();
            return true;
        }

        /// <summary>
        /// Returns the complete Waiting Queue
        /// </summary>
        /// <returns>Queue of waiting people</returns>
        public Queue<T> GetWaitingQueue()
        {
            return this._queueRepo.ReturnWaitingQueue();
        }
    }
}
