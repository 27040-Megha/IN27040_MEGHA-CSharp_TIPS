using System.Collections.Generic;
using EmployeeHierarchy.Models;

namespace EmployeeHierarchy.Services
{
    internal class EmployeeService
    {
        public string ManagerEmployeeService(string name, decimal salary)
        {
            Manager manager = CreateManager(name, salary);
            AssignManagerBonus(manager);
            return PrintManagerDetails(manager);
        }

        public string DeveloperEmployeeService(string name, decimal salary)
        {
            Developer developer = CreateDeveloper(name, salary);
            AssignDeveloperBonus(developer);
            return PrintDeveloperDetails(developer);
        }

        private Manager CreateManager(string name, decimal salary)
        {
            return new Manager(name, salary);
        }

        private void AssignManagerBonus(Manager manager)
        {
            manager.Bonus = manager.CalculateBonus();
        }

        private string PrintManagerDetails(Manager manager)
        {
            return manager.GetDetails();
        }

        private Developer CreateDeveloper(string name, decimal salary)
        {
            return new Developer(name, salary);
        }

        private void AssignDeveloperBonus(Developer developer)
        {
            developer.Bonus = developer.CalculateBonus();
        }

        private string PrintDeveloperDetails(Developer developer)
        {
            return developer.GetDetails();
        }
    }
}