using System;
using System.Threading;

namespace GarbageCollection.Domain.Model
{
    /// <summary>
    /// Model for Student class
    /// </summary>
    public class Student
    {
        private static int _count = 0;

        public Student()
        {
            _count++;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="Student"/> class.
        /// </summary>
        ~Student()
        {
            Console.WriteLine(_count);
        }

        /// <summary>
        /// Gets or Sets the value of Student Roll Number
        /// </summary>
        /// <value>
        /// Student Roll Number
        /// </value>
        public string RollNumber { get; set; }

        /// <summary>
        /// Gets or Sets the value of Student Name
        /// </summary>
        /// <value>
        /// Student Name
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets the value of Student's Department
        /// </summary>
        /// <value>
        /// Department of Study
        /// </value>
        public string Department { get; set; }

        /// <summary>
        /// Gets or Sets the value of Student's Year of Study
        /// </summary>
        /// <value>
        /// Year Of Study
        /// </value>
        public byte YearOfStudy { get; set; }
    }
}
