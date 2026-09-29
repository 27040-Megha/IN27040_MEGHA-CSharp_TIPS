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
            this.DemonstrateValueAndReferenceType();
            this.DemonstrateMemoryAllocationTypes();
        }

        private void DemonstrateMemoryAllocationTypes()
        {
            this.CreateArray();
            this.CalculateSum();
        }

        private void DemonstrateValueAndReferenceType()
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
            Console.WriteLine(string.Format(DisplayResource.StudentDetailsTemplate, student.RollNumber, student.Name, student.Department, student.YearOfStudy));
        }

        private void HandleReferenceType(Student student, Student newStudent)
        {
            Console.WriteLine(DisplayResource.ReferenceType);
            Console.WriteLine(DisplayResource.BeforeModifying);
            this.DisplayReferenceType(student);
            this._updateService.Modify(student, newStudent);
            Console.WriteLine(DisplayResource.AfterModifying);
            this.DisplayReferenceType(student);
        }

        private void HandleValueType(StudentStruct structStudent, StudentStruct newStructStudent)
        {
            Console.WriteLine(DisplayResource.ValueType);
            Console.WriteLine(DisplayResource.BeforeModifying);
            this.DisplayValueType(structStudent);
            this._updateService.Modify(structStudent, newStructStudent);
            Console.WriteLine(DisplayResource.AfterModifying);
            this.DisplayValueType(structStudent);
        }

        private void DisplayReferenceType(Student student)
        {
            Console.WriteLine(string.Format(DisplayResource.StudentDetailsTemplate, student.RollNumber, student.Name, student.Department, student.YearOfStudy));
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
