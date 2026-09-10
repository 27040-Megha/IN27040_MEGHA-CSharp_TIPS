using System.Collections.Generic;
using System.Linq;
using QueueImplementation.InfrastructureLayer;

namespace QueueImplementation.ApplicationLayer.Service
{
    public class QueueService<T>
    {
        private QueueRepo<T> _queueRepo;

        public QueueService(QueueRepo<T> queueRepo)
        {
            this._queueRepo = queueRepo;
        }

        public bool EnqueuePeople(T person)
        {
            if (this._queueRepo.FindPerson(person))
            {
                return false;
            }

            this._queueRepo.AddPeople(person);
            return true;
        }

        public bool DequeuePeople()
        {
            if (!this.GetWaitingQueue().Any())
            {
                return false;
            }

            this._queueRepo.RemovePeople();
            return true;
        }

        public Queue<T> GetWaitingQueue()
        {
            return this._queueRepo.ReturnWaitingQueue();
        }
    }
}
