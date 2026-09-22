namespace GarbageCollection.Domain.Model
{
    /// <summary>
    /// Model for Student class
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Gets or Sets the value of Student Roll Number
        /// </summary>
        /// <value>
        /// Student Roll Number
        /// </value>
        public int RollNumber { get; set; }

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
