using System.Collections.Generic;
using EmployeeHierarchy.Models;

namespace EmployeeHierarchy.Services
{
    /// <summary>
    /// Contains the business logic of the Employee Hierarchy.
    /// </summary>
    internal class EmployeeService
    {
        /// <summary>
        /// Creates Manager objects, calculates bonuses and returns employee details.
        /// </summary>
        /// <param name="name">manager name</param>
        /// <param name="salary">manager salary</param>
        /// <returns>Details of Manager</returns>
        public string ManagerEmployeeService(string name, decimal salary)
        {
            Manager manager = CreateManager(name, salary);
            AssignManagerBonus(manager);
            return GetManagerDetails(manager);
        }

        /// <summary>
        /// Creates Developer objects, calculates bonuses and returns employee details.
        /// </summary>
        /// <param name="name">developer name</param>
        /// <param name="salary">developer salary</param>
        /// <returns>Details of Developer</returns>
        public string DeveloperEmployeeService(string name, decimal salary)
        {
            Developer developer = CreateDeveloper(name, salary);
            AssignDeveloperBonus(developer);
            return GetDeveloperDetails(developer);
        }

        /// <summary>
        /// Creates Manager object
        /// </summary>
        /// <param name="name">manager name</param>
        /// <param name="salary">manager salary</param>
        /// <returns>Manager Object</returns>
        private Manager CreateManager(string name, decimal salary)
        {
            return new Manager(name, salary);
        }

        /// <summary>
        /// Calclulate Manager Bonus and set in the object property
        /// </summary>
        /// <param name="manager">Manager object</param>
        private void AssignManagerBonus(Manager manager)
        {
            manager.Bonus = manager.CalculateBonus();
        }

        /// <summary>
        /// Return Details of manager to print in view
        /// </summary>
        /// <param name="manager">Manager Object</param>
        /// <returns>Details of manager</returns>
        private string GetManagerDetails(Manager manager)
        {
            return manager.GetDetails();
        }

        /// <summary>
        /// Creates Developer object
        /// </summary>
        /// <param name="name">developer name</param>
        /// <param name="salary">develoer salary</param>
        /// <returns>Developer Object</returns>
        private Developer CreateDeveloper(string name, decimal salary)
        {
            return new Developer(name, salary);
        }

        /// <summary>
        /// Calclulate Developer Bonus and set in the object property
        /// </summary>
        /// <param name="developer">Developer object</param>
        private void AssignDeveloperBonus(Developer developer)
        {
            developer.Bonus = developer.CalculateBonus();
        }

        /// <summary>
        /// Return Details of developer to print in view
        /// </summary>
        /// <param name="developer">Developer Object</param>
        /// <returns>Details of developer</returns>
        private string GetDeveloperDetails(Developer developer)
        {
            return developer.GetDetails();
        }
    }
}