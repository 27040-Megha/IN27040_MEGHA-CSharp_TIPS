using System;

namespace EmployeeHierarchy.Models
{
    public abstract class Employee
    {
        protected Employee(string name, decimal salary)
        {
            Name = name;
            Salary = salary;
        }

        public string Name { get; set; }
        public decimal Salary { get; set; }
        public decimal Bonus { get; set; }
        public abstract decimal CalculateBonus();
        public virtual string GetDetails()
        {
            return $"Name: {Name} \nSalary: {Salary:F2}";
        }
    }
}