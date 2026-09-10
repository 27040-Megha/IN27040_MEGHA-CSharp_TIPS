using System.Collections.Generic;

namespace DictionaryImplementation.InfrastructureLayer
{
    public class StudentRepo<Tkey, TValue>
    {
        private Dictionary<Tkey, TValue> _studentResult;

        public StudentRepo()
        {
            this._studentResult = new Dictionary<Tkey, TValue>();
        }

        public void AddStudentResult(Tkey studentName, TValue grade)
        {
            this._studentResult.Add(studentName, grade);
        }

        public void RemoveStudentResult(Tkey studentName)
        {
            this._studentResult.Remove(studentName);
        }

        public Dictionary<Tkey, TValue> ReturnStudentResult()
        {
            return this._studentResult;
        }
    }
}
