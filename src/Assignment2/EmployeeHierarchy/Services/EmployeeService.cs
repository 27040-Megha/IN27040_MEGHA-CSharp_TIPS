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
        /// Creates Manager object
        /// </summary>
        /// <param name="name">manager name</param>
        /// <param name="salary">manager salary</param>
        /// <returns>Manager Object</returns>
        internal Manager CreateManager(string name, decimal salary)
        {
            return new Manager(name, salary);
        }

        /// <summary>
        /// Calclulate Manager Bonus and set in the object property
        /// </summary>
        /// <param name="manager">Manager object</param>
        internal void SetManagerBonus(Manager manager)
        {
            manager.Bonus = manager.CalculateBonus();
        }

        /// <summary>
        /// Return Details of manager to print in view
        /// </summary>
        /// <param name="manager">Manager Object</param>
        /// <returns>Details of manager</returns>
        internal string GetManagerDetails(Manager manager)
        {
            return manager.GetDetails();
        }

        /// <summary>
        /// Creates Developer object
        /// </summary>
        /// <param name="name">developer name</param>
        /// <param name="salary">develoer salary</param>
        /// <returns>Developer Object</returns>
        internal Developer CreateDeveloper(string name, decimal salary)
        {
            return new Developer(name, salary);
        }

        /// <summary>
        /// Calclulate Developer Bonus and set in the object property
        /// </summary>
        /// <param name="developer">Developer object</param>
        internal void SetDeveloperBonus(Developer developer)
        {
            developer.Bonus = developer.CalculateBonus();
        }

        /// <summary>
        /// Return Details of developer to print in view
        /// </summary>
        /// <param name="developer">Developer Object</param>
        /// <returns>Details of developer</returns>
        internal string GetDeveloperDetails(Developer developer)
        {
            return developer.GetDetails();
        }
    }
}