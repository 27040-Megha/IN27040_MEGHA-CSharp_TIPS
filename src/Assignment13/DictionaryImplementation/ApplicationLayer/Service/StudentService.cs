using System.Collections.Generic;
using DictionaryImplementation.InfrastructureLayer;

namespace DictionaryImplementation.ApplicationLayer.Service
{
    /// <summary>
    /// Contains business logic to perform operations with Dictionary
    /// </summary>
    /// <typeparam name="Tkey">Generic type of key</typeparam>
    /// <typeparam name="TValue">Generic type of value</typeparam>
    public class StudentService<Tkey, TValue>
    {
        private StudentRepo<Tkey, TValue> _studentRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentService{Tkey, TValue}"/> class.
        /// </summary>
        /// <param name="studentRepo">Infrastructure Layer repo object</param>
        public StudentService(StudentRepo<Tkey, TValue> studentRepo)
        {
            this._studentRepo = studentRepo;
        }

        /// <summary>
        /// Checks if key already exists in the repo, before adding in repo
        /// </summary>
        /// <param name="studentName">Student Name - key</param>
        /// <param name="grade">Grade of student</param>
        /// <returns>true if successfully added to repo, otherwise false</returns>
        public bool CreateStudentResult(Tkey studentName, TValue grade)
        {
            if (this.GetStudentResult().ContainsKey(studentName))
            {
                return false;
            }

            this._studentRepo.AddStudentResult(studentName, grade);
            return true;
        }

        /// <summary>
        /// Checks if the studentName exists in the Dictionary in repo, then deletes from repo
        /// </summary>
        /// <param name="studentName">Student Name to be deleted</param>
        /// <returns>true if successfully deleted, otherwise false</returns>
        public bool DeleteStudent(Tkey studentName)
        {
            if (!this.GetStudentResult().ContainsKey(studentName))
            {
                return false;
            }

            this._studentRepo.RemoveStudentResult(studentName);
            return true;
        }

        /// <summary>
        /// Returns the complete StudentResult Dictionary
        /// </summary>
        /// <returns>Student Result Dictionary</returns>
        public Dictionary<Tkey, TValue> GetStudentResult()
        {
            return this._studentRepo.ReturnStudentResult();
        }
    }
}
