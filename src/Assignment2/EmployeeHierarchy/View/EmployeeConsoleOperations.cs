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
                    HandleEmployeeService("Manager");
                    break;
                case 2:
                    Console.WriteLine(EmployeeMessages.DeveloperHeader);
                    HandleEmployeeService("Developer");
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine(EmployeeMessages.InvalidChoice);
                    break;
            }
        }

        private void HandleEmployeeService(string employeeType)
        {
            var (name, salary) = GetEmployeeInputs();
            if (name == null || salary == -1)
            {
                return;
            }

            var employee = CreateEmployee(employeeType, name, salary);
            if (employee != null)
            {
                PrintEmployeeDetails(employee);
            }
        }

        private Employee CreateEmployee(string employeeType, string name, decimal salary)
        {
            if (employeeType == "Manager")
            {
                var manager = _employeeService.CreateManager(name, salary);
                _employeeService.SetManagerBonus(manager);
                return manager;
            }
            else if (employeeType == "Developer")
            {
                var developer = _employeeService.CreateDeveloper(name, salary);
                _employeeService.SetDeveloperBonus(developer);
                return developer;
            }
            return null;
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

        private void PrintEmployeeDetails(Employee employee)
        {
            string details;
            if (employee is Manager manager)
            {
                details = _employeeService.GetManagerDetails(manager);
            }
            else
            {
                var developer = (Developer)employee;
                details = _employeeService.GetDeveloperDetails(developer);
            }
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
