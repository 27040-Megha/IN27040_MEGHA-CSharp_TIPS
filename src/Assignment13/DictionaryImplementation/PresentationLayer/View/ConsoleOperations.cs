using System;
using System.Linq;
using ConsoleUtilities;
using DictionaryImplementation.ApplicationLayer.Service;
using InputValidator;

namespace DictionaryImplementation.PresentationLayer.View
{
    /// <summary>
    /// Contains all methods that interacts with the user by getting input and displaying expected outcome
    /// </summary>
    public class ConsoleOperations
    {
        private StudentService<string, int> _studentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleOperations"/> class.
        /// </summary>
        /// <param name="studentService">Service object</param>
        public ConsoleOperations(StudentService<string, int> studentService)
        {
            this._studentService = studentService;
        }

        /// <summary>
        /// Initial method that is called from Program.cs
        /// </summary>
        public void Run()
        {
            this.AddStudentGrade();
            this.DisplayStudentGrade();
            this.RemoveStudentGrade();
            this.DisplayStudentGrade();
        }

        private string GetStudentName()
        {
            Console.WriteLine(DisplayResource.PromptStudentName);
            string studentName = Console.ReadLine();
            if (!StringValidator.ValidateString(studentName))
            {
                ConsoleLogger.WriteColorLine(DisplayResource.InvalidStudentNameError, ConsoleColor.Red);
                return null;
            }

            return studentName;
        }

        private int GetGrade()
        {
            Console.WriteLine(DisplayResource.PromptGrade);
            var isValidGrade = IntegerValidator.ValidateInteger(Console.ReadLine(), out int grade);
            if (!isValidGrade || !(grade >= 1 && grade <= 10))
            {
                ConsoleLogger.WriteColorLine(DisplayResource.InvalidGradeError, ConsoleColor.Red);
                return -1;
            }

            return grade;
        }

        private void AddStudentGrade()
        {
            for (int i = 0; i < 5; i++)
            {
                string studentName = this.GetStudentName();
                if (studentName == null)
                {
                    return;
                }

                int grade = this.GetGrade();
                if (grade == -1)
                {
                    return;
                }

                if (!this._studentService.CreateStudentResult(studentName, grade))
                {
                    ConsoleLogger.WriteColorLine(DisplayResource.DuplicateStudentError, ConsoleColor.Red);
                    return;
                }
            }
        }

        private void RemoveStudentGrade()
        {
            ConsoleLogger.WriteColorLine(DisplayResource.RemoveStudentHeading, ConsoleColor.Cyan);
            string studentToRemove = this.GetStudentName();
            if (studentToRemove == null)
            {
                return;
            }

            if (!this._studentService.DeleteStudent(studentToRemove))
            {
                ConsoleLogger.WriteColorLine(DisplayResource.NameNotFoundToDelete, ConsoleColor.Red);
                return;
            }

            ConsoleLogger.WriteColorLine(DisplayResource.SuccessfullyDeleted, ConsoleColor.Green);
        }

        private void DisplayStudentGrade()
        {
            ConsoleLogger.WriteColorLine(DisplayResource.StudentDetailsHeading, ConsoleColor.Cyan);
            var studentResult = this._studentService.GetStudentResult();
            if (!studentResult.Any())
            {
                ConsoleLogger.WriteColorLine(DisplayResource.StudentNotFound, ConsoleColor.Red);
            }

            foreach (var student in studentResult)
            {
                Console.WriteLine($"{student.Key} - {student.Value}");
            }
        }
    }
}
