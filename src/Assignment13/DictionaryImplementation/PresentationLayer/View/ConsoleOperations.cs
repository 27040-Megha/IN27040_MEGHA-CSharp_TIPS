using System;
using System.Linq;
using DictionaryImplementation.ApplicationLayer.Service;
using InputValidator;

namespace DictionaryImplementation.PresentationLayer.View
{
    public class ConsoleOperations
    {
        private StudentService<string, int> _studentService;

        public ConsoleOperations(StudentService<string, int> studentService)
        {
            this._studentService = studentService;
        }

        public void Run()
        {
            this.AddStudentGrade();
            this.DisplayStudentGrade();
            this.RemoveStudentGrade();
            this.DisplayStudentGrade();
        }

        private string GetStudentName()
        {
            Console.WriteLine("Enter Student Name: ");
            string studentName = Console.ReadLine();
            if (!StringValidator.ValidateString(studentName))
            {
                Console.WriteLine("Student Name should not be null or empty, and should contain only characters");
                return null;
            }

            return studentName;
        }

        private int GetGrade()
        {
            Console.WriteLine("Enter Grade (1 to 10): ");
            var isValidGrade = IntegerValidator.ValidateInteger(Console.ReadLine(), out int grade);
            if (!isValidGrade || !(grade >= 1 && grade <= 10))
            {
                Console.WriteLine("Enter a valid grade between 1 to 10!");
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
                    Console.WriteLine("Duplicate Student found, Cannot add Student to Repo");
                    return;
                }
            }
        }

        private void RemoveStudentGrade()
        {
            Console.WriteLine("\nRemove Student Details!");
            string studentToRemove = this.GetStudentName();
            if (studentToRemove == null)
            {
                return;
            }

            if (!this._studentService.DeleteStudent(studentToRemove))
            {
                Console.WriteLine("Student Name not found to delete!");
                return;
            }

            Console.WriteLine("Student result deleted Successfully!");
        }

        private void DisplayStudentGrade()
        {
            Console.WriteLine("\nStudent Details");
            var studentResult = this._studentService.GetStudentResult();
            if (!studentResult.Any())
            {
                Console.WriteLine("No Student Result Found!");
            }

            foreach (var student in studentResult)
            {
                Console.WriteLine($"{student.Key} - {student.Value}");
            }
        }
    }
}
