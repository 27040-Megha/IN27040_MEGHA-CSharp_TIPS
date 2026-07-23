using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using EmployeeHierarchy.Models;
using EmployeeHierarchy.Services;

namespace EmployeeHierarchy.View
{
    /// <summary>
    /// Handles user interaction through the console.
    /// </summary>
    internal class EmployeeConsoleOperations
    {
        private EmployeeService _employeeService = new EmployeeService();
        /// <summary>
        /// Handles Employee Hierarchy console Operations
        /// </summary>
        internal void ShowEmployeeHierarchy()
        {
            int choice;
            do
            {
                PrintMenu();
                choice = GetMenuChoice();
                ProcessMenuChoice(choice);
            } 
            while (choice != 3);
        }
        private void PrintMenu()
        {
            Console.WriteLine(EmployeeMessages.MenuOptions);
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
                    Console.WriteLine(EmployeeMessages.ManagerHeader);
                    ManagerService();
                    break;
                case 2:
                    Console.WriteLine(EmployeeMessages.DeveloperHeader);
                    ViewDeveloperService();
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine(EmployeeMessages.InvalidChoice);
                    break;
            }
        }

        private void ManagerService()
        {
            var (name, salary) = GetEmployeeInputs();
            if (name == null || salary == -1)
            {
                return;
            }
            string managerDetails = ProcessManagerService(name, salary);
            PrintEmployeeDetails(managerDetails);
        }

        private void ViewDeveloperService()
        {
            var (name, salary) = GetEmployeeInputs();
            if (name == null || salary == -1)
            {
                return;
            }
            string developerDetails = ProcessDeveloperService(name, salary);
            PrintEmployeeDetails(developerDetails);
        }

        private (string name, decimal salary) GetEmployeeInputs()
        {
            Console.WriteLine(EmployeeMessages.NamePrompt);
            string name = Console.ReadLine();
            if (!ValidateName(name))
            {
                return (null, -1);
            }
            Console.Write(EmployeeMessages.SalaryPrompt);
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
            Console.WriteLine(EmployeeMessages.InvalidSalary);
            return -1;
        }

        private bool ValidateName(string name)
        {
            if (!string.IsNullOrEmpty(name) && name.All(char.IsLetter))
            {
                return true;
            }
            Console.WriteLine(EmployeeMessages.InvalidName);
            return false;
        }
    }
}
