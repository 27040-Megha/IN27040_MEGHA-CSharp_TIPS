using System.Collections.Generic;

namespace DictionaryImplementation.InfrastructureLayer
{
    /// <summary>
    /// Contains a generic dictionary to map student name with their grades and CRUD operation methods.
    /// </summary>
    /// <typeparam name="Tkey">Generic key type - Student Name</typeparam>
    /// <typeparam name="TValue">Generic value type - grade</typeparam>
    public class StudentRepo<Tkey, TValue>
    {
        private Dictionary<Tkey, TValue> _studentResult;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentRepo{Tkey, TValue}"/> class.
        /// </summary>
        public StudentRepo()
        {
            this._studentResult = new Dictionary<Tkey, TValue>();
        }

        /// <summary>
        /// Adds the Student Name and grade as a key-value pair to the dictionary.
        /// </summary>
        /// <param name="studentName">key - name of student</param>
        /// <param name="grade">value - grade of the student</param>
        public void AddStudentResult(Tkey studentName, TValue grade)
        {
            this._studentResult.Add(studentName, grade);
        }

        /// <summary>
        /// Removes student from dictionary using key
        /// </summary>
        /// <param name="studentName">Student Name to be removed</param>
        public void RemoveStudentResult(Tkey studentName)
        {
            this._studentResult.Remove(studentName);
        }

        /// <summary>
        /// Returns the complete StudentResult Dictionary
        /// </summary>
        /// <returns>Student Result Dictionary</returns>
        public Dictionary<Tkey, TValue> ReturnStudentResult()
        {
            return this._studentResult;
        }
    }
}
