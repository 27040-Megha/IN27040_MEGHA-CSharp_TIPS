using ValueAndReferenceTypes.Domain.Model;
using ValueAndReferenceTypes.Domain.Strcuts;

namespace ValueAndReferenceTypes.ApplicationLayer.Service
{
    /// <summary>
    /// Contains Business logic to update the data
    /// </summary>
    public class UpdateService
    {
        /// <summary>
        /// Edits the Data objects
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="item">Existing object</param>
        /// <param name="newItem">Object with updated details</param>
        public void Modify<T>(T item, T newItem)
        {
            if (item is Student studentItem && newItem is Student newStudentItem)
            {
                studentItem.RollNumber = newStudentItem.RollNumber;
                studentItem.Name = newStudentItem.Name;
                studentItem.Department = newStudentItem.Department;
                studentItem.YearOfStudy = newStudentItem.YearOfStudy;
            }
            else if (item is StudentStruct structStudent && newItem is StudentStruct newStructStudent)
            {
                structStudent.RollNumber = newStructStudent.RollNumber;
                structStudent.Name = newStructStudent.Name;
                structStudent.Department = newStructStudent.Department;
                structStudent.YearOfStudy = newStructStudent.YearOfStudy;
            }
        }
    }
}
