using System;
using ValueAndReferenceTypes.ApplicationLayer.Service;
using ValueAndReferenceTypes.Domain.Model;
using ValueAndReferenceTypes.Domain.Strcuts;

namespace ValueAndReferenceTypes.PresentationLayer.View
{
    /// <summary>
    /// Displays Output to User
    /// </summary>
    public class ConsoleOperations
    {
        private readonly UpdateService _updateService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleOperations"/> class.
        /// </summary>
        /// <param name="updateService">UpdateService object</param>
        public ConsoleOperations(UpdateService updateService)
        {
            this._updateService = updateService;
        }

        /// <summary>
        /// Executes Task1 and Task2
        /// </summary>
        public void Run()
        {
            this.ExecuteTask1();
            this.ExecuteTask2();
        }

        private void ExecuteTask2()
        {
            this.CreateArray();
            this.CalculateSum();
        }

        private void ExecuteTask1()
        {
            var student = new Student()
            {
                RollNumber = "23CSR129",
                Name = "Megha E G",
                Department = "CSE",
                YearOfStudy = 4,
            };
            var newStudent = new Student()
            {
                RollNumber = "23CSR156",
                Name = "Prateeksha",
                Department = "CSE",
                YearOfStudy = 4,
            };
            this.HandleReferenceType(student, newStudent);
            var structStudent = new StudentStruct()
            {
                RollNumber = "23CSR129",
                Name = "Megha E G",
                Department = "CSE",
                YearOfStudy = 4,
            };
            var newStructStudent = new StudentStruct()
            {
                RollNumber = "23CSR156",
                Name = "Prateeksha",
                Department = "CSE",
                YearOfStudy = 4,
            };
            this.HandleValueType(structStudent, newStructStudent);
        }

        private void DisplayValueType(StudentStruct student)
        {
            Console.WriteLine($"Student RollNumber: {student.RollNumber}");
            Console.WriteLine($"Student Name: {student.Name}");
            Console.WriteLine($"Student Department: {student.Department}");
            Console.WriteLine($"Student Year Of Study: {student.YearOfStudy}\n");
        }

        private void HandleReferenceType(Student student, Student newStudent)
        {
            Console.WriteLine("Reference Type: ");
            Console.WriteLine("Before Modifying: ");
            this.DisplayReferenceType(student);
            this._updateService.Modify(student, newStudent);
            Console.WriteLine("After Modifying: ");
            this.DisplayReferenceType(student);
            Console.WriteLine("Value Type: ");
        }

        private void HandleValueType(StudentStruct structStudent, StudentStruct newStructStudent)
        {
            Console.WriteLine("Before Modifying: ");
            this.DisplayValueType(structStudent);
            this._updateService.Modify(structStudent, newStructStudent);
            Console.WriteLine("After Modifying: ");
            this.DisplayValueType(structStudent);
        }

        private void DisplayReferenceType(Student student)
        {
            Console.WriteLine($"Student RollNumber: {student.RollNumber}");
            Console.WriteLine($"Student Name: {student.Name}");
            Console.WriteLine($"Student Department: {student.Department}");
            Console.WriteLine($"Student Year Of Study: {student.YearOfStudy}\n");
        }

        private void CreateArray()
        {
            var integerArray = new int[100000];
            for (int i = 0; i < integerArray.Length; i++)
            {
                integerArray[i] = i;
            }
        }

        private void CalculateSum()
        {
            int sum = 0;
            for (int i = 0; i < int.MaxValue; i++)
            {
                int number = 1;
                sum += number;
            }
        }
    }
}
