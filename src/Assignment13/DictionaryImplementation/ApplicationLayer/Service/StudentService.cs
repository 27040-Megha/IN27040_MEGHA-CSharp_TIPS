using System.Collections.Generic;
using DictionaryImplementation.InfrastructureLayer;

namespace DictionaryImplementation.ApplicationLayer.Service
{
    public class StudentService<Tkey, TValue>
    {
        private StudentRepo<Tkey, TValue> _studentRepo;

        public StudentService(StudentRepo<Tkey, TValue> studentRepo)
        {
            this._studentRepo = studentRepo;
        }

        public bool CreateStudentResult(Tkey studentName, TValue grade)
        {
            if (this.GetStudentResult().ContainsKey(studentName))
            {
                return false;
            }

            this._studentRepo.AddStudentResult(studentName, grade);
            return true;
        }

        public bool DeleteStudent(Tkey studentName)
        {
            if (!this.GetStudentResult().ContainsKey(studentName))
            {
                return false;
            }

            this._studentRepo.RemoveStudentResult(studentName);
            return true;
        }

        public Dictionary<Tkey, TValue> GetStudentResult()
        {
            return this._studentRepo.ReturnStudentResult();
        }
    }
}
