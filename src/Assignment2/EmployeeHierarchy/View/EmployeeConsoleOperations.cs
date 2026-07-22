using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using EmployeeHierarchy.Models;
using EmployeeHierarchy.Services;

namespace EmployeeHierarchy.View
{
    internal class EmployeeConsoleOperations
    {
        private EmployeeService _employeeService = new EmployeeService();

        internal void ShowEmployeeHierarchy()
        {
            int choice;
            do
            {
                PrintMenu();
                choice = GetMenuChoice();
                ProcessMenuChoice(choice);
            } while (choice != 3);
        }

        private void PrintMenu()
        {
            Console.WriteLine("EMPLOYEE HIERARCHY");
            Console.WriteLine("----------------------------");
            Console.WriteLine("1. Manager");
            Console.WriteLine("2. Developer");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");
        }

        private int GetMenuChoice()
        {
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                return choice;
            }
            return 0;
        }

        private void ProcessMenuChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nMANAGER DETAILS");
                    ManagerService();
                    break;
                case 2:
                    Console.WriteLine("\nDEVELOPER DETAILS");
                    ViewDeveloperService();
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine("Enter a valid choice (1/2/3)");
                    break;
            }
        }

        private void ManagerService()
        {
            var (name, salary) = GetEmployeeInputs();
            string managerDetails = ProcessManagerService(name, salary);
            PrintEmployeeDetails(managerDetails);
        }

        private void ViewDeveloperService()
        {
            var (name, salary) = GetEmployeeInputs();
            string developerDetails = ProcessDeveloperService(name, salary);
            PrintEmployeeDetails(developerDetails);
        }

        private (string name, decimal salary) GetEmployeeInputs()
        {
            Console.WriteLine("Enter Name : ");
            string name = Console.ReadLine();
            Console.Write($"Enter salary: ");
            decimal salary = ReturnValidSalary();
            return (name, salary);
        }

        private string ProcessManagerService(string name, decimal salary)
        {
            return _employeeService.ManagerEmployeeService(name, salary);
        }

        private string ProcessDeveloperService(string name, decimal salary)
        {
            return _employeeService.DeveloperEmployeeService(name, salary);
        }

        private void PrintEmployeeDetails(string details)
        {
            Console.WriteLine(details);
        }

        private decimal ReturnValidSalary()
        {
            string input = Console.ReadLine();
            if (decimal.TryParse(input, out decimal salary) && salary > 0)
            {
                return salary;
            }
            Console.Write("Invalid salary. Enter a positive numeric value: ");
            return ReturnValidSalary();
        }
    }
}