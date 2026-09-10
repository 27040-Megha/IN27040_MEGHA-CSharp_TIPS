using System.Collections.Generic;

namespace QueueImplementation.InfrastructureLayer
{
    public class QueueRepo<T>
    {
        private Queue<T> _waitingQueue;

        public QueueRepo()
        {
            this._waitingQueue = new Queue<T>();
        }

        public void AddPeople(T person)
        {
            this._waitingQueue.Enqueue(person);
        }

        public void RemovePeople()
        {
            this._waitingQueue.Dequeue();
        }

        public Queue<T> ReturnWaitingQueue()
        {
            return this._waitingQueue;
        }
    }
}
