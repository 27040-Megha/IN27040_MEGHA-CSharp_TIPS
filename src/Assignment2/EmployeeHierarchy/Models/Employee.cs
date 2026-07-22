using System;

namespace EmployeeHierarchy.Models
{
    /// <summary>
    /// Abstract base class containing common employee properties and methods
    /// </summary>
    public abstract class Employee
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class.
        /// </summary>
        /// <param name="name">name of the employee</param>
        /// <param name="salary">salary of the employee</param>
        protected Employee(string name, decimal salary)
        {
            Name = name;
            Salary = salary;
        }

        /// <summary>
        /// Gets or sets name of the Employee
        /// </summary>
        /// <value>
        /// Name of the Employee
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Salary of the Employee
        /// </summary>
        /// <value>
        /// Salary of the Employee
        /// </value>
        public decimal Salary { get; set; }

        /// <summary>
        /// Gets or sets Bonus of the Employee
        /// </summary>
        /// <value>
        /// Bonus of the Employee
        /// </value>
        public decimal Bonus { get; set; }
        
        /// <summary>
        /// Base Abstract CalculateBonus() that will be overridden in subclasses
        /// </summary>
        /// <returns>Calculated Bonus</returns>
        public abstract decimal CalculateBonus();
        
        /// <summary>
        /// Returns the details to be printed
        /// </summary>
        /// <returns>Returns name and salary of the employee</returns>
        public virtual string GetDetails()
        {
            return $"Name: {Name} \nSalary: {Salary:F2}";
        }
    }
}