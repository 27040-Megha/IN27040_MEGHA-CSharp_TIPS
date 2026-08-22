namespace EmployeeHierarchy.Models
{
    /// <summary>
    /// Inherits from Employee and calculates salary bonus for managers
    /// </summary>
    public class Manager : Employee
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Manager"/> class.
        /// </summary>
        /// <param name="name">name of the manager</param>
        /// <param name="salary">salary of the manager</param>
        public Manager(string name, decimal salary) 
            : base(name, salary)
        {
        }

        /// <summary>
        /// Caclulates and returns bonus of manager
        /// </summary>
        /// <returns>Bonus of manager</returns>
        public override decimal CalculateBonus()
        {
            return Salary * 0.20m;
        }

        /// <summary>
        /// Returns manager details that needed to be printed
        /// </summary>
        /// <returns>manager details as string</returns>
        public override string GetDetails()
        {
            return $"Employee Type : Manager \n{base.GetDetails()} \nBonus : {Bonus:F2}";
        }
    }
}